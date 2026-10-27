Add-Type -AssemblyName System.Drawing

$width = 240
$height = 80
$bitmap = New-Object System.Drawing.Bitmap $width, $height
$g = [System.Drawing.Graphics]::FromImage($bitmap)
$g.SmoothingMode = [System.Drawing.Drawing2D.SmoothingMode]::AntiAlias
$g.TextRenderingHint = [System.Drawing.Text.TextRenderingHint]::AntiAliasGridFit
$g.Clear([System.Drawing.Color]::Transparent)

# Fonts
$fontMain = New-Object System.Drawing.Font ("Georgia", [single]26, [System.Drawing.FontStyle]::Bold)
$fontSub = New-Object System.Drawing.Font ("Arial", [single]8.5, [System.Drawing.FontStyle]::Bold)

# Brushes
$navyBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(24, 44, 71))
$goldBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(197, 155, 39))
$subBrush = New-Object System.Drawing.SolidBrush ([System.Drawing.Color]::FromArgb(120, 135, 155))

# Draw text
$g.DrawString("Dola", $fontMain, $navyBrush, 6, 10)
$g.DrawString("Spa", $fontMain, $goldBrush, 98, 10)
$g.DrawString("ORGANIC & COSMETICS", $fontSub, $subBrush, 8, 48)

$bitmap.Save("img/logo.png", [System.Drawing.Imaging.ImageFormat]::Png)
$bitmap.Save("Images/logo.png", [System.Drawing.Imaging.ImageFormat]::Png)
$g.Dispose()
$bitmap.Dispose()
Write-Host "SUCCESS: Generated img/logo.png and Images/logo.png"
