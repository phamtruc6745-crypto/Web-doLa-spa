$htmls = Get-ChildItem -Path . -Filter "raw_*.html"
$allImgs = @()
foreach ($h in $htmls) {
    $content = Get-Content $h.FullName -Raw
    $srcs = [regex]::Matches($content, 'src=["''](img/[^"'']+)["'']') | ForEach-Object { $_.Groups[1].Value }
    $bgs = [regex]::Matches($content, 'data-setbg=["''](img/[^"'']+)["'']') | ForEach-Object { $_.Groups[1].Value }
    $allImgs += $srcs
    $allImgs += $bgs
}
$uniqueImgs = $allImgs | Select-Object -Unique | Sort-Object
Write-Host "Total unique images across all pages: $($uniqueImgs.Count)"
$uniqueImgs | ForEach-Object { Write-Host $_ }
