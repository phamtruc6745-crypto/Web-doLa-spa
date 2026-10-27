$baseUrl = 'https://duongnt1998.github.io/WebDesign_UTC2/'
$files = @(
    'index.html',
    'shop-grid.html',
    'shop-details.html',
    'shoping-cart.html',
    'checkout.html',
    'blog.html',
    'blog-details.html',
    'contact.html',
    'css/bootstrap.min.css',
    'css/font-awesome.min.css',
    'css/elegant-icons.css',
    'css/nice-select.css',
    'css/jquery-ui.min.css',
    'css/owl.carousel.min.css',
    'css/slicknav.min.css',
    'css/style.css',
    'js/jquery-3.3.1.min.js',
    'js/bootstrap.min.js',
    'js/jquery.nice-select.min.js',
    'js/jquery-ui.min.js',
    'js/jquery.slicknav.js',
    'js/mixitup.min.js',
    'js/owl.carousel.min.js',
    'js/main.js'
)

foreach ($f in $files) {
    try {
        $u = $baseUrl + $f
        $resp = Invoke-WebRequest -Uri $u -Method Head -UseBasicParsing
        Write-Host "Found ($($resp.StatusCode)): $f"
    } catch {
        Write-Host "Missing: $f"
    }
}
