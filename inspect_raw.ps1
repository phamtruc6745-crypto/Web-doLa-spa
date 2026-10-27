$html = Get-Content 'raw_index.html' -Raw
$imgs = [regex]::Matches($html, 'src=["'']([^"'']+\.(?:png|jpg|jpeg|svg|webp))["'']') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
$bgImgs = [regex]::Matches($html, 'data-setbg=["'']([^"'']+\.(?:png|jpg|jpeg|svg|webp))["'']') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "Total inline img: $($imgs.Count)"
Write-Host "Total bg img: $($bgImgs.Count)"
Write-Host "Sample inline: $($imgs -join ', ')"
Write-Host "Sample bg: $($bgImgs -join ', ')"
