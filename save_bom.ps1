$cs = Get-Content 'Generator.cs' -Raw
[System.IO.File]::WriteAllText('Generator.cs', $cs, (New-Object System.Text.UTF8Encoding($true)))
Write-Host "Generator.cs saved with UTF-8 BOM"
