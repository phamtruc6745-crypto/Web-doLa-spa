$url = "https://www.w3schools.com/html/mov_bbb.mp4"
$out = "Videos\spa-intro-video.mp4"
$webclient = New-Object System.Net.WebClient
$webclient.Headers.Add("User-Agent", "Mozilla/5.0")
$webclient.DownloadFile($url, $out)
Write-Output "Video size: $((Get-Item $out).Length)"
