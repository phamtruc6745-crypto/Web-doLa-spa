$mainJs = Get-Content 'Scripts/main.js' -Raw
Write-Host "Length: $($mainJs.Length)"
Write-Host "Content preview:"
$mainJs.Substring(0, [Math]::Min(1500, $mainJs.Length))
