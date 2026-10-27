$files = @(
    'index.html',
    'shop-grid.html',
    'shop-details.html',
    'shoping-cart.html',
    'checkout.html',
    'blog.html',
    'blog-details.html',
    'contact.html'
)

function Replace-All($text) {
    # CSS and JS links to Styles and Scripts folders as per PDF
    $text = $text.Replace('href="css/', 'href="Styles/')
    $text = $text.Replace('src="js/', 'src="Scripts/')
    $text = $text.Replace('src="img/', 'src="Images/')
    $text = $text.Replace('data-setbg="img/', 'data-setbg="Images/')

    # Branding & Header
    $text = $text.Replace('Ogani | Template', 'Dola Spa & Cosmetics | Mỹ Phẩm & Spa Trị Liệu')
    $text = $text.Replace('Ogani', 'Dola Spa')
    $text = $text.Replace('ORGANIC', 'DOLA SPA')
    $text = $text.Replace('hello@colorlib.com', 'cskh@dolaspa.vn')
    $text = $text.Replace('Free Shipping for all Order of $99', 'Miễn phí giao hàng toàn quốc từ $50')
    $text = $text.Replace('English', 'Tiếng Việt')
    $text = $text.Replace('Login', 'Đăng nhập')
    $text = $text.Replace('+65 11.188.888', '1900 6750')
    $text = $text.Replace('support 24/7 time', 'Hỗ trợ 24/7')

    # Menu
    $text = $text.Replace('>Home<', '>Trang Chủ<')
    $text = $text.Replace('>Shop<', '>Cửa Hàng<')
    $text = $text.Replace('>Pages<', '>Trang<')
    $text = $text.Replace('>Blog<', '>Cẩm Nang Spa<')
    $text = $text.Replace('>Contact<', '>Liên Hệ<')
    $text = $text.Replace('>Shop Details<', '>Chi Tiết Sản Phẩm<')
    $text = $text.Replace('>Shoping Cart<', '>Giỏ Hàng<')
    $text = $text.Replace('>Checkout<', '>Thanh Toán<')
    $text = $text.Replace('>Blog Details<', '>Chi Tiết Bài Viết<')

    # Categories / Departments
    $text = $text.Replace('All departments', 'Danh mục mỹ phẩm')
    $text = $text.Replace('Department', 'Danh mục sản phẩm')
    $text = $text.Replace('Fresh Meat', 'Chăm Sóc Da Mặt')
    $text = $text.Replace('Vegetables', 'Tẩy Tế Bào Chết')
    $text = $text.Replace('Fruit & Nut Gifts', 'Serum & Tinh Chất')
    $text = $text.Replace('Fresh Berries', 'Kem Dưỡng Ẩm')
    $text = $text.Replace('Ocean Foods', 'Chống Nắng Phổ Rộng')
    $text = $text.Replace('Butter & Eggs', 'Mặt Nạ Thảo Dược')
    $text = $text.Replace('Fastfood', 'Nước Tẩy Trang')
    $text = $text.Replace('Fresh Onion', 'Son Dưỡng Tự Nhiên')
    $text = $text.Replace('Papayaya & Crisps', 'Tinh Dầu Trị Liệu')
    $text = $text.Replace('Oatmeal', 'Combo Chăm Sóc Da')
    $text = $text.Replace('Fresh Bananas', 'Dưỡng Môi & Mi')

    # Hero Banner
    $text = $text.Replace('FRUIT FRESH', 'MỸ PHẨM THUẦN CHAY')
    $text = $text.Replace('Vegetable <br />100% Organic', 'Dola Spa <br />Mỹ Phẩm Thiên Nhiên')
    $text = $text.Replace('Free Pickup and Delivery Available', 'Chiết xuất 100% thảo mộc hữu cơ cho làn da căng bóng mướt mịn')
    $text = $text.Replace('SHOP NOW', 'MUA SẮM NGAY')
    $text = $text.Replace('What do yo u need?', 'Bạn đang tìm mỹ phẩm gì?')
    $text = $text.Replace('SEARCH', 'TÌM KIẾM')

    # Featured Products
    $text = $text.Replace('Featured Product', 'Sản phẩm nổi bật')
    $text = $text.Replace('>All<', '>Tất Cả<')
    $text = $text.Replace('>Oranges<', '>Dưỡng Da<')

    # Shop Grid (Screenshot matching!)
    $text = $text.Replace('Price', 'Khoảng giá')
    $text = $text.Replace('Colors', 'Tone da / Loại da')
    $text = $text.Replace('Popular Size', 'Dung tích')
    $text = $text.Replace('Products found', 'Sản phẩm')
    $text = $text.Replace('Sort By', 'Sắp xếp theo')
    $text = $text.Replace('Default', 'Mặc định')
    $text = $text.Replace('Dried Fruit', 'Chăm sóc da tự nhiên')

    # Products names
    $text = $text.Replace('Crab Pool Security', 'Tẩy Tế Bào Chết Cà Phê Cúc La Mã')
    $text = $text.Replace('Mixed Fruitss', 'Combo Dưỡng Trắng Hồng Trà Xanh')
    $text = $text.Replace('Raisin’n’nuts', 'Serum Cấp Nước Phục Hồi B5 & HA')
    $text = $text.Replace('Fresh Fruit', 'Nước Tẩy Trang Dịu Nhẹ Green Tea')

    # Cart & Checkout
    $text = $text.Replace('Shopping Cart', 'Giỏ Hàng')
    $text = $text.Replace('Cart Total', 'Tổng Tiền Giỏ Hàng')
    $text = $text.Replace('Subtotal', 'Tạm tính')
    $text = $text.Replace('Total', 'Tổng cộng')
    $text = $text.Replace('CONTINUE SHOPPING', 'TIẾP TỤC MUA SẮM')
    $text = $text.Replace('UPDATE CART', 'CẬP NHẬT GIỎ HÀNG')
    $text = $text.Replace('APPLY COUPON', 'ÁP DỤNG')
    $text = $text.Replace('Apply Coupon', 'Áp Dụng')
    $text = $text.Replace('PROCEED TO CHECKOUT', 'TIẾN HÀNH THANH TOÁN')
    $text = $text.Replace('Billing Details', 'Thông Tin Đặt Hàng')
    $text = $text.Replace('First Name', 'Họ')
    $text = $text.Replace('Last Name', 'Tên')
    $text = $text.Replace('Street Address', 'Địa chỉ giao hàng')
    $text = $text.Replace('Postcode / ZIP', 'Mã bưu chính')
    $text = $text.Replace('Order notes', 'Ghi chú cho đơn hàng')
    $text = $text.Replace('Your Order', 'Đơn Hàng Của Bạn')
    $text = $text.Replace('PLACE ORDER', 'XÁC NHẬN ĐẶT HÀNG')

    # Blog & News
    $text = $text.Replace('From The Blog', 'Cẩm nang làm đẹp')
    $text = $text.Replace('Latest Products', 'Sản phẩm mới nhất')
    $text = $text.Replace('Top Rated Products', 'Đánh giá cao')
    $text = $text.Replace('Review Products', 'Bán chạy nhất')
    $text = $text.Replace('Cooking tips make cooking simple', 'Bí quyết cấp ẩm sâu cho làn da căng bóng mướt mịn chuẩn Hàn')
    $text = $text.Replace('6 ways to prepare breakfast for 30', 'Routine 4 bước chăm sóc da mụn nhạy cảm phục hồi tức thì')
    $text = $text.Replace('Visit the clean farm in the US', 'Tinh hoa làm đẹp từ quả ô liu và thảo mộc tự nhiên')

    # Contact & Footer
    $text = $text.Replace('Contact Us', 'Liên Hệ')
    $text = $text.Replace('Leave Message', 'Gửi Tin Nhắn')
    $text = $text.Replace('Your name', 'Họ tên của bạn')
    $text = $text.Replace('Your Email', 'Email của bạn')
    $text = $text.Replace('Your message', 'Nội dung tin nhắn...')
    $text = $text.Replace('SEND MESSAGE', 'GỬI TIN NHẮN')
    $text = $text.Replace('Open time', 'Giờ mở cửa')
    $text = $text.Replace('Address: 60-49 Road 11378 New York', 'Địa chỉ: 128 Nguyễn Đình Chiểu, Quận 3, TP.HCM')
    $text = $text.Replace('Useful Links', 'Liên Kết Nhanh')
    $text = $text.Replace('About Us', 'Về Dola Spa')
    $text = $text.Replace('About Our Shop', 'Về Mỹ Phẩm')
    $text = $text.Replace('Secure Shopping', 'Mua Sắm An Toàn')
    $text = $text.Replace('Delivery infomation', 'Giao Hàng & Đổi Trả')
    $text = $text.Replace('Privacy Policy', 'Chính Sách Bảo Mật')
    $text = $text.Replace('Our Sitemap', 'Sơ Đồ Trang')
    $text = $text.Replace('Who We Are', 'Đội Ngũ Chuyên Viên')
    $text = $text.Replace('Our Services', 'Dịch Vụ Spa')
    $text = $text.Replace('Testimonials', 'Cảm Nhận Khách Hàng')
    $text = $text.Replace('Join Our Newsletter Now', 'Đăng Ký Nhận Bản Tin Ưu Đãi')
    $text = $text.Replace('Get E-mail updates about our latest shop and special offers.', 'Nhận voucher giảm giá 20% cho đơn hàng mỹ phẩm đầu tiên.')
    $text = $text.Replace('Subscribe', 'Đăng Ký')
    $text = $text.Replace('Enter your mail', 'Nhập email của bạn...')

    return $text
}

foreach ($f in $files) {
    $rawPath = "raw_" + $f
    if (Test-Path $rawPath) {
        $content = Get-Content $rawPath -Raw -Encoding UTF8
        $content = Replace-All($content)
        [System.IO.File]::WriteAllText($f, $content, [System.Text.Encoding]::UTF8)
        Write-Host "Created $f"
    }
}
Write-Host "ALL 8 HTML PAGES GENERATED SUCCESSFULLY!"
