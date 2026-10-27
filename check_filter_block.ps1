$grid = Get-Content 'shop-grid.html' -Raw -Encoding UTF8
$start = $grid.IndexOf('<div class="filter__item">')
$end = $grid.IndexOf('<div class="product__pagination">')
Write-Host "Length between filter__item and pagination: $($end - $start)"
Write-Host $grid.Substring($start, [Math]::Min(1500, $end - $start))
