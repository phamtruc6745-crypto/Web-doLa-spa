$html = Get-Content 'raw_shop-grid.html' -Raw
Write-Host "Title: " ([regex]::Match($html, '<title>(.*?)</title>').Groups[1].Value)

# Find sections in raw_shop-grid.html
$sections = [regex]::Matches($html, '<section[^>]*class=["'']([^"'']+)["'']') | ForEach-Object { $_.Groups[1].Value }
Write-Host "Sections: $($sections -join ' | ')"

# Check sale off section
$hasSaleOff = $html -match 'Sale Off'
Write-Host "Has 'Sale Off': $hasSaleOff"

# Check sidebar
$sidebarMatches = [regex]::Matches($html, '<div[^>]*class=["'']sidebar__item[^"'']*["'']>[\s\S]*?<h4>(.*?)</h4>') | ForEach-Object { $_.Groups[1].Value }
Write-Host "Sidebar items: $($sidebarMatches -join ' | ')"
