#Obtém a pasta do msbuild v4 via registro do windows.
$msbuildPath = (Get-ItemProperty "HKLM:\SOFTWARE\Microsoft\MSBuild\ToolsVersions\4.0").MSBuildToolsPath

#Lança um erro caso a pasta não for encontrada.
if ([System.String]::IsNullOrEmpty($msbuildPath)) {
    throw "MSBuild não foi encontrado no computador local."
}    

#Gera o caminho completo até o .exe do msbuild.
$msbuild = Join-Path $msbuildPath 'msbuild.exe'

#Lança um erro caso o arquivo do msbuild não for encontrado.
if (!(Test-Path $msbuild)) {
    throw "MSBuild.exe não foi encontrado na pasta $($msbuildPath)"
}

#Executa o comando de build.
Invoke-Expression "$msbuild ./ControlePontos.sln /t:Build /p:Configuration=Release /p:DebugType=None /p:AllowedReferenceRelatedFileExtensions=None /p:OutputPath=..\built"