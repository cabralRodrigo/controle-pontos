$ErrorActionPreference = "Stop"
Add-Type -AssemblyName "System.IO.Compression.FileSystem"	
	
if ($env:APPVEYOR) { 
	$buildpath = Join-Path $env:APPVEYOR_BUILD_FOLDER "ControlePontos.UI\bin\$($env:CONFIGURATION)"
	$pastadependencias = Join-Path $buildpath 'dll'
	$artifactzip = Join-Path $env:APPVEYOR_BUILD_FOLDER "controle-pontos-release.zip"	
	
	if (!(Test-Path $artifactzip)) {
		Get-ChildItem $buildpath -Recurse -Include '*.xml', '*.pdb' | foreach ($_) { Remove-Item $_.FullName }
		Get-ChildItem -Path $buildpath | Where-Object { @("dados", "dll", "ControlePontos.exe", "ControlePontos.exe.config") -notcontains $_ } | Move-Item -Destination $pastadependencias

		[System.IO.Compression.ZipFile]::CreateFromDirectory($buildpath, $artifactzip)

		Write-Host "Caminho do zip: $($artifactzip)"
		Push-AppveyorArtifact $artifactzip
	}
}
