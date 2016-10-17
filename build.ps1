param ( [switch] $ZipRelease = $false )

#Define que qualquer erro que ocorreu deverá para o script.
$ErrorActionPreference = "Stop"

#Define o diretório de output do build.
$output = '.\output'

#Cria o diretório de output se não existir.
if (!(Test-Path $output)) {
    New-Item $output -ItemType Directory
}

#Define o caminho completo para o diretório de output.
$outputPath = Resolve-Path $output

#Whitelist de arquivos e pastas que podem ficar dentro da raiz do diretório de build.
$WhiteList = @("dados", "dll", "ControlePontos.exe", "ControlePontos.exe.config")

#Define o diretório de dependências do projeto.
$DestinoDll = (Join-Path $outputPath 'dll')

#Obtém a pasta do msbuild v4 via registro do windows.
$msbuildPath = (Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\MSBuild\ToolsVersions\14.0").MSBuildToolsPath

#Lança um erro caso a pasta não for encontrada.
if ([System.String]::IsNullOrEmpty($msbuildPath)) {
    throw "MSBuild 14.0 não foi encontrado no computador local. Provavelmente esse computar não tem o Visual Studio 2015 instalado."
}    

#Gera o caminho completo até o .exe do msbuild.
$msbuild = Join-Path $msbuildPath 'msbuild.exe'

#Lança um erro caso o arquivo do msbuild não for encontrado.
if (!(Test-Path $msbuild)) {
    throw "MSBuild.exe não foi encontrado na pasta $($msbuildPath)"
}

#Remove a pasta de build se ela já existir.
if (Test-Path $outputPath) {
    Remove-Item $outputPath -Recurse
}

#Caso o executável do nuget não existir, baixa e salva no mesmo diretório do script.
if (!(Test-Path '.\nuget.exe')) {
    Write-Host 'Nuget.exe não foi encontrado. Baixando...'
    Invoke-WebRequest 'https://dist.nuget.org/win-x86-commandline/latest/nuget.exe' -UseBasicParsing -OutFile '.\nuget.exe'
}

#Executa o comando para restaurar os pacotes do nuget da solução.
Write-Host 'Restaurando packages'
Start-Process -FilePath ".\nuget.exe" -NoNewWindow -Wait -ArgumentList "restore"

#Executa o comando de build.
Start-Process -FilePath $msbuild -NoNewWindow -Wait -ArgumentList "./ControlePontos.sln", "/t:Build", "/p:Configuration=Release", "/p:DebugType=None", "/p:AllowedReferenceRelatedFileExtensions=None", "/p:OutputPath=$($outputPath)"

#Cria a pasta de destino de todas as dlls do projeto.
New-Item $DestinoDll -ItemType Directory

#Move todas os arquivos e pastas para o diretório de dependências.
Get-ChildItem -Path $outputPath | Where-Object { $WhiteList -notcontains $_ } | Move-Item -Destination $DestinoDll

#Verifica se é para criar o zip do release.
if ($ZipRelease) {
    Write-Host "Criando arquivo zip do release"

    #Carrega o namespace que contém a classe responsável por criar o arquivo zip.
    Add-Type -AssemblyName "System.IO.Compression.FileSystem"

    #Obtém a versão do 'controle de pontos' pelo executavel.  
    $versao = (Get-ChildItem (Join-Path $outputPath 'ControlePontos.exe') | Select-Object -ExpandProperty VersionInfo).FileVersion
    $versao = $versao.Substring(0, $versao.Length - 2)

    #Monta o destino no arquivo zip.
    $destino = Join-Path (Resolve-Path '.\') "controle-pontos-$($versao).zip"

    #Remove o arquivo zip se ela já existir.
    if (Test-Path $destino) {
        Remove-Item $destino
    }

    #Cria o arquivo zip.
    [System.IO.Compression.ZipFile]::CreateFromDirectory($outputPath, $destino)

    #Remove a pasta de build.
    Remove-Item $outputPath -Recurse -Confirm:$false
}