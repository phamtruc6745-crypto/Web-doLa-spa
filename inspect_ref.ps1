$url = 'https://duongnt1998.github.io/WebDesign_UTC2/index.html'
$resp = Invoke-WebRequest -Uri $url -UseBasicParsing
Write-Host "Status: $($resp.StatusCode)"
$title = [regex]::Match($resp.Content, '<title>(.*?)</title>').Groups[1].Value
Write-Host "Title: $title"
$links = [regex]::Matches($resp.Content, 'href=["'']([^"'']+\.html)["'']') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "Links found: $($links -join ', ')"

# Check stylesheets and scripts
$css = [regex]::Matches($resp.Content, 'href=["'']([^"'']+\.css)["'']') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "CSS found: $($css -join ', ')"

$js = [regex]::Matches($resp.Content, 'src=["'']([^"'']+\.js)["'']') | ForEach-Object { $_.Groups[1].Value } | Select-Object -Unique
Write-Host "JS found: $($js -join ', ')"
