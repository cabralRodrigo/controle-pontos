function Get-Tipo ($char) {
	$retorno = ""
	switch ($char) {
		'+' { $retorno = "Adi$([char]0x00E7)$([char]0x00E3)o de funcionalidade" }
		'!' { $retorno = "Corre$([char]0x00E7)$([char]0x00E3)o de bugs" }
		'*' { $retorno = "Altera$([char]0x00E7)$([char]0x00F5)es em n$([char]0x00ED)vel de c$([char]0x00F3)digo e arquitetura do projeto" }
		'@' { $retorno = "Altera$([char]0x00E7)$([char]0x00F5)es em funcionalidades j$([char]0x00E1) existentes" }
		default { $retorno = "Outras altera$([char]0x00E7)$([char]0x00F5)es" }
	}
	
	return [System.Net.WebUtility]::HtmlEncode($retorno)
}


function Get-Changelog {
	$changelog = [System.Collections.ArrayList]@()
		
	$atual = @{}
	$atual.Mudancas = [System.Collections.ArrayList]@()
	
	Get-Content .\changelog.txt -Encoding utf8 | ForEach-Object {
		
		if ($_ -eq "") {
			$changelog.Add($atual) | Out-Null
			$atual = @{}
			$atual.Mudancas = [System.Collections.ArrayList]@()
		}
		else {
			if ($_.Substring(0, 1) -eq "`t") {
				$mudanca = @{}
				$mudanca.Tipo = Get-Tipo $_.SubString(1, 1)
				$mudanca.Descricao = [System.Net.WebUtility]::HtmlEncode($_.SubString(3))
				
				$atual.Mudancas.Add($mudanca) | Out-Null
			}
			else {
				$partes = $_.Split(' ', 2)
				$atual.Versao = $partes[1].Replace(':', '')
				$atual.Data = [DateTime]::ParseExact($partes[0], 'dd/MM/yyyy', $null)
			}
		}   
	}	
	return $changelog
}
