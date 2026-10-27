$htmlFiles = @(
    'index.html',
    'shop-grid.html',
    'shop-details.html',
    'shoping-cart.html',
    'checkout.html',
    'blog.html',
    'blog-details.html',
    'contact.html'
)

$missing = @()
$found = 0

foreach ($file in $htmlFiles) {
    $content = Get-Content $file -Raw -Encoding UTF8
    
    # Matches src="Images/..." or data-setbg="Images/..."
    $regex = '(?:src|data-setbg)="(Images/[^"#\?]+)"'
    $matches = [regex]::Matches($content, $regex)
    
    foreach ($m in $matches) {
        $imgPath = $m.Groups[1].Value
        # Replace forward slash with backslash for local test
        $localPath = $imgPath.Replace('/', '\')
        if (Test-Path $localPath) {
            $found++
        } else {
            $missing += "$file -> $imgPath"
        }
    }
}

Write-Host "Found verified image references: $found"
if ($missing.Count -gt 0) {
    Write-Host "MISSING IMAGES ($($missing.Count)):" -ForegroundColor Red
    $missing | Select-Object -Unique | ForEach-Object { Write-Host " - $_" }
} else {
    Write-Host "ALL IMAGE REFERENCES EXIST ON DISK! 100% OK" -ForegroundColor Green
}
