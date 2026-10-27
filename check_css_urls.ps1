$css = Get-Content 'Styles/style.css' -Raw
$fontUrls = [regex]::Matches($css, 'url\(([^)]+)\)') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "URLs in style.css: $($fontUrls -join ', ')"
