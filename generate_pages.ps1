# Helper script to localize and format all Organi template files into Dola Spa & Cosmetics
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

# Common replacements dictionary
$replacements = @{
    # Head titles & branding
    "Ogani \| Template" = "Dola Spa & Cosmetics | Mỹ Phẩm & Spa Trị Liệu Thiên Nhiên"
    "Ogani" = "Dola Spa"
    "ORGANIC" = "DOLA SPA"
    "hello@colorlib.com" = "cskh@dolaspa.vn"
    "Free Shipping for all Order of \$99" = "Miễn phí giao hàng cho đơn từ $50"
    "English" = "Tiếng Việt"
    "Spanish" = "English"
    "Login" = "Đăng nhập"

    # Navigation menu
    ">Home<" = ">Trang Chủ<"
    ">Shop<" = ">Cửa Hàng<"
    ">Pages<" = ">Trang<"
    ">Blog<" = ">Cẩm Nang Spa<"
    ">Contact<" = ">Liên Hệ<"
    ">Shop Details<" = ">Chi Tiết Sản Phẩm<"
    ">Shoping Cart<" = ">Giỏ Hàng<"
    ">Checkout<" = ">Thanh Toán<"
    ">Blog Details<" = ">Chi Tiết Bài Viết<"

    # Category menu
    "All departments" = "Danh mục sản phẩm"
    "Fresh Meat" = "Chăm Sóc Da Mặt"
    "Vegetables" = "Tẩy Tế Bào Chết"
    "Fruit & Nut Gifts" = "Serum & Tinh Chất"
    "Fresh Berries" = "Kem Dưỡng Ẩm"
    "Ocean Foods" = "Chống Nắng Phổ Rộng"
    "Butter & Eggs" = "Mặt Nạ Thảo Dược"
    "Fastfood" = "Nước Tẩy Trang"
    "Fresh Onion" = "Son Môi Tự Nhiên"
    "Papayaya & Crisps" = "Tinh Dầu Trị Liệu"
    "Oatmeal" = "Combo Tiết Kiệm"
    "Fresh Bananas" = "Dưỡng Môi & Mắt"

    # Hero Banner
    "FRUIT FRESH" = "MỸ PHẨM THUẦN CHAY"
    "Vegetable <br />100% Organic" = "Dola Spa <br />Mỹ Phẩm Thiên Nhiên"
    "Free Pickup and Delivery Available" = "Chiết xuất 100% thảo mộc tự nhiên cho làn da mướt mịn"
    "SHOP NOW" = "MUA SẮM NGAY"
    "What do yo u need\?" = "Bạn đang tìm mỹ phẩm gì?"
    "SEARCH" = "TÌM KIẾM"
    "support 24/7 time" = "Hỗ trợ 24/7"

    # Featured Section
    "Featured Product" = "Sản phẩm nổi bật"
    ">All<" = ">Tất Cả<"
    ">Oranges<" = ">Dưỡng Da<"
    ">Fresh Meat<" = ">Làm Sạch<"
    ">Vegetables<" = ">Serum & Kem<"
    ">Fastfood<" = ">Son & Makeup<"

    # Shop Grid Section (Screenshot matching!)
    "Department" = "Danh mục sản phẩm"
    "Price" = "Khoảng giá"
    "Colors" = "Tone da / Màu sắc"
    "White" = "Trắng sáng"
    "Gray" = "Da khô"
    "Red" = "Hồng hào"
    "Black" = "Mụn cám"
    "Blue" = "Nhạy cảm"
    "Green" = "Da dầu"
    "Popular Size" = "Dung tích phổ biến"
    "Large" = "200ml"
    "Medium" = "100ml"
    "Small" = "50ml"
    "Tiny" = "30ml"
    "Products found" = "Sản phẩm tìm thấy"
    "Default" = "Mặc định"
    "Sort By" = "Sắp xếp theo"
    "Dried Fruit" = "Mỹ phẩm thiên nhiên"

    # Products names
    "Crab Pool Security" = "Tẩy Tế Bào Chết Cà Phê Cúc La Mã"
    "Mixed Fruitss" = "Combo Dưỡng Da Trắng Mịn Trà Xanh"
    "Raisin’n’nuts" = "Serum Cấp Nước Phục Hồi B5 & HA"
    "Fresh Fruit" = "Nước Tẩy Trang Dịu Nhẹ Green Tea"
    "Fresh Meat" = "Kem Chống Nắng Phổ Rộng SPF50+"
    "Organic Bananas" = "Mặt Nạ Đất Sét Tro Núi Lửa"
    "Watermelon" = "Son Dưỡng Môi Màu Đỏ Cam Tự Nhiên"
    "Drink Fruits" = "Tinh Dầu Tràm Trà Kháng Khuẩn"

    # Latest Products / Blog
    "From The Blog" = "Cẩm nang làm đẹp"
    "Latest Products" = "Sản phẩm mới"
    "Top Rated Products" = "Đánh giá cao"
    "Review Products" = "Bán chạy nhất"
    "Cooking tips make cooking simple" = "Bí quyết dưỡng ẩm cho làn da căng bóng mướt mịn"
    "6 ways to prepare breakfast for 30" = "Routine 4 bước chăm sóc da mụn nhạy cảm tại nhà"
    "Visit the clean farm in the US" = "Công dụng thần kỳ của quả ô liu trong làm đẹp"

    # Cart & Checkout
    "Shopping Cart" = "Giỏ Hàng"
    "Cart Total" = "Tổng Tiền Giỏ Hàng"
    "Subtotal" = "Tạm tính"
    "Total" = "Tổng cộng"
    "CONTINUE SHOPPING" = "TIẾP TỤC MUA SẮM"
    "UPDATE CART" = "CẬP NHẬT GIỎ HÀNG"
    "Apply Coupon" = "ÁP DỤNG MÃ"
    "APPLY COUPON" = "ÁP DỤNG"
    "PROCEED TO CHECKOUT" = "TIẾN HÀNH THANH TOÁN"
    "Billing Details" = "Thông Tin Thanh Toán"
    "First Name" = "Họ và tên đệm"
    "Last Name" = "Tên"
    "Country" = "Quốc gia"
    "Street Address" = "Địa chỉ nhận hàng"
    "Postcode / ZIP" = "Mã bưu điện"
    "Phone" = "Số điện thoại"
    "Email" = "Địa chỉ Email"
    "Order notes" = "Ghi chú đơn hàng"
    "Your Order" = "Đơn Hàng Của Bạn"
    "PLACE ORDER" = "ĐẶT HÀNG NGAY"

    # Contact & Footer
    "Contact Us" = "Liên Hệ Với Chúng Tôi"
    "Leave Message" = "Gửi Tin Nhắn Cho Dola Spa"
    "Your name" = "Họ tên của bạn"
    "Your Email" = "Email liên hệ"
    "Your message" = "Nội dung cần tư vấn..."
    "SEND MESSAGE" = "GỬI TIN NHẮN"
    "Open time" = "Giờ mở cửa"
    "Address: 60-49 Road 11378 New York" = "Địa chỉ: 128 Nguyễn Đình Chiểu, Quận 3, TP. Hồ Chí Minh"
    "Phone: \+65 11.188.888" = "Hotline: 1900 6750"
    "Email: hello@colorlib.com" = "Email: cskh@dolaspa.vn"
    "Useful Links" = "Liên Kết Hữu Ích"
    "About Us" = "Về Dola Spa"
    "About Our Shop" = "Về Sản Phẩm"
    "Secure Shopping" = "Mua Sắm An Toàn"
    "Delivery infomation" = "Chính Sách Giao Hàng"
    "Privacy Policy" = "Chính Sách Bảo Mật"
    "Our Sitemap" = "Sơ Đồ Website"
    "Who We Are" = "Giới Thiệu"
    "Our Services" = "Dịch Vụ Spa"
    "Projects" = "Liệu Trình Chuyên Sâu"
    "Testimonials" = "Đánh Giá Khách Hàng"
    "Innovation" = "Công Nghệ Mới"
    "Join Our Newsletter Now" = "Đăng Ký Nhận Bản Tin Ưu Đãi"
    "Get E-mail updates about our latest shop and special offers." = "Nhận ngay voucher giảm giá 20% cho đơn hàng mỹ phẩm đầu tiên."
    "Subscribe" = "Đăng Ký"
    "Enter your mail" = "Nhập email của bạn..."
}

foreach ($f in $files) {
    $rawPath = "raw_" + $f
    if (Test-Path $rawPath) {
        $content = Get-Content $rawPath -Raw -Encoding UTF8

        # 1. Update CSS references to Styles/
        $content = $content -replace 'href="css/', 'href="Styles/'
        # 2. Update JS references to Scripts/
        $content = $content -replace 'src="js/', 'src="Scripts/'
        # 3. Update img references to Images/
        $content = $content -replace 'src="img/', 'src="Images/'
        $content = $content -replace 'data-setbg="img/', 'data-setbg="Images/'

        # 4. Apply vocabulary & translations
        foreach ($k in $replacements.Keys) {
            $val = $replacements[$k]
            $content = $content -replace $k, $val
        }

        # Write out UTF-8 with BOM or UTF-8 clean
        [System.IO.File]::WriteAllText($f, $content, [System.Text.Encoding]::UTF8)
        Write-Host "Created $f"
    }
}
Write-Host "Successfully generated all 8 pages matching Organi for Dola Spa!"
