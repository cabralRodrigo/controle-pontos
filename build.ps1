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

#Executa o comando de build.
Start-Process -FilePath $msbuild -NoNewWindow -Wait -ArgumentList "./ControlePontos.sln", "/t:Build", "/p:Configuration=Release", "/p:DebugType=None", "/p:AllowedReferenceRelatedFileExtensions=None", "/p:OutputPath=..\built"