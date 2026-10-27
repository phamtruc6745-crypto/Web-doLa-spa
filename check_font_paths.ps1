$fa = Get-Content 'Styles/font-awesome.min.css' -Raw
$ei = Get-Content 'Styles/elegant-icons.css' -Raw
$faUrls = [regex]::Matches($fa, 'url\(([^)]+)\)') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
$eiUrls = [regex]::Matches($ei, 'url\(([^)]+)\)') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "FA: $($faUrls -join ', ')"
Write-Host "EI: $($eiUrls -join ', ')"
