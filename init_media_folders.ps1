# Create readme/metadata in Sounds and Videos if empty, or download sample media
$soundPath = "Sounds/spa-relaxing-music.mp3"
$videoPath = "Videos/spa-intro-video.mp4"

# Create valid minimal files if not existing
if (-not (Test-Path $soundPath)) {
    # 1 second silent MP3 header/frame bytes
    $silentMp3 = [byte[]](0xFF, 0xFB, 0x90, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00)
    [System.IO.File]::WriteAllBytes($soundPath, $silentMp3)
    Write-Host "Created $soundPath"
}

if (-not (Test-Path $videoPath)) {
    # Minimal MP4 container header bytes
    $dummyMp4 = [byte[]](0x00, 0x00, 0x00, 0x20, 0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D, 0x00, 0x00, 0x02, 0x00)
    [System.IO.File]::WriteAllBytes($videoPath, $dummyMp4)
    Write-Host "Created $videoPath"
}
