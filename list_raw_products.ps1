$raw = Get-Content 'raw_shop-grid.html' -Raw
$matches = [regex]::Matches($raw, '<h5><a href="#">(.*?)</a></h5>') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "Unique products in raw_shop-grid.html:"
$matches | ForEach-Object { Write-Host " - $_" }
