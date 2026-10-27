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

Write-Host "=== VERIFYING HTML FILES ==="

foreach ($file in $htmlFiles) {
    if (-not (Test-Path $file)) {
        Write-Host "MISSING: $file" -ForegroundColor Red
        continue
    }
    $content = Get-Content $file -Raw -Encoding UTF8
    
    # Check old paths
    $hasCss = $content -match 'href="css/'
    $hasJs = $content -match 'src="js/'
    $hasImg = $content -match 'src="img/' -or $content -match 'data-setbg="img/'
    
    Write-Host "$file : CSS old=$hasCss | JS old=$hasJs | IMG old=$hasImg"
}
