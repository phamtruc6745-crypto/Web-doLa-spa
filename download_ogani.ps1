$baseUrl = 'https://duongnt1998.github.io/WebDesign_UTC2/'

# Create folders per PDF specification
New-Item -ItemType Directory -Force -Path 'Styles' | Out-Null
New-Item -ItemType Directory -Force -Path 'Scripts' | Out-Null
New-Item -ItemType Directory -Force -Path 'Images' | Out-Null
New-Item -ItemType Directory -Force -Path 'Sounds' | Out-Null
New-Item -ItemType Directory -Force -Path 'Videos' | Out-Null
New-Item -ItemType Directory -Force -Path 'fonts' | Out-Null

$htmlFiles = @(
    'index.html',
    'shop-grid.html',
    'shop-details.html',
    'shoping-cart.html',
    'checkout.html',
    'blog.html',
    'blog-details.html',
    'contact.html'
)

$cssFiles = @(
    'bootstrap.min.css',
    'font-awesome.min.css',
    'elegant-icons.css',
    'nice-select.css',
    'jquery-ui.min.css',
    'owl.carousel.min.css',
    'slicknav.min.css',
    'style.css'
)

$jsFiles = @(
    'jquery-3.3.1.min.js',
    'bootstrap.min.js',
    'jquery.nice-select.min.js',
    'jquery-ui.min.js',
    'jquery.slicknav.js',
    'mixitup.min.js',
    'owl.carousel.min.js',
    'main.js'
)

Write-Host "Downloading HTML..."
foreach ($f in $htmlFiles) {
    Invoke-WebRequest -Uri ($baseUrl + $f) -OutFile ("raw_" + $f) -UseBasicParsing
    Write-Host "Downloaded raw_$f"
}

Write-Host "Downloading CSS to Styles/ and css/..."
New-Item -ItemType Directory -Force -Path 'css' | Out-Null
foreach ($f in $cssFiles) {
    Invoke-WebRequest -Uri ($baseUrl + 'css/' + $f) -OutFile ("Styles/" + $f) -UseBasicParsing
    Copy-Item ("Styles/" + $f) ("css/" + $f) -Force
    Write-Host "Downloaded $f"
}

Write-Host "Downloading JS to Scripts/ and js/..."
New-Item -ItemType Directory -Force -Path 'js' | Out-Null
foreach ($f in $jsFiles) {
    Invoke-WebRequest -Uri ($baseUrl + 'js/' + $f) -OutFile ("Scripts/" + $f) -UseBasicParsing
    Copy-Item ("Scripts/" + $f) ("js/" + $f) -Force
    Write-Host "Downloaded $f"
}

Write-Host "Downloading Fonts..."
$fontFiles = @(
    'ElegantIcons.eot',
    'ElegantIcons.svg',
    'ElegantIcons.ttf',
    'ElegantIcons.woff',
    'fontawesome-webfont.eot',
    'fontawesome-webfont.svg',
    'fontawesome-webfont.ttf',
    'fontawesome-webfont.woff',
    'fontawesome-webfont.woff2',
    'FontAwesome.otf'
)

foreach ($f in $fontFiles) {
    try {
        Invoke-WebRequest -Uri ($baseUrl + 'fonts/' + $f) -OutFile ("fonts/" + $f) -UseBasicParsing
        Write-Host "Downloaded font $f"
    } catch {
        Write-Host "Font not found: $f"
    }
}
Write-Host "DONE DOWNLOADING ALL CORE ASSETS!"
