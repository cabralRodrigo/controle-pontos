param ( [switch] $ZipRelease = $false )

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
if (Test-Path '.\built') {
    Remove-Item '.\built' -Recurse
}

#Executa o comando de build.
Start-Process -FilePath $msbuild -NoNewWindow -Wait -ArgumentList "./ControlePontos.sln", "/t:Build", "/p:Configuration=Release", "/p:DebugType=None", "/p:AllowedReferenceRelatedFileExtensions=None", "/p:OutputPath=..\built"

#Verifica se é para criar o zip do release.
if ($ZipRelease) {
    Write-Host "Criando arquivo zip do release"

    #Carrega o namespace que contém a classe responsável por criar o arquivo zip.
    Add-Type -AssemblyName "System.IO.Compression.FileSystem"

    #Obtém a versão do 'controle de pontos' pelo executavel.  
    $versao = (Get-ChildItem '.\built\ControlePontos.exe' | Select-Object -ExpandProperty VersionInfo).FileVersion
    $versao = $versao.Substring(0, $versao.Length - 2)

    #Monta a pasta de origem dos arquivo do zip.
    $origem = Join-Path (Resolve-Path '.\') 'built'

    #Monta o destino no arquivo zip.
    $destino = Join-Path (Resolve-Path '.\') "controle-pontos-$($versao).zip"

    #Remove o arquivo zip se ela já existir.
    if (Test-Path $destino) {
        Remove-Item $destino
    }
    
    #Cria o arquivo zip.
    [System.IO.COmpression.ZipFile]::CreateFromDirectory($origem, $destino)

    #Remove a pasta de build.
    Remove-Item $origem -Recurse -Confirm:$false
}