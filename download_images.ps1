$baseUrl = 'https://duongnt1998.github.io/WebDesign_UTC2/'
$imgList = Get-Content 'list_all_images.ps1' -Raw

$imgs = @(
    'img/banner/banner-1.jpg',
    'img/banner/banner-2.jpg',
    'img/blog/blog-1.jpg',
    'img/blog/blog-2.jpg',
    'img/blog/blog-3.jpg',
    'img/blog/blog-4.jpg',
    'img/blog/blog-6.jpg',
    'img/blog/details/details-author.jpg',
    'img/blog/details/details-hero.jpg',
    'img/blog/details/details-pic.jpg',
    'img/blog/sidebar/sr-1.jpg',
    'img/blog/sidebar/sr-2.jpg',
    'img/blog/sidebar/sr-3.jpg',
    'img/breadcrumb.jpg',
    'img/cart/cart-1.jpg',
    'img/cart/cart-2.jpg',
    'img/cart/cart-3.jpg',
    'img/categories/cat-1.jpg',
    'img/categories/cat-2.jpg',
    'img/categories/cat-3.jpg',
    'img/categories/cat-4.jpg',
    'img/categories/cat-5.jpg',
    'img/featured/feature-1.jpg',
    'img/featured/feature-2.jpg',
    'img/featured/feature-3.jpg',
    'img/featured/feature-4.jpg',
    'img/featured/feature-5.jpg',
    'img/featured/feature-6.jpg',
    'img/featured/feature-7.jpg',
    'img/featured/feature-8.jpg',
    'img/hero/banner.jpg',
    'img/language.png',
    'img/latest-product/lp-1.jpg',
    'img/latest-product/lp-2.jpg',
    'img/latest-product/lp-3.jpg',
    'img/logo.png',
    'img/payment-item.png',
    'img/product/details/product-details-1.jpg',
    'img/product/details/thumb-1.jpg',
    'img/product/details/thumb-2.jpg',
    'img/product/details/thumb-3.jpg',
    'img/product/details/thumb-4.jpg',
    'img/product/discount/pd-1.jpg',
    'img/product/discount/pd-2.jpg',
    'img/product/discount/pd-3.jpg',
    'img/product/discount/pd-4.jpg',
    'img/product/discount/pd-5.jpg',
    'img/product/discount/pd-6.jpg',
    'img/product/product-1.jpg',
    'img/product/product-10.jpg',
    'img/product/product-11.jpg',
    'img/product/product-12.jpg',
    'img/product/product-2.jpg',
    'img/product/product-3.jpg',
    'img/product/product-4.jpg',
    'img/product/product-5.jpg',
    'img/product/product-6.jpg',
    'img/product/product-7.jpg',
    'img/product/product-8.jpg',
    'img/product/product-9.jpg'
)

foreach ($item in $imgs) {
    $dirImg = Split-Path $item -Parent
    $dirImages = $dirImg -replace '^img', 'Images'
    
    if (-not (Test-Path $dirImg)) { New-Item -ItemType Directory -Force -Path $dirImg | Out-Null }
    if (-not (Test-Path $dirImages)) { New-Item -ItemType Directory -Force -Path $dirImages | Out-Null }
    
    $targetFileImg = $item
    $targetFileImages = $item -replace '^img', 'Images'
    
    try {
        Invoke-WebRequest -Uri ($baseUrl + $item) -OutFile $targetFileImg -UseBasicParsing
        Copy-Item $targetFileImg $targetFileImages -Force
        Write-Host "Downloaded: $item"
    } catch {
        Write-Host "Failed: $item"
    }
}
Write-Host "Done downloading template images!"
