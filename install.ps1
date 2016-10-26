#Importa a função que carrega o changelog.
. ".\changelog.ps1"

#Só executa o script se estiver executando no appveyor.
if ($env:APPVEYOR) {
    #Carrega o changelog e obtém a versão do primeiro log na lista.
    $changelog = (Get-Changelog)[0]
    
    $linebreak = "\n"#"<br>"#[System.Net.WebUtility]::HtmlEncode([Environment]::NewLine)
    
    Write-Host "Versão: $($changelog.Versao)"
    
    #Monta o markdown do changelog para o github.
    $sb = New-Object -TypeName "System.Text.StringBuilder"
    $changelog.Mudancas | Group-Object {$_.Tipo} | ForEach-Object {
        
        [void]$sb.AppendFormat("**{0}:**{1}", $_.Name, $linebreak)
    
        $_.Group | ForEach-Object {
            [void]$sb.AppendFormat("* {0}{1}", $_.Descricao, $linebreak)
        }
        
        [void]$sb.Append($linebreak)
    }
    [void]$sb.Remove($sb.Length - 4, 4)
    
    #Define as variáveis de ambiente do app-veyor.
    $env:versao = $changelog.Versao
    $env:changelog = $sb.ToString()
        
    Write-Host "Changelog: $($env:changelog)"
}
