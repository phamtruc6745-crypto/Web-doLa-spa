$bytes = [System.IO.File]::ReadAllBytes('shop-grid.html')
$str = [System.Text.Encoding]::UTF8.GetString($bytes)
$match = [regex]::Match($str, '<h5><a href="#">(.*?)</a></h5>')
Write-Host "Product name UTF8: $($match.Groups[1].Value)"
