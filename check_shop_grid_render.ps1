$grid = Get-Content 'shop-grid.html' -Raw
$idx = $grid.IndexOf('product__discount')
if ($idx -ge 0) {
    Write-Host "Found product__discount at $idx"
    Write-Host $grid.Substring($idx, [Math]::Min(1500, $grid.Length - $idx))
}
