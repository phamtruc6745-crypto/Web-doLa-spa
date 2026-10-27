$grid = Get-Content 'raw_shop-grid.html' -Raw
$saleOffMatch = [regex]::Match($grid, '(<div class="product__discount">[\s\S]*?</div>\s*</div>\s*</div>\s*</div>)')
Write-Host "Sale Off block preview:"
$saleOffMatch.Value.Substring(0, [Math]::Min(1200, $saleOffMatch.Value.Length))
