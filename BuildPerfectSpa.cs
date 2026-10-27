using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class BuildPerfectSpa {
    static void Main() {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== REBUILDING 100% PERFECT DOLA SPA & COSMETICS WEBSITE ===");

        BuildContact();
        BuildShopGrid();
        BuildShopDetails();
        BuildCart();
        BuildCheckout();
        BuildBlog();
        BuildBlogDetails();
        BuildIndex();

        Console.WriteLine("=== ALL 8 PAGES REBUILT WITH 100% PRECISION ===");
    }

    static string ReadRaw(string filename) {
        return File.ReadAllText(filename, Encoding.UTF8);
    }

    static void Save(string filename, string content) {
        File.WriteAllText(filename, content, new UTF8Encoding(false));
        Console.WriteLine("Generated: " + filename + " (" + content.Length + " chars)");
    }

    static string ApplyBaseTranslations(string html, string activeMenu) {
        // Replace asset folder paths
        html = html.Replace("href=\"css/", "href=\"Styles/");
        html = html.Replace("src=\"js/", "src=\"Scripts/");
        html = html.Replace("src=\"img/", "src=\"Images/");
        html = html.Replace("data-setbg=\"img/", "data-setbg=\"Images/");

        // Brand & Title
        html = html.Replace("<title>Ogani | Template</title>", "<title>Dola Spa & Cosmetics | Mỹ Phẩm & Spa Trị Liệu Thiên Nhiên</title>");
        html = html.Replace("content=\"Ogani Template\"", "content=\"Dola Spa & Cosmetics Template\"");
        html = html.Replace("content=\"Ogani, unica, creative, html\"", "content=\"Dola Spa, my pham thuan chay, spa tri lieu, cham soc da\"");

        // Top bar
        html = html.Replace("hello@colorlib.com", "cskh@dolaspa.vn");
        html = html.Replace("Free Shipping for all Order of $99", "Miễn phí giao hàng cho đơn từ $50");
        html = html.Replace("<div>English</div>", "<div>Tiếng Việt</div>");
        html = html.Replace("<li><a href=\"#\">Spanis</a></li>", "<li><a href=\"#\">English</a></li>");
        html = html.Replace("<li><a href=\"#\">English</a></li>", "<li><a href=\"#\">Tiếng Việt</a></li>");
        html = html.Replace("<i class=\"fa fa-user\"></i> Login", "<i class=\"fa fa-user\"></i> Đăng nhập");
        html = html.Replace("item: <span>$150.00</span>", "món: <span>$110.00</span>");

        // Header Cart link
        html = html.Replace("<li><a href=\"#\"><i class=\"fa fa-shopping-bag\"></i> <span>3</span></a></li>",
                            "<li><a href=\"./shoping-cart.html\"><i class=\"fa fa-shopping-bag\"></i> <span>3</span></a></li>");

        // Menu navigation
        string navTemplate = @"
                    <nav class=""header__menu"">
                        <ul>
                            <li class=""{INDEX_ACTIVE}""><a href=""./index.html"">Trang Chủ</a></li>
                            <li class=""{SHOP_ACTIVE}""><a href=""./shop-grid.html"">Cửa Hàng</a></li>
                            <li class=""{PAGES_ACTIVE}""><a href=""#"">Trang</a>
                                <ul class=""header__menu__dropdown"">
                                    <li><a href=""./shop-details.html"">Chi Tiết Sản Phẩm</a></li>
                                    <li><a href=""./shoping-cart.html"">Giỏ Hàng</a></li>
                                    <li><a href=""./checkout.html"">Thanh Toán</a></li>
                                    <li><a href=""./blog-details.html"">Chi Tiết Bài Viết</a></li>
                                </ul>
                            </li>
                            <li class=""{BLOG_ACTIVE}""><a href=""./blog.html"">Cẩm Nang Spa</a></li>
                            <li class=""{CONTACT_ACTIVE}""><a href=""./contact.html"">Liên Hệ</a></li>
                        </ul>
                    </nav>";

        navTemplate = navTemplate.Replace("{INDEX_ACTIVE}", activeMenu == "index" ? "active" : "");
        navTemplate = navTemplate.Replace("{SHOP_ACTIVE}", activeMenu == "shop" ? "active" : "");
        navTemplate = navTemplate.Replace("{PAGES_ACTIVE}", (activeMenu == "shop-details" || activeMenu == "cart" || activeMenu == "checkout" || activeMenu == "blog-details") ? "active" : "");
        navTemplate = navTemplate.Replace("{BLOG_ACTIVE}", activeMenu == "blog" ? "active" : "");
        navTemplate = navTemplate.Replace("{CONTACT_ACTIVE}", activeMenu == "contact" ? "active" : "");

        html = Regex.Replace(html, @"<nav class=""header__menu"">[\s\S]*?</nav>", navTemplate);

        // Mobile Menu
        string mobileNavTemplate = @"
        <nav class=""humberger__menu__nav mobile-menu"">
            <ul>
                <li class=""{INDEX_ACTIVE}""><a href=""./index.html"">Trang Chủ</a></li>
                <li class=""{SHOP_ACTIVE}""><a href=""./shop-grid.html"">Cửa Hàng</a></li>
                <li class=""{PAGES_ACTIVE}""><a href=""#"">Trang</a>
                    <ul class=""header__menu__dropdown"">
                        <li><a href=""./shop-details.html"">Chi Tiết Sản Phẩm</a></li>
                        <li><a href=""./shoping-cart.html"">Giỏ Hàng</a></li>
                        <li><a href=""./checkout.html"">Thanh Toán</a></li>
                        <li><a href=""./blog-details.html"">Chi Tiết Bài Viết</a></li>
                    </ul>
                </li>
                <li class=""{BLOG_ACTIVE}""><a href=""./blog.html"">Cẩm Nang Spa</a></li>
                <li class=""{CONTACT_ACTIVE}""><a href=""./contact.html"">Liên Hệ</a></li>
            </ul>
        </nav>";
        mobileNavTemplate = mobileNavTemplate.Replace("{INDEX_ACTIVE}", activeMenu == "index" ? "active" : "");
        mobileNavTemplate = mobileNavTemplate.Replace("{SHOP_ACTIVE}", activeMenu == "shop" ? "active" : "");
        mobileNavTemplate = mobileNavTemplate.Replace("{PAGES_ACTIVE}", (activeMenu == "shop-details" || activeMenu == "cart" || activeMenu == "checkout" || activeMenu == "blog-details") ? "active" : "");
        mobileNavTemplate = mobileNavTemplate.Replace("{BLOG_ACTIVE}", activeMenu == "blog" ? "active" : "");
        mobileNavTemplate = mobileNavTemplate.Replace("{CONTACT_ACTIVE}", activeMenu == "contact" ? "active" : "");
        html = Regex.Replace(html, @"<nav class=""humberger__menu__nav mobile-menu"">[\s\S]*?</nav>", mobileNavTemplate);

        // Hero Search Bar & Hotline
        html = html.Replace("All Categories", "Tất cả danh mục");
        html = html.Replace("What do yo u need?", "Bạn đang tìm mỹ phẩm gì?");
        html = html.Replace(">SEARCH<", ">TÌM KIẾM<");
        html = html.Replace("+65 11.188.888", "1900 6750");
        html = html.Replace("support 24/7 time", "Hỗ trợ 24/7");

        // Hero Categories
        string heroCategories = @"
                    <div class=""hero__categories"">
                        <div class=""hero__categories__all"">
                            <i class=""fa fa-bars""></i>
                            <span>Danh mục mỹ phẩm</span>
                        </div>
                        <ul>
                            <li><a href=""./shop-grid.html"">Chăm Sóc Da Mặt</a></li>
                            <li><a href=""./shop-grid.html"">Tẩy Tế Bào Chết</a></li>
                            <li><a href=""./shop-grid.html"">Serum & Tinh Chất</a></li>
                            <li><a href=""./shop-grid.html"">Kem Dưỡng Ẩm Chuyên Sâu</a></li>
                            <li><a href=""./shop-grid.html"">Chống Nắng Phổ Rộng</a></li>
                            <li><a href=""./shop-grid.html"">Mặt Nạ Thảo Dược</a></li>
                            <li><a href=""./shop-grid.html"">Nước Tẩy Trang & Làm Sạch</a></li>
                            <li><a href=""./shop-grid.html"">Son Dưỡng & Makeup</a></li>
                            <li><a href=""./shop-grid.html"">Tinh Dầu Trị Liệu Spa</a></li>
                            <li><a href=""./shop-grid.html"">Combo Tiết Kiệm</a></li>
                            <li><a href=""./shop-grid.html"">Dưỡng Môi & Mi Tự Nhiên</a></li>
                        </ul>
                    </div>";
        html = Regex.Replace(html, @"<div class=""hero__categories"">[\s\S]*?</div>\s*</div>", heroCategories + "\n</div>");

        // Footer
        html = html.Replace("Address: 60-49 Road 11378 New York", "Địa chỉ: 128 Nguyễn Đình Chiểu, Quận 3, TP.HCM");
        html = html.Replace("Useful Links", "Liên Kết Hữu Ích");
        html = html.Replace("About Us", "Về Dola Spa");
        html = html.Replace("About Our Shop", "Về Mỹ Phẩm");
        html = html.Replace("Secure Shopping", "Mua Sắm An Toàn");
        html = html.Replace("Delivery infomation", "Chính Sách Giao Hàng");
        html = html.Replace("Privacy Policy", "Chính Sách Bảo Mật");
        html = html.Replace("Our Sitemap", "Sơ Đồ Trang");
        html = html.Replace("Who We Are", "Đội Ngũ Chuyên Viên");
        html = html.Replace("Our Services", "Dịch Vụ Spa");
        html = html.Replace("Projects", "Liệu Trình Chuyên Sâu");
        html = html.Replace("Contact", "Liên Hệ");
        html = html.Replace("Innovation", "Công Nghệ Mới");
        html = html.Replace("Testimonials", "Cảm Nhận Khách Hàng");
        html = html.Replace("Join Our Newsletter Now", "Đăng Ký Nhận Bản Tin Ưu Đãi");
        html = html.Replace("Get E-mail updates about our latest shop and special offers.", "Nhận ngay voucher giảm giá 20% cho đơn hàng mỹ phẩm đầu tiên.");
        html = html.Replace("Subscribe", "Đăng Ký");
        html = html.Replace("Enter your mail", "Nhập email của bạn...");

        return html;
    }

    static void BuildContact() {
        string html = ReadRaw("raw_contact.html");
        html = ApplyBaseTranslations(html, "contact");

        // Breadcrumb
        html = html.Replace("<h2>Contact Us</h2>", "<h2>Liên Hệ</h2>");
        html = html.Replace("<a href=\"./index.html\">Home</a>", "<a href=\"./index.html\">Trang Chủ</a>");
        html = html.Replace("<span>Contact Us</span>", "<span>Liên Hệ</span>");

        // Contact info boxes
        html = html.Replace("<h4>Phone</h4>", "<h4>Số điện thoại</h4>");
        html = html.Replace("<p>+01-3-8888-6868</p>", "<p>1900 6750</p>");
        html = html.Replace("<h4>Address</h4>", "<h4>Địa chỉ Spa</h4>");
        html = html.Replace("<p>60-49 Road 11378 New York</p>", "<p>128 Nguyễn Đình Chiểu, Quận 3, TP.HCM</p>");
        html = html.Replace("<h4>Open time</h4>", "<h4>Giờ mở cửa</h4>");
        html = html.Replace("<p>10:00 am to 23:00 pm</p>", "<p>08:00 am - 21:30 pm (Cả tuần)</p>");
        html = html.Replace("<h4>Email</h4>\n                        <p>hello@colorlib.com</p>", "<h4>Địa chỉ Email</h4>\n                        <p>cskh@dolaspa.vn</p>");

        // Map Widget
        string mapWidget = @"
    <div class=""map"">
        <iframe
            src=""https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3919.4975549880875!2d106.69179927570377!3d10.773147859254316!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31752f3922c06173%3A0x6b5c3284050a4176!2zMTI4IE5ndXnhu4VuIMSQw6xuaCBDaGnhu4N1LCBQaMaw4budbmcgNiwgUXXhuq1uIDMsIEjhu5MgQ2jDrSBNaW5o!5e0!3m2!1svi!2s!4v1700000000000!5m2!1svi!2s""
            height=""500"" style=""border:0;"" allowfullscreen="""" aria-hidden=""false"" tabindex=""0""></iframe>
        <div class=""map-inside"">
            <i class=""icon_pin""></i>
            <div class=""inside-widget"">
                <h4>Dola Spa TP.HCM</h4>
                <ul>
                    <li>Hotline: 1900 6750</li>
                    <li>Add: 128 Nguyễn Đình Chiểu, P. Võ Thị Sáu, Quận 3</li>
                </ul>
            </div>
        </div>
    </div>";
        html = Regex.Replace(html, @"<div class=""map"">[\s\S]*?</div>\s*<!-- Map End -->", mapWidget + "\n    <!-- Map End -->");

        // Form
        html = html.Replace("<h2>Leave Message</h2>", "<h2>Gửi Tin Nhắn Cho Dola Spa</h2>");
        html = html.Replace("placeholder=\"Your name\"", "placeholder=\"Họ và tên của bạn\"");
        html = html.Replace("placeholder=\"Your Email\"", "placeholder=\"Email của bạn\"");
        html = html.Replace("placeholder=\"Your message\"", "placeholder=\"Nội dung cần tư vấn làm đẹp hoặc đặt hẹn spa...\"");
        html = html.Replace("SEND MESSAGE", "GỬI TIN NHẮN");

        // Form submit alert
        string formScript = @"
    <script>
        document.querySelector('.contact-form form').addEventListener('submit', function(e) {
            e.preventDefault();
            alert('Cảm ơn bạn đã gửi tin nhắn! Chuyên viên Dola Spa sẽ liên hệ tư vấn trong vòng 15 phút.');
            this.reset();
        });
    </script>
</body>";
        html = html.Replace("</body>", formScript);

        Save("contact.html", html);
    }

    static void BuildShopGrid() {
        string html = ReadRaw("raw_shop-grid.html");
        html = ApplyBaseTranslations(html, "shop");

        // Breadcrumb
        html = html.Replace("<h2>Organi Shop</h2>", "<h2>Cửa Hàng Mỹ Phẩm Dola Spa</h2>");
        html = html.Replace("<a href=\"./index.html\">Home</a>", "<a href=\"./index.html\">Trang Chủ</a>");
        html = html.Replace("<span>Shop</span>", "<span>Cửa Hàng</span>");

        // Replace entire sidebar department block
        string departmentSidebar = @"
                        <div class=""sidebar__item"">
                            <h4>Danh mục sản phẩm</h4>
                            <ul>
                                <li><a href=""#"">Chăm Sóc Da Mặt (18)</a></li>
                                <li><a href=""#"">Tẩy Tế Bào Chết (12)</a></li>
                                <li><a href=""#"">Serum & Tinh Chất (25)</a></li>
                                <li><a href=""#"">Kem Dưỡng Ẩm (16)</a></li>
                                <li><a href=""#"">Chống Nắng Phổ Rộng (10)</a></li>
                                <li><a href=""#"">Mặt Nạ Thảo Dược (14)</a></li>
                                <li><a href=""#"">Nước Tẩy Trang (9)</a></li>
                                <li><a href=""#"">Son Dưỡng & Makeup (15)</a></li>
                                <li><a href=""#"">Tinh Dầu Trị Liệu (8)</a></li>
                                <li><a href=""#"">Combo Tiết Kiệm (7)</a></li>
                                <li><a href=""#"">Dưỡng Môi & Mi (6)</a></li>
                            </ul>
                        </div>";
        html = Regex.Replace(html, @"<div class=""sidebar__item"">\s*<h4>Department</h4>\s*<ul>[\s\S]*?</ul>\s*</div>", departmentSidebar);

        // Sidebar Filter Headings
        html = html.Replace("<h4>Price</h4>", "<h4>Khoảng giá</h4>");
        html = html.Replace("<h4>Colors</h4>", "<h4>Tone da / Loại da</h4>");
        html = html.Replace("White\n                                <input type=\"radio\" id=\"white\">", "Trắng sáng\n                                <input type=\"radio\" id=\"white\">");
        html = html.Replace("Gray\n                                <input type=\"radio\" id=\"gray\">", "Da mụn\n                                <input type=\"radio\" id=\"gray\">");
        html = html.Replace("Red\n                                <input type=\"radio\" id=\"red\">", "Chống lão hóa\n                                <input type=\"radio\" id=\"red\">");
        html = html.Replace("Black\n                                <input type=\"radio\" id=\"black\">", "Cấp ẩm sâu\n                                <input type=\"radio\" id=\"black\">");
        html = html.Replace("Blue\n                                <input type=\"radio\" id=\"blue\">", "Phục hồi B5\n                                <input type=\"radio\" id=\"blue\">");
        html = html.Replace("Green\n                                <input type=\"radio\" id=\"green\">", "Nâng tone\n                                <input type=\"radio\" id=\"green\">");

        // Size / Dung tich
        html = html.Replace("Popular Size", "Dung tích / Size");
        html = html.Replace("Large\n", "100ml\n");
        html = html.Replace("Medium\n", "50ml\n");
        html = html.Replace("Small\n", "30ml\n");
        html = html.Replace("Tiny\n", "200ml\n");

        // Sidebar Latest Products Slider
        string sidebarLatestProducts = @"
                            <div class=""latest-product__text"">
                                <h4>Sản phẩm mới nhất</h4>
                                <div class=""latest-product__slider owl-carousel"">
                                    <div class=""latest-prdouct__slider__item"">
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Kem Mắt Collagen Tươi Phục Hồi</h6>
                                                <span>$32.00</span>
                                            </div>
                                        </a>
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Toner Hoa Cúc Cân Bằng Độ Ẩm</h6>
                                                <span>$24.00</span>
                                            </div>
                                        </a>
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Xịt Khoáng Dưỡng Ẩm Nha Đam</h6>
                                                <span>$19.00</span>
                                            </div>
                                        </a>
                                    </div>
                                    <div class=""latest-prdouct__slider__item"">
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Kem Dưỡng Đêm Tái Tạo Collagen</h6>
                                                <span>$48.00</span>
                                            </div>
                                        </a>
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Gel Rửa Mặt Tràm Trà Kháng Viêm</h6>
                                                <span>$18.00</span>
                                            </div>
                                        </a>
                                        <a href=""shop-details.html"" class=""latest-product__item"">
                                            <div class=""latest-product__item__pic"">
                                                <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                            </div>
                                            <div class=""latest-product__item__text"">
                                                <h6>Tinh Chất Trẻ Hóa Retinol 0.5%</h6>
                                                <span>$58.00</span>
                                            </div>
                                        </a>
                                    </div>
                                </div>
                            </div>";
        html = Regex.Replace(html, @"<div class=""latest-product__text"">[\s\S]*?</div>\s*</div>\s*</div>\s*</div>\s*</div>\s*</div>",
                             sidebarLatestProducts + "\n</div></div></div></div>");

        // Sale Off Carousel (from <div class="product__discount"> to <div class="filter__item">)
        string saleOffSection = @"
<div class=""product__discount"">
    <div class=""section-title product__discount__title"">
        <h2>Sản phẩm khuyến mãi (Sale Off)</h2>
    </div>
    <div class=""row"">
        <div class=""product__discount__slider owl-carousel"">
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-1.jpg"">
                        <div class=""product__discount__percent"">-20%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Chăm sóc da mặt</span>
                        <h5><a href=""shop-details.html"">Combo Dưỡng Trắng Hồng Trà Xanh</a></h5>
                        <div class=""product__item__price"">$30.00 <span>$36.00</span></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-2.jpg"">
                        <div class=""product__discount__percent"">-20%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Serum chuyên sâu</span>
                        <h5><a href=""shop-details.html"">Serum Cấp Nước Phục Hồi B5 & HA</a></h5>
                        <div class=""product__item__price"">$30.00 <span>$36.00</span></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-3.jpg"">
                        <div class=""product__discount__percent"">-20%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Tẩy tế bào chết</span>
                        <h5><a href=""shop-details.html"">Tẩy Tế Bào Chết Cà Phê Cúc La Mã</a></h5>
                        <div class=""product__item__price"">$25.00 <span>$32.00</span></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-4.jpg"">
                        <div class=""product__discount__percent"">-25%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Làm sạch da</span>
                        <h5><a href=""shop-details.html"">Nước Tẩy Trang Dịu Nhẹ Green Tea</a></h5>
                        <div class=""product__item__price"">$18.00 <span>$24.00</span></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-5.jpg"">
                        <div class=""product__discount__percent"">-20%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Mặt nạ thảo dược</span>
                        <h5><a href=""shop-details.html"">Mặt Nạ Đất Sét Tràm Trà Kiềm Dầu</a></h5>
                        <div class=""product__item__price"">$22.00 <span>$28.00</span></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""product__discount__item"">
                    <div class=""product__discount__item__pic set-bg"" data-setbg=""Images/product/discount/pd-6.jpg"">
                        <div class=""product__discount__percent"">-20%</div>
                        <ul class=""product__item__pic__hover"">
                            <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                            <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                            <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                        </ul>
                    </div>
                    <div class=""product__discount__item__text"">
                        <span>Chống nắng bảo vệ</span>
                        <h5><a href=""shop-details.html"">Kem Chống Nắng Phổ Rộng SPF50+</a></h5>
                        <div class=""product__item__price"">$28.00 <span>$35.00</span></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>";
        html = Regex.Replace(html, @"<div class=""product__discount"">[\s\S]*?(?=<div class=""filter__item"">)", saleOffSection + "\n");

        // Filter Bar & 16 Products Grid
        string mainProductsGrid = @"
<div class=""filter__item"">
    <div class=""row"">
        <div class=""col-lg-4 col-md-5"">
            <div class=""filter__sort"">
                <span>Sắp xếp theo</span>
                <select>
                    <option value=""0"">Mặc định</option>
                    <option value=""1"">Giá tăng dần</option>
                    <option value=""2"">Giá giảm dần</option>
                    <option value=""3"">Bán chạy nhất</option>
                </select>
            </div>
        </div>
        <div class=""col-lg-4 col-md-4"">
            <div class=""filter__found"">
                <h6><span>16</span> Sản phẩm tìm thấy</h6>
            </div>
        </div>
        <div class=""col-lg-4 col-md-3"">
            <div class=""filter__option"">
                <span class=""icon_grid-2x2 active""></span>
                <span class=""icon_ul""></span>
            </div>
        </div>
    </div>
</div>
<div class=""row"">
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-1.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Tẩy Tế Bào Chết Cà Phê Cúc La Mã</a></h6>
                <h5>$15.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-2.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Son Dưỡng Môi Màu Đỏ Cam Tự Nhiên</a></h6>
                <h5>$18.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-3.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Combo Chăm Sóc Da Căn Bản Trắng Hồng</a></h6>
                <h5>$53.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-4.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Nước Tẩy Trang Trà Xanh Green Tea Pure</a></h6>
                <h5>$14.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-5.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Xịt Khoáng Dưỡng Ẩm Tinh Chất Lô Hội</a></h6>
                <h5>$16.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-6.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Kem Chống Nắng Nâng Tone Kiềm Dầu SPF50+</a></h6>
                <h5>$35.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-7.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Mặt Nạ Đất Sét Tràm Trà Hút Dầu Mụn</a></h6>
                <h5>$22.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-8.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Serum Cấp Nước Phục Hồi Da B5 & HA</a></h6>
                <h5>$42.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-9.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Sữa Rửa Mặt Dịu Nhẹ Rau Má Lên Men</a></h6>
                <h5>$15.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-10.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Kem Dưỡng Trắng Ban Đêm Collagen</a></h6>
                <h5>$48.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-11.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Tinh Dầu Trị Liệu Oải Hương & Hoa Hồng</a></h6>
                <h5>$28.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-12.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Bộ Kit Dưỡng Ẩm Du Lịch 4 Món Mini</a></h6>
                <h5>$29.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-1.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Nước Hoa Hồng Cúc La Mã Cân Bằng Độ Ẩm</a></h6>
                <h5>$20.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-2.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Gel Dưỡng Nha Đam Làm Dịu Cháy Nắng</a></h6>
                <h5>$12.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-3.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Tinh Chất Trẻ Hóa Retinol 0.5% & Peptide</a></h6>
                <h5>$58.00</h5>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-md-6 col-sm-6"">
        <div class=""product__item"">
            <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-4.jpg"">
                <ul class=""product__item__pic__hover"">
                    <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                    <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                    <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                </ul>
            </div>
            <div class=""product__item__text"">
                <h6><a href=""shop-details.html"">Sáp Tẩy Trang Thảo Mộc Đánh Bay Mascara</a></h6>
                <h5>$26.00</h5>
            </div>
        </div>
    </div>
</div>";
        html = Regex.Replace(html, @"<div class=""filter__item"">[\s\S]*?<div class=""product__pagination"">", mainProductsGrid + "\n<div class=\"product__pagination\">");

        Save("shop-grid.html", html);
    }

    static void BuildShopDetails() {
        string html = ReadRaw("raw_shop-details.html");
        html = ApplyBaseTranslations(html, "shop-details");

        // Breadcrumb
        html = Regex.Replace(html, @"<h2>.*?</h2>\s*<div class=""breadcrumb__option"">[\s\S]*?</div>", @"
                        <h2>Combo Chăm Sóc Da Căn Bản Trắng Hồng</h2>
                        <div class=""breadcrumb__option"">
                            <a href=""./index.html"">Trang Chủ</a>
                            <a href=""./shop-grid.html"">Chăm Sóc Da</a>
                            <span>Combo Chăm Sóc Da Căn Bản Trắng Hồng</span>
                        </div>");

        // Product Details Title & Rating
        html = Regex.Replace(html, @"<h3>Vetgetable[\s\S]*?</h3>", "<h3>Combo Chăm Sóc Da Căn Bản Trắng Hồng</h3>");
        html = Regex.Replace(html, @"<span>\(\d+ reviews\)</span>", "<span>(148 đánh giá của khách hàng)</span>");
        html = Regex.Replace(html, @"<div class=""product__details__price"">.*?</div>", "<div class=\"product__details__price\">$53.00</div>");
        
        // Summary text
        html = Regex.Replace(html, @"<div class=""product__details__price"">\$53\.00</div>\s*<p>[\s\S]*?</p>", @"<div class=""product__details__price"">$53.00</div>
                        <p>Bộ ba chăm sóc da chuyên sâu chiết xuất từ rau má organic, trà xanh và vitamin B5 giúp cấp ẩm đa tầng, phục hồi hàng rào bảo vệ tự nhiên và nuôi dưỡng làn da trắng hồng, căng mọng rạng rỡ.</p>");

        // Add to cart button
        html = Regex.Replace(html, @"<a href=""#"" class=""primary-btn"">ADD TO CAR[TD]</a>", "<a href=\"./shoping-cart.html\" class=\"primary-btn\">THÊM VÀO GIỎ HÀNG</a>");

        // Product Meta
        html = html.Replace("<b>Availability</b> <span>In Stock</span>", "<b>Tình trạng</b> <span>Còn hàng (Sẵn sàng giao)</span>");
        html = html.Replace("<b>Shipping</b> <span>01 day shipping. <samp>Free pickup today</samp></span>", "<b>Vận chuyển</b> <span>Giao hàng hỏa tốc 24h. <samp>Miễn phí từ $50</samp></span>");
        html = html.Replace("<b>Weight</b> <span>0.5 kg</span>", "<b>Dung tích</b> <span>Bộ 3 món (150ml + 120ml + 50ml)</span>");
        html = html.Replace("<b>Share on</b>", "<b>Chia sẻ</b>");

        // Tabs Headers
        html = html.Replace("Description</a>", "Mô tả sản phẩm</a>");
        html = html.Replace("Information</a>", "Thành phần & Công nghệ</a>");
        html = Regex.Replace(html, @"Reviews <span>\(\d+\)</span></a>", "Đánh giá của khách hàng <span>(3)</span></a>");

        // Tab 1 Content
        string tab1 = @"
                                <div class=""product__details__tab__desc"">
                                    <h6>Mô Tả Sản Phẩm Combo Trắng Hồng Dola Spa</h6>
                                    <p>Bộ sản phẩm Combo Chăm Sóc Da Căn Bản Trắng Hồng là giải pháp hoàn hảo cho phái đẹp muốn sở hữu làn da căng bóng, mướt mịn tự nhiên chuẩn Hàn Quốc. Với công thức độc quyền nghiên cứu bởi các chuyên gia da liễu tại Dola Spa, sản phẩm được chắt lọc từ 100% thảo mộc organic không chứa paraben, cồn khô hay hương liệu tổng hợp.</p>
                                    <p>Quy trình tác động 3 bước khép kín:<br>
                                    - <b>Bước 1: Làm sạch sâu</b> với Sữa rửa mặt rau má lên men nhẹ nhàng cuốn trôi bụi mịn PM2.5 và bã nhờn mà vẫn giữ độ ẩm pH 5.5.<br>
                                    - <b>Bước 2: Cân bằng & Mở đường dẫn ẩm</b> với Toner hoa cúc la mã giúp làm dịu tức thì các kích ứng, se khít lỗ chân lông.<br>
                                    - <b>Bước 3: Phục hồi & Khóa ẩm căng mướt</b> với Serum B5 & HA cấp nước tầng sâu, hỗ trợ tái tạo màng lipid bảo vệ da suốt 24 giờ.</p>
                                </div>";

        // Tab 2 Content
        string tab2 = @"
                                <div class=""product__details__tab__desc"">
                                    <h6>Thành Phần & Chứng Nhận Chất Lượng</h6>
                                    <p><b>Bảng thành phần tiêu biểu:</b> Centella Asiatica Extract (chiết xuất rau má hữu cơ), Camellia Sinensis Leaf Extract (tinh chất trà xanh), Sodium Hyaluronate (HA đa kích thước), Panthenol (Vitamin B5 tinh khiết), Niacinamide 2%, Allantoin, Ceramide NP.</p>
                                    <p><b>Cam kết chất lượng từ Dola Spa:</b><br>
                                    • Đạt chứng nhận thuần chay (Vegan) & không thử nghiệm trên động vật (Cruelty-Free).<br>
                                    • Được kiểm nghiệm da liễu an toàn cho cả làn da mụn và da nhạy cảm nhất.<br>
                                    • Hạn sử dụng: 36 tháng kể từ ngày sản xuất (12 tháng sau khi mở nắp).</p>
                                </div>";

        // Tab 3 Content (Natural Vietnamese Customer Feedback)
        string tab3 = @"
                                <div class=""product__details__tab__desc"">
                                    <h6>Đánh Giá Thực Tế Từ Khách Hàng (3 Đánh Giá)</h6>
                                    <div class=""review__item"" style=""border-bottom: 1px solid #eee; padding-bottom: 15px; margin-bottom: 15px;"">
                                        <div style=""display:flex; justify-content:space-between; align-items:center;"">
                                            <h5 style=""color:#333; font-size:16px; font-weight:700;"">Nguyễn Hoàng Yến <span style=""color:#7fad39; font-size:13px; font-weight:normal;"">✓ Đã mua hàng tại Dola Spa</span></h5>
                                            <div style=""color:#edbb0e;""><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i></div>
                                        </div>
                                        <p style=""font-style:italic; margin-top:8px; color:#555;"">""Mỹ phẩm ở đây xài mướt da lắm, nhân viên lại tư vấn nhiệt tình, sẽ ủng hộ dài dài.""</p>
                                        <small style=""color:#999;"">Đánh giá vào 2 ngày trước • Mua tại Chi nhánh Quận 3 TP.HCM</small>
                                    </div>
                                    <div class=""review__item"" style=""border-bottom: 1px solid #eee; padding-bottom: 15px; margin-bottom: 15px;"">
                                        <div style=""display:flex; justify-content:space-between; align-items:center;"">
                                            <h5 style=""color:#333; font-size:16px; font-weight:700;"">Trần Bích Thảo <span style=""color:#7fad39; font-size:13px; font-weight:normal;"">✓ Đã mua hàng tại Dola Spa</span></h5>
                                            <div style=""color:#edbb0e;""><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i></div>
                                        </div>
                                        <p style=""font-style:italic; margin-top:8px; color:#555;"">""Dùng trọn bộ combo này da mình đỡ mụn hẳn, nâng tông tự nhiên mà không hề bết rít. Giao hàng nhanh đóng gói cẩn thận 5 sao nhé!""</p>
                                        <small style=""color:#999;"">Đánh giá vào 1 tuần trước • Mua Online</small>
                                    </div>
                                    <div class=""review__item"">
                                        <div style=""display:flex; justify-content:space-between; align-items:center;"">
                                            <h5 style=""color:#333; font-size:16px; font-weight:700;"">Lê Vũ Thùy Trang <span style=""color:#7fad39; font-size:13px; font-weight:normal;"">✓ Đã mua hàng tại Dola Spa</span></h5>
                                            <div style=""color:#edbb0e;""><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i><i class=""fa fa-star""></i></div>
                                        </div>
                                        <p style=""font-style:italic; margin-top:8px; color:#555;"">""Mùi thảo mộc nhẹ nhàng thư giãn, kem thấm nhanh vào da, sáng ngủ dậy sờ da mềm mịn thích mê luôn ạ.""</p>
                                        <small style=""color:#999;"">Đánh giá vào 2 tuần trước • Mua Online</small>
                                    </div>
                                </div>";

        html = Regex.Replace(html, @"<div class=""tab-pane active"" id=""tabs-1"" role=""tabpanel"">[\s\S]*?</div>\s*</div>", "<div class=\"tab-pane active\" id=\"tabs-1\" role=\"tabpanel\">" + tab1 + "\n</div>");
        html = Regex.Replace(html, @"<div class=""tab-pane"" id=""tabs-2"" role=""tabpanel"">[\s\S]*?</div>\s*</div>", "<div class=\"tab-pane\" id=\"tabs-2\" role=\"tabpanel\">" + tab2 + "\n</div>");
        html = Regex.Replace(html, @"<div class=""tab-pane"" id=""tabs-3"" role=""tabpanel"">[\s\S]*?</div>\s*</div>", "<div class=\"tab-pane\" id=\"tabs-3\" role=\"tabpanel\">" + tab3 + "\n</div>");

        // Related Products section
        string relatedProducts = @"
    <section class=""related-product"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title related__product__title"">
                        <h2>Sản Phẩm Cùng Liệu Trình</h2>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-3 col-md-4 col-sm-6"">
                    <div class=""product__item"">
                        <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-1.jpg"">
                            <ul class=""product__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""product__item__text"">
                            <h6><a href=""shop-details.html"">Tẩy Tế Bào Chết Cà Phê Cúc La Mã</a></h6>
                            <h5>$15.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6"">
                    <div class=""product__item"">
                        <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-2.jpg"">
                            <ul class=""product__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""product__item__text"">
                            <h6><a href=""shop-details.html"">Son Dưỡng Môi Màu Đỏ Cam Tự Nhiên</a></h6>
                            <h5>$18.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6"">
                    <div class=""product__item"">
                        <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-3.jpg"">
                            <ul class=""product__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""product__item__text"">
                            <h6><a href=""shop-details.html"">Serum Cấp Nước Phục Hồi Da B5 & HA</a></h6>
                            <h5>$42.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6"">
                    <div class=""product__item"">
                        <div class=""product__item__pic set-bg"" data-setbg=""Images/product/product-7.jpg"">
                            <ul class=""product__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""product__item__text"">
                            <h6><a href=""shop-details.html"">Mặt Nạ Đất Sét Tràm Trà Hút Dầu Mụn</a></h6>
                            <h5>$22.00</h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""related-product"">[\s\S]*?</section>", relatedProducts);

        Save("shop-details.html", html);
    }

    static void BuildCart() {
        string html = ReadRaw("raw_shoping-cart.html");
        html = ApplyBaseTranslations(html, "cart");

        // Breadcrumb
        html = html.Replace("<h2>Shopping Cart</h2>", "<h2>Giỏ Hàng Của Bạn</h2>");
        html = html.Replace("<a href=\"./index.html\">Home</a>", "<a href=\"./index.html\">Trang Chủ</a>");
        html = html.Replace("<span>Shopping Cart</span>", "<span>Giỏ Hàng</span>");

        // Table headers
        html = html.Replace("<th>Products</th>", "<th>Sản phẩm</th>");
        html = html.Replace("<th>Price</th>", "<th>Đơn giá</th>");
        html = html.Replace("<th>Quantity</th>", "<th>Số lượng</th>");
        html = html.Replace("<th>Total</th>", "<th>Thành tiền</th>");

        // Table Body with 3 Vietnamese Spa Items
        string cartTbody = @"
                            <tbody>
                                <tr data-price=""55.00"">
                                    <td class=""shoping__cart__item"">
                                        <img src=""Images/cart/cart-1.jpg"" alt="""">
                                        <h5>Combo Chăm Sóc Da Căn Bản Trắng Hồng</h5>
                                    </td>
                                    <td class=""shoping__cart__price"">
                                        $55.00
                                    </td>
                                    <td class=""shoping__cart__quantity"">
                                        <div class=""quantity"">
                                            <div class=""pro-qty"">
                                                <input type=""text"" value=""1"">
                                            </div>
                                        </div>
                                    </td>
                                    <td class=""shoping__cart__total"">
                                        $55.00
                                    </td>
                                    <td class=""shoping__cart__item__close"">
                                        <span class=""icon_close""></span>
                                    </td>
                                </tr>
                                <tr data-price=""40.00"">
                                    <td class=""shoping__cart__item"">
                                        <img src=""Images/cart/cart-2.jpg"" alt="""">
                                        <h5>Serum Cấp Nước Phục Hồi B5 & HA</h5>
                                    </td>
                                    <td class=""shoping__cart__price"">
                                        $40.00
                                    </td>
                                    <td class=""shoping__cart__quantity"">
                                        <div class=""quantity"">
                                            <div class=""pro-qty"">
                                                <input type=""text"" value=""1"">
                                            </div>
                                        </div>
                                    </td>
                                    <td class=""shoping__cart__total"">
                                        $40.00
                                    </td>
                                    <td class=""shoping__cart__item__close"">
                                        <span class=""icon_close""></span>
                                    </td>
                                </tr>
                                <tr data-price=""15.00"">
                                    <td class=""shoping__cart__item"">
                                        <img src=""Images/cart/cart-3.jpg"" alt="""">
                                        <h5>Nước Tẩy Trang Dịu Nhẹ Green Tea Pure</h5>
                                    </td>
                                    <td class=""shoping__cart__price"">
                                        $15.00
                                    </td>
                                    <td class=""shoping__cart__quantity"">
                                        <div class=""quantity"">
                                            <div class=""pro-qty"">
                                                <input type=""text"" value=""1"">
                                            </div>
                                        </div>
                                    </td>
                                    <td class=""shoping__cart__total"">
                                        $15.00
                                    </td>
                                    <td class=""shoping__cart__item__close"">
                                        <span class=""icon_close""></span>
                                    </td>
                                </tr>
                            </tbody>";

        html = Regex.Replace(html, @"<tbody>[\s\S]*?</tbody>", cartTbody);

        // Action Buttons
        html = html.Replace("CONTINUE SHOPPING", "TIẾP TỤC MUA SẮM");
        html = html.Replace("UPDATE CART", "CẬP NHẬT GIỎ HÀNG");
        html = html.Replace("<a href=\"#\" class=\"primary-btn cart-btn\">", "<a href=\"./shop-grid.html\" class=\"primary-btn cart-btn\">");

        // Coupon & Checkout Summary
        html = html.Replace("Apply Coupon", "Áp Dụng Mã Ưu Đãi");
        html = html.Replace("Enter your coupon code", "Nhập mã DOLASPA20 để giảm 20%");
        html = html.Replace("APPLY COUPON", "ÁP DỤNG");

        html = html.Replace("Cart Total", "Tổng Tiền Giỏ Hàng");
        html = html.Replace("Subtotal <span>$150.00</span>", "Tạm tính <span id=\"cart-subtotal\">$110.00</span>");
        html = html.Replace("Total <span>$150.00</span>", "Tổng thanh toán <span id=\"cart-total\">$110.00</span>");
        html = html.Replace("PROCEED TO CHECKOUT", "TIẾN HÀNH THANH TOÁN");
        html = html.Replace("<a href=\"#\" class=\"primary-btn\">TIẾN HÀNH THANH TOÁN</a>", "<a href=\"./checkout.html\" class=\"primary-btn\">TIẾN HÀNH THANH TOÁN</a>");

        // Dynamic Interactive Cart Script
        string cartScript = @"
    <script>
        $(document).ready(function() {
            var discountRate = 0;

            function updateCartTotals() {
                var subtotal = 0;
                $('tbody tr').each(function() {
                    var unitPrice = parseFloat($(this).data('price')) || 0;
                    var qty = parseInt($(this).find('.pro-qty input').val()) || 0;
                    var rowTotal = unitPrice * qty;
                    $(this).find('.shoping__cart__total').text('$' + rowTotal.toFixed(2));
                    subtotal += rowTotal;
                });
                var total = subtotal * (1 - discountRate);
                $('#cart-subtotal').text('$' + subtotal.toFixed(2));
                $('#cart-total').text('$' + total.toFixed(2));
            }

            // Click close / remove row
            $(document).on('click', '.shoping__cart__item__close', function() {
                $(this).closest('tr').fadeOut(300, function() {
                    $(this).remove();
                    updateCartTotals();
                });
            });

            // Quantity change
            $(document).on('click', '.qtybtn', function() {
                setTimeout(updateCartTotals, 50);
            });
            $(document).on('change', '.pro-qty input', function() {
                updateCartTotals();
            });

            // Coupon
            $('.shoping__discount form').on('submit', function(e) {
                e.preventDefault();
                var code = $(this).find('input').val().trim().toUpperCase();
                if (code === 'DOLASPA20') {
                    discountRate = 0.20;
                    alert('Áp dụng mã DOLASPA20 thành công! Bạn được giảm 20% trên tổng đơn hàng.');
                    updateCartTotals();
                } else if (code === '') {
                    alert('Vui lòng nhập mã ưu đãi (Thử mã: DOLASPA20)');
                } else {
                    alert('Mã giảm giá không hợp lệ. Vui lòng thử lại với mã DOLASPA20');
                }
            });
        });
    </script>
</body>";
        html = html.Replace("</body>", cartScript);

        Save("shoping-cart.html", html);
    }

    static void BuildCheckout() {
        string html = ReadRaw("raw_checkout.html");
        html = ApplyBaseTranslations(html, "checkout");

        // Breadcrumb
        html = html.Replace("<h2>Checkout</h2>", "<h2>Thanh Toán Đơn Hàng</h2>");
        html = html.Replace("<a href=\"./index.html\">Home</a>", "<a href=\"./index.html\">Trang Chủ</a>");
        html = html.Replace("<span>Checkout</span>", "<span>Thanh Toán</span>");

        // Coupon reminder
        html = html.Replace("Have a coupon? <a href=\"#\">Click here</a> to enter your code", "Bạn có mã giảm giá? <a href=\"./shoping-cart.html\">Nhấp vào đây</a> để nhập mã");

        // Form Title
        html = html.Replace("<h4>Billing Details</h4>", "<h4>Thông Tin Thanh Toán & Giao Hàng</h4>");

        // Form fields
        html = html.Replace("<p>Fist Name<span>*</span></p>", "<p>Họ và tên đệm<span>*</span></p>");
        html = html.Replace("<p>Last Name<span>*</span></p>", "<p>Tên của bạn<span>*</span></p>");
        html = html.Replace("<p>Country<span>*</span></p>", "<p>Quốc gia / Khu vực<span>*</span></p>");
        html = html.Replace("<input type=\"text\">\n                            </div>\n                            <div class=\"checkout__input\">\n                                <p>Address<span>*</span></p>",
                            "<input type=\"text\" value=\"Việt Nam\">\n                            </div>\n                            <div class=\"checkout__input\">\n                                <p>Địa chỉ nhận hàng<span>*</span></p>");
        html = html.Replace("placeholder=\"Street Address\"", "placeholder=\"Số nhà, tên đường, khu phố...\"");
        html = html.Replace("placeholder=\"Apartment, suite, unite etc (optinal)\"", "placeholder=\"Tòa nhà, số tầng, căn hộ (không bắt buộc)\"");
        html = html.Replace("<p>Town/City<span>*</span></p>", "<p>Tỉnh / Thành phố<span>*</span></p>");
        html = html.Replace("<p>Country/State<span>*</span></p>", "<p>Quận / Huyện / Thị xã<span>*</span></p>");
        html = html.Replace("<p>Postcode / ZIP<span>*</span></p>", "<p>Mã bưu điện (Zip Code)<span>*</span></p>");
        html = html.Replace("<p>Phone<span>*</span></p>", "<p>Số điện thoại liên hệ<span>*</span></p>");
        html = html.Replace("<p>Email<span>*</span></p>", "<p>Địa chỉ Email<span>*</span></p>");
        html = html.Replace("<p>Order notes<span>*</span></p>", "<p>Ghi chú đơn hàng (chỉ dẫn giao hàng, giờ giao...)<span></span></p>");
        html = html.Replace("placeholder=\"Notes about your order, e.g. special notes for delivery.\"", "placeholder=\"Ví dụ: Giao giờ hành chính, gọi trước khi đến...\"");

        html = html.Replace("Create an account?", "Tạo tài khoản thành viên Dola VIP?");
        html = html.Replace("Create an account by entering the information below. If you are a returning customer", "Tích lũy điểm thưởng và nhận quà sinh nhật từ Dola Spa.");
        html = html.Replace("<p>Account Password<span>*</span></p>", "<p>Mật khẩu tạo tài khoản<span>*</span></p>");
        html = html.Replace("Ship to a different address?", "Giao hàng tới địa chỉ khác?");

        // Order Box
        html = html.Replace("<h4>Your Order</h4>", "<h4>Đơn Hàng Của Bạn</h4>");
        html = html.Replace("Products <span>Total</span>", "Sản phẩm <span>Thành tiền</span>");

        string orderItems = @"
                                <ul>
                                    <li>Combo Chăm Sóc Da Căn Bản Trắng Hồng <span>$55.00</span></li>
                                    <li>Serum Cấp Nước Phục Hồi B5 & HA <span>$40.00</span></li>
                                    <li>Nước Tẩy Trang Dịu Nhẹ Green Tea <span>$15.00</span></li>
                                </ul>";
        html = Regex.Replace(html, @"<div class=""checkout__order__products"">[\s\S]*?<ul>[\s\S]*?</ul>", "<div class=\"checkout__order__products\">Sản phẩm <span>Thành tiền</span></div>\n" + orderItems);

        html = html.Replace("Subtotal <span>$750.99</span>", "Tạm tính <span>$110.00</span>");
        html = html.Replace("Total <span>$750.99</span>", "Tổng thanh toán <span>$110.00</span>");

        // Payment options
        html = html.Replace("Check Payment", "Thanh toán khi nhận hàng (COD)");
        html = html.Replace("Paypal", "Chuyển khoản Ngân hàng / VNPAY / MoMo");
        html = Regex.Replace(html, @"<p>Lorem ipsum dolor sit amet[\s\S]*?</p>",
                            "<p>Kiểm tra hàng trước khi thanh toán. Đổi trả miễn phí trong 7 ngày nếu có bất kỳ kích ứng nào.</p>");

        html = html.Replace("PLACE ORDER", "ĐẶT HÀNG NGAY");

        // Order Submit Alert
        string checkoutScript = @"
    <script>
        document.querySelector('.checkout__form form').addEventListener('submit', function(e) {
            e.preventDefault();
            alert('🎉 CHÚC MỪNG QUÝ KHÁCH ĐÃ ĐẶT HÀNG THÀNH CÔNG!\n\nMã đơn hàng: #DOLA' + Math.floor(100000 + Math.random() * 900000) + '\nTổng thanh toán: $110.00\n\nChuyên viên Dola Spa sẽ gọi điện xác nhận trong 15 phút. Cảm ơn quý khách!');
            window.location.href = './index.html';
        });
    </script>
</body>";
        html = html.Replace("</body>", checkoutScript);

        Save("checkout.html", html);
    }

    static void BuildBlog() {
        string html = ReadRaw("raw_blog.html");
        html = ApplyBaseTranslations(html, "blog");

        // Breadcrumb
        html = html.Replace("<h2>Blog</h2>", "<h2>Cẩm Nang Spa & Làm Đẹp</h2>");
        html = html.Replace("<a href=\"./index.html\">Home</a>", "<a href=\"./index.html\">Trang Chủ</a>");
        html = html.Replace("<span>Blog</span>", "<span>Cẩm Nang Spa</span>");

        // Sidebar
        string sidebarCategories = @"
                        <div class=""blog__sidebar__item"">
                            <h4>Chuyên mục làm đẹp</h4>
                            <ul>
                                <li><a href=""#"">Tất cả bài viết</a></li>
                                <li><a href=""#"">Chăm sóc da mặt (20)</a></li>
                                <li><a href=""#"">Mỹ phẩm thuần chay (15)</a></li>
                                <li><a href=""#"">Liệu trình trị liệu Spa (12)</a></li>
                                <li><a href=""#"">Bí quyết trẻ hóa da (8)</a></li>
                            </ul>
                        </div>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__item"">\s*<h4>Categories</h4>\s*<ul>[\s\S]*?</ul>\s*</div>", sidebarCategories);

        html = html.Replace("Recent News", "Bài viết mới nhất");
        html = html.Replace("Search By", "Thẻ tìm kiếm nổi bật");

        // Tag cloud
        string tags = @"
                                <a href=""#"">Chăm Sóc Da</a>
                                <a href=""#"">Serum B5</a>
                                <a href=""#"">Trắng Hồng</a>
                                <a href=""#"">Dola Spa</a>
                                <a href=""#"">Chống Lão Hóa</a>
                                <a href=""#"">Organic</a>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__item__tags"">[\s\S]*?</div>", "<div class=\"blog__sidebar__item__tags\">" + tags + "\n                            </div>");

        // Recent posts in sidebar
        string recentPosts = @"
                            <div class=""blog__sidebar__recent"">
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-1.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Bí quyết cấp ẩm sâu<br />cho làn da căng mướt</h6>
                                        <span>24 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-2.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Routine 4 bước phục hồi<br />da mụn nhạy cảm</h6>
                                        <span>18 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-3.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Top 5 thảo mộc trị liệu<br />dưỡng sáng da tự nhiên</h6>
                                        <span>10 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                            </div>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__recent"">[\s\S]*?</div>\s*</div>", recentPosts + "\n                        </div>");

        // Main 6 blog posts
        string blogGrid = @"
                    <div class=""row"">
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-1.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 24 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 18 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Bí quyết cấp ẩm sâu cho làn da căng bóng mướt mịn chuẩn Hàn</a></h5>
                                    <p>Hướng dẫn chi tiết các bước skincare cấp nước tầng sâu với Hyaluronic Acid và B5 giúp làn da ngậm nước suốt 24 giờ...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-2.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 20 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 25 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Routine 4 bước chăm sóc da mụn nhạy cảm phục hồi tức thì</a></h5>
                                    <p>Chăm sóc da mụn cần sự tối giản nhưng hiệu quả cao. Bí quyết làm sạch dịu nhẹ và kháng viêm từ chiết xuất tràm trà...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-3.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 15 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 12 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Tinh hoa làm đẹp từ dầu ô liu và thảo mộc tự nhiên Dola Spa</a></h5>
                                    <p>Khám phá công thức dưỡng ẩm chống lão hóa từ thảo mộc thiên nhiên mang lại sức sống tươi trẻ và rạng ngời cho phái đẹp...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-4.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 10 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 30 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Cách chọn kem chống nắng phổ rộng bảo vệ da toàn diện</a></h5>
                                    <p>Tia UV là thủ phạm hàng đầu gây lão hóa và sạm nám. Tìm hiểu tiêu chí chọn kem chống nắng an toàn không nâng tone quá lố...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-6.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 05 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 14 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Liệu pháp xông hơi thảo dược thải độc da chuyên sâu</a></h5>
                                    <p>Phương pháp detox da mặt bằng tinh dầu tràm gió và hoa hồng giúp giãn nở lỗ chân lông và đào thải bụi mịn hiệu quả...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6 col-md-6 col-sm-6"">
                            <div class=""blog__item"">
                                <div class=""blog__item__pic"">
                                    <img src=""Images/blog/blog-1.jpg"" alt="""">
                                </div>
                                <div class=""blog__item__text"">
                                    <ul>
                                        <li><i class=""fa fa-calendar-o""></i> 01 Tháng 5, 2026</li>
                                        <li><i class=""fa fa-comment-o""></i> 22 Bình luận</li>
                                    </ul>
                                    <h5><a href=""blog-details.html"">Kinh nghiệm dưỡng môi hồng hào tự nhiên không cần phun xăm</a></h5>
                                    <p>Bí quyết tẩy tế bào chết môi bằng đường nâu và mật ong rừng kết hợp sáp dưỡng gấc cho đôi môi căng mọng quyến rũ...</p>
                                    <a href=""blog-details.html"" class=""blog__btn"">XEM CHI TIẾT <span class=""arrow_right""></span></a>
                                </div>
                            </div>
                        </div>
                    </div>";

        html = Regex.Replace(html, @"<div class=""col-lg-8 col-md-7"">\s*<div class=""row"">[\s\S]*?<div class=""col-lg-12"">\s*<div class=""product__pagination blog__pagination"">",
                             "<div class=\"col-lg-8 col-md-7\">\n" + blogGrid + "\n<div class=\"col-lg-12\">\n<div class=\"product__pagination blog__pagination\">");

        Save("blog.html", html);
    }

    static void BuildBlogDetails() {
        string html = ReadRaw("raw_blog-details.html");
        html = ApplyBaseTranslations(html, "blog-details");

        // Details Hero
        string detailsHero = @"
    <section class=""blog-details-hero set-bg"" data-setbg=""Images/blog/details/details-hero.jpg"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""blog__details__hero__text"">
                        <h2>Bí Quyết Chăm Sóc Da Căng Bóng Mướt Mịn Chuẩn Spa Hàn Quốc</h2>
                        <ul>
                            <li>Bởi BS. Nguyễn Lan Anh</li>
                            <li>24 Tháng 5, 2026</li>
                            <li>36 Bình luận</li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""blog-details-hero[\s\S]*?</section>", detailsHero);

        // Sidebar Categories
        string sidebarCategories = @"
                        <div class=""blog__sidebar__item"">
                            <h4>Chuyên mục làm đẹp</h4>
                            <ul>
                                <li><a href=""#"">Tất cả bài viết</a></li>
                                <li><a href=""#"">Chăm sóc da mặt (20)</a></li>
                                <li><a href=""#"">Mỹ phẩm thuần chay (15)</a></li>
                                <li><a href=""#"">Liệu trình trị liệu Spa (12)</a></li>
                                <li><a href=""#"">Bí quyết trẻ hóa da (8)</a></li>
                            </ul>
                        </div>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__item"">\s*<h4>Categories</h4>\s*<ul>[\s\S]*?</ul>\s*</div>", sidebarCategories);

        html = html.Replace("Recent News", "Bài viết mới nhất");
        html = html.Replace("Search By", "Thẻ tìm kiếm nổi bật");

        // Sidebar Recent Posts
        string recentPosts = @"
                            <div class=""blog__sidebar__recent"">
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-1.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Bí quyết cấp ẩm sâu<br />cho làn da căng mướt</h6>
                                        <span>24 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-2.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Routine 4 bước phục hồi<br />da mụn nhạy cảm</h6>
                                        <span>18 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                                <a href=""blog-details.html"" class=""blog__sidebar__recent__item"">
                                    <div class=""blog__sidebar__recent__item__pic"">
                                        <img src=""Images/blog/sidebar/sr-3.jpg"" alt="""">
                                    </div>
                                    <div class=""blog__sidebar__recent__item__text"">
                                        <h6>Top 5 thảo mộc trị liệu<br />dưỡng sáng da tự nhiên</h6>
                                        <span>10 THÁNG 5, 2026</span>
                                    </div>
                                </a>
                            </div>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__recent"">[\s\S]*?</div>\s*</div>", recentPosts + "\n                        </div>");

        // Tag cloud
        string tags = @"
                                <a href=""#"">Chăm Sóc Da</a>
                                <a href=""#"">Serum B5</a>
                                <a href=""#"">Trắng Hồng</a>
                                <a href=""#"">Dola Spa</a>
                                <a href=""#"">Chống Lão Hóa</a>
                                <a href=""#"">Organic</a>";
        html = Regex.Replace(html, @"<div class=""blog__sidebar__item__tags"">[\s\S]*?</div>", "<div class=\"blog__sidebar__item__tags\">" + tags + "\n                            </div>");

        // Detail Article Body with Embedded Video & Audio Showcase!
        string articleBody = @"
                    <div class=""blog__details__text"">
                        <img src=""Images/blog/details/details-pic.jpg"" alt="""" style=""border-radius: 8px; margin-bottom: 25px;"">
                        <p>Một làn da khỏe mạnh, căng tràn sức sống luôn là niềm ao ước của mọi cô gái. Tuy nhiên, dưới tác động của khói bụi ô nhiễm, ánh nắng mặt trời và áp lực công việc hàng ngày, làn da rất dễ rơi vào tình trạng thiếu nước, xỉn màu và xuất hiện nếp nhăn sớm. Tại Dola Spa, chúng tôi luôn tin rằng việc nuôi dưỡng làn da bắt đầu từ việc thấu hiểu và tôn trọng cơ chế tự phục hồi tự nhiên của tế bào.</p>
                        
                        <h3>Quy trình 3 bước vàng kiến tạo làn da thủy tinh (Glass Skin)</h3>
                        <p>Để đạt được hiệu ứng da căng bóng như phủ sương, bạn không cần phải layer quá nhiều lớp mỹ phẩm nặng nề. Thay vào đó, hãy tập trung vào 3 yếu tố cốt lõi: Làm sạch đúng cách không gây tổn thương màng ẩm, Cấp nước tầng sâu với phân tử Hyaluronic Acid đa kích thước, và Khóa ẩm bằng chiết xuất thảo mộc hữu cơ.</p>
                        
                        <!-- Embedded Video Section -->
                        <div class=""blog__video__showcase"" style=""margin: 30px 0; background: #fdfaf6; padding: 25px; border-radius: 10px; border: 1px solid #ede3d8;"">
                            <h4 style=""font-weight: 700; color: #1c1c1c; margin-bottom: 15px;""><i class=""fa fa-video-camera"" style=""color:#7fad39; margin-right:8px;""></i> Video Giới Thiệu Liệu Trình Spa & Mỹ Phẩm Dola Spa</h4>
                            <p style=""margin-bottom: 15px; color: #666;"">Mời bạn cùng xem quy trình trị liệu chuyên sâu và công nghệ chiết xuất mỹ phẩm thuần chay tại không gian Dola Spa:</p>
                            <div style=""position:relative; border-radius:8px; overflow:hidden; box-shadow:0 6px 18px rgba(0,0,0,0.1);"">
                                <video controls style=""width:100%; display:block; max-height:450px; background:#000;"">
                                    <source src=""Videos/spa-intro-video.mp4"" type=""video/mp4"">
                                    Trình duyệt của bạn không hỗ trợ phát video.
                                </video>
                            </div>
                            
                            <!-- Relaxing Audio Player -->
                            <div style=""margin-top: 20px; padding-top: 15px; border-top: 1px dashed #d6c6b6;"">
                                <h5 style=""font-weight:600; font-size:16px; color:#1c1c1c; margin-bottom:8px;""><i class=""fa fa-headphones"" style=""color:#7fad39; margin-right:8px;""></i> Nghe Nhạc Thiền Thư Giãn Dola Spa (MP3)</h5>
                                <p style=""font-size:14px; color:#777; margin-bottom:10px;"">Bật giai điệu êm dịu để thư thái tâm hồn trong lúc chăm sóc da:</p>
                                <audio controls style=""width:100%; outline:none;"">
                                    <source src=""Sounds/spa-relaxing-music.mp3"" type=""audio/mp3"">
                                    Trình duyệt của bạn không hỗ trợ phát âm thanh.
                                </audio>
                            </div>
                        </div>

                        <p>Đặc biệt, việc kết hợp massage nhẹ nhàng từ 3 - 5 phút mỗi tối với tinh dầu hoa hồng sẽ kích thích tuần hoàn máu dưới da, giúp các dưỡng chất thẩm thấu sâu hơn gấp 3 lần so với thoa kem thông thường.</p>
                    </div>";

        html = Regex.Replace(html, @"<div class=""blog__details__text"">[\s\S]*?</div>\s*<div class=""blog__details__content"">", articleBody + "\n<div class=\"blog__details__content\">");

        // Author Card (Asian Specialist)
        string authorCard = @"
                                <div class=""blog__details__author"">
                                    <div class=""blog__details__author__pic"">
                                        <img src=""Images/blog/details/details-author.jpg"" alt="""" style=""border-radius: 50%; width:92px; height:92px; object-fit:cover;"">
                                    </div>
                                    <div class=""blog__details__author__text"">
                                        <h6>BS. Nguyễn Lan Anh</h6>
                                        <span>Trưởng bộ phận Chuyên môn & Cố vấn Dola Spa</span>
                                    </div>
                                </div>";
        html = Regex.Replace(html, @"<div class=""blog__details__author"">[\s\S]*?</div>\s*</div>", authorCard + "\n</div>");

        // Author tags and social
        html = html.Replace("Categories:</span> Food", "Chuyên mục:</span> Chăm Sóc Da");
        html = html.Replace("Tags:</span> All, Trending, Cooking, Healthy Food, Life Style", "Thẻ:</span> Dola Spa, Skincare, Serum B5, Trắng Da, Tự Nhiên");

        // Related Blog Posts
        string relatedBlogSection = @"
    <section class=""related-blog spad"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title related-blog-title"">
                        <h2>Bài Viết Bạn Có Thể Thích</h2>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-1.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 24 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 18</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Bí quyết cấp ẩm sâu cho làn da căng bóng mướt mịn chuẩn Hàn</a></h5>
                            <p>Hướng dẫn chi tiết các bước skincare cấp nước tầng sâu với Hyaluronic Acid và B5 giúp da ngậm nước suốt 24 giờ...</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-2.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 20 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 25</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Routine 4 bước chăm sóc da mụn nhạy cảm phục hồi tức thì</a></h5>
                            <p>Chăm sóc da mụn cần sự tối giản nhưng hiệu quả cao. Bí quyết làm sạch dịu nhẹ và kháng viêm từ tràm trà...</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-3.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 15 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 12</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Tinh hoa làm đẹp từ dầu ô liu và thảo mộc tự nhiên Dola Spa</a></h5>
                            <p>Khám phá công thức dưỡng ẩm chống lão hóa từ thảo mộc thiên nhiên mang lại sức sống tươi trẻ rạng ngời...</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""related-blog spad"">[\s\S]*?</section>", relatedBlogSection);

        // Comments Form
        html = html.Replace("Leave Comment", "Để Lại Bình Luận Của Bạn");
        html = html.Replace("placeholder=\"Name\"", "placeholder=\"Họ và tên của bạn\"");
        html = html.Replace("placeholder=\"Email\"", "placeholder=\"Địa chỉ email\"");
        html = html.Replace("placeholder=\"Comment\"", "placeholder=\"Chia sẻ cảm nhận hoặc thắc mắc của bạn về bài viết...\"");
        html = html.Replace("POST COMMENT", "GỬI BÌNH LUẬN");

        Save("blog-details.html", html);
    }

    static void BuildIndex() {
        string html = ReadRaw("raw_index.html");
        html = ApplyBaseTranslations(html, "index");

        // Hero Banner Text & CTA
        html = html.Replace("FRUIT FRESH", "MỸ PHẨM THUẦN CHAY");
        html = html.Replace("Vegetable <br />100% Organic", "Dola Spa & Cosmetics<br />Mỹ Phẩm Thiên Nhiên");
        html = html.Replace("Free Pickup and Delivery Available", "Chiết xuất 100% thảo mộc hữu cơ cho làn da căng bóng mướt mịn");
        html = html.Replace("SHOP NOW", "MUA SẮM NGAY");
        html = html.Replace("<a href=\"#\" class=\"primary-btn\">MUA SẮM NGAY</a>", "<a href=\"./shop-grid.html\" class=\"primary-btn\">MUA SẮM NGAY</a>");

        // Categories Slider (Owl Carousel)
        string categoriesCarousel = @"
    <section class=""categories"">
        <div class=""container"">
            <div class=""row"">
                <div class=""categories__slider owl-carousel"">
                    <div class=""col-lg-3"">
                        <div class=""categories__item set-bg"" data-setbg=""Images/categories/cat-1.jpg"">
                            <h5><a href=""./shop-grid.html"">Chăm Sóc Da Mặt</a></h5>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""categories__item set-bg"" data-setbg=""Images/categories/cat-2.jpg"">
                            <h5><a href=""./shop-grid.html"">Tẩy Tế Bào Chết</a></h5>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""categories__item set-bg"" data-setbg=""Images/categories/cat-3.jpg"">
                            <h5><a href=""./shop-grid.html"">Serum & Tinh Chất</a></h5>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""categories__item set-bg"" data-setbg=""Images/categories/cat-4.jpg"">
                            <h5><a href=""./shop-grid.html"">Mặt Nạ Thảo Dược</a></h5>
                        </div>
                    </div>
                    <div class=""col-lg-3"">
                        <div class=""categories__item set-bg"" data-setbg=""Images/categories/cat-5.jpg"">
                            <h5><a href=""./shop-grid.html"">Nước Tẩy Trang</a></h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""categories"">[\s\S]*?</section>", categoriesCarousel);

        // Featured Section Title & Controls
        html = html.Replace("Featured Product", "Sản Phẩm Nổi Bật");

        string featuredControls = @"
                    <div class=""featured__controls"">
                        <ul>
                            <li class=""active"" data-filter=""*"">Tất Cả</li>
                            <li data-filter="".skincare"">Chăm Sóc Da</li>
                            <li data-filter="".serum"">Serum & Tinh Chất</li>
                            <li data-filter="".cleanser"">Làm Sạch Da</li>
                            <li data-filter="".spa"">Trị Liệu Spa</li>
                        </ul>
                    </div>";
        html = Regex.Replace(html, @"<div class=""featured__controls"">[\s\S]*?</div>", featuredControls);

        // 8 Distinct Featured Items with Correct Classes & Prices & Links
        string featuredGrid = @"
            <div class=""row featured__filter"">
                <div class=""col-lg-3 col-md-4 col-sm-6 mix skincare serum"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-1.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Combo Dưỡng Trắng Hồng Trà Xanh</a></h6>
                            <h5>$45.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix serum skincare"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-2.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Serum Cấp Nước Phục Hồi B5 & HA</a></h6>
                            <h5>$38.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix cleanser"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-3.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Tẩy Tế Bào Chết Cà Phê Cúc La Mã</a></h6>
                            <h5>$25.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix cleanser"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-4.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Nước Tẩy Trang Hoa Hồng Dịu Nhẹ</a></h6>
                            <h5>$22.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix skincare"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-5.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Kem Chống Nắng Phổ Rộng SPF50+</a></h6>
                            <h5>$35.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix spa skincare"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-6.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Mặt Nạ Thảo Dược Tràm Trà Kiềm Dầu</a></h6>
                            <h5>$28.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix skincare"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-7.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Son Dưỡng Gấc & Dầu Dừa Tự Nhiên</a></h6>
                            <h5>$18.00</h5>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-3 col-md-4 col-sm-6 mix spa"">
                    <div class=""featured__item"">
                        <div class=""featured__item__pic set-bg"" data-setbg=""Images/featured/feature-8.jpg"">
                            <ul class=""featured__item__pic__hover"">
                                <li><a href=""#""><i class=""fa fa-heart""></i></a></li>
                                <li><a href=""shop-details.html""><i class=""fa fa-retweet""></i></a></li>
                                <li><a href=""shoping-cart.html""><i class=""fa fa-shopping-cart""></i></a></li>
                            </ul>
                        </div>
                        <div class=""featured__item__text"">
                            <h6><a href=""shop-details.html"">Tinh Dầu Trị Liệu Oải Hương & Tràm</a></h6>
                            <h5>$32.00</h5>
                        </div>
                    </div>
                </div>
            </div>";
        html = Regex.Replace(html, @"<div class=""row featured__filter"">[\s\S]*?</div>\s*</div>\s*</section>", featuredGrid + "\n</div>\n</section>");

        // Banner Links
        html = Regex.Replace(html, @"<div class=""banner"">[\s\S]*?</div>\s*</div>\s*</div>\s*</div>", @"
    <div class=""banner"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-6 col-md-6 col-sm-6"">
                    <div class=""banner__pic"">
                        <a href=""shop-grid.html""><img src=""Images/banner/banner-1.jpg"" alt=""""></a>
                    </div>
                </div>
                <div class=""col-lg-6 col-md-6 col-sm-6"">
                    <div class=""banner__pic"">
                        <a href=""shop-grid.html""><img src=""Images/banner/banner-2.jpg"" alt=""""></a>
                    </div>
                </div>
            </div>
        </div>
    </div>");

        // Latest Products 3 columns
        string latestProductsSection = @"
    <section class=""latest-product spad"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-4 col-md-6"">
                    <div class=""latest-product__text"">
                        <h4>Sản phẩm mới nhất</h4>
                        <div class=""latest-product__slider owl-carousel"">
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Kem Mắt Collagen Tươi Phục Hồi</h6>
                                        <span>$32.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Toner Hoa Cúc Cân Bằng Độ Ẩm</h6>
                                        <span>$24.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Xịt Khoáng Dưỡng Ẩm Nha Đam</h6>
                                        <span>$19.00</span>
                                    </div>
                                </a>
                            </div>
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Kem Dưỡng Đêm Tái Tạo Collagen</h6>
                                        <span>$48.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Gel Rửa Mặt Tràm Trà Kháng Viêm</h6>
                                        <span>$18.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Tinh Chất Trẻ Hóa Retinol 0.5%</h6>
                                        <span>$58.00</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-6"">
                    <div class=""latest-product__text"">
                        <h4>Đánh giá cao</h4>
                        <div class=""latest-product__slider owl-carousel"">
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Combo Chăm Sóc Da Căn Bản Trắng Hồng</h6>
                                        <span>$55.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Serum Cấp Nước Phục Hồi B5 & HA</h6>
                                        <span>$38.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Kem Chống Nắng Phổ Rộng SPF50+</h6>
                                        <span>$35.00</span>
                                    </div>
                                </a>
                            </div>
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Mặt Nạ Đất Sét Tràm Trà Kiềm Dầu</h6>
                                        <span>$28.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Tẩy Tế Bào Chết Cà Phê Cúc La Mã</h6>
                                        <span>$25.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Nước Tẩy Trang Hoa Hồng Dịu Nhẹ</h6>
                                        <span>$22.00</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-6"">
                    <div class=""latest-product__text"">
                        <h4>Bán chạy nhất</h4>
                        <div class=""latest-product__slider owl-carousel"">
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Tẩy Tế Bào Chết Cà Phê Cúc La Mã</h6>
                                        <span>$25.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Nước Tẩy Trang Trà Xanh Green Tea</h6>
                                        <span>$18.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Mặt Nạ Thảo Dược Tràm Trà</h6>
                                        <span>$28.00</span>
                                    </div>
                                </a>
                            </div>
                            <div class=""latest-prdouct__slider__item"">
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-1.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Son Dưỡng Gấc & Dầu Dừa Tự Nhiên</h6>
                                        <span>$18.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-2.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Tinh Dầu Trị Liệu Oải Hương & Tràm</h6>
                                        <span>$32.00</span>
                                    </div>
                                </a>
                                <a href=""shop-details.html"" class=""latest-product__item"">
                                    <div class=""latest-product__item__pic"">
                                        <img src=""Images/latest-product/lp-3.jpg"" alt="""">
                                    </div>
                                    <div class=""latest-product__item__text"">
                                        <h6>Bộ Kit Dưỡng Ẩm Du Lịch 4 Món</h6>
                                        <span>$29.00</span>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""latest-product spad"">[\s\S]*?</section>", latestProductsSection);

        // Blog Section in Home Page
        string homeBlog = @"
    <section class=""from-blog spad"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-lg-12"">
                    <div class=""section-title from-blog__title"">
                        <h2>Cẩm nang làm đẹp</h2>
                    </div>
                </div>
            </div>
            <div class=""row"">
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-1.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 24 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 18</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Bí quyết cấp ẩm sâu cho làn da căng bóng mướt mịn chuẩn Hàn</a></h5>
                            <p>Hướng dẫn chi tiết các bước skincare cấp nước tầng sâu với Hyaluronic Acid và B5 giúp làn da ngậm nước suốt 24 giờ...</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-2.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 20 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 25</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Routine 4 bước chăm sóc da mụn nhạy cảm phục hồi tức thì</a></h5>
                            <p>Chăm sóc da mụn cần sự tối giản nhưng hiệu quả cao. Bí quyết làm sạch dịu nhẹ và kháng viêm từ chiết xuất tràm trà...</p>
                        </div>
                    </div>
                </div>
                <div class=""col-lg-4 col-md-4 col-sm-6"">
                    <div class=""blog__item"">
                        <div class=""blog__item__pic"">
                            <img src=""Images/blog/blog-3.jpg"" alt="""">
                        </div>
                        <div class=""blog__item__text"">
                            <ul>
                                <li><i class=""fa fa-calendar-o""></i> 15 Tháng 5, 2026</li>
                                <li><i class=""fa fa-comment-o""></i> 12</li>
                            </ul>
                            <h5><a href=""blog-details.html"">Tinh hoa làm đẹp từ dầu ô liu và thảo mộc tự nhiên Dola Spa</a></h5>
                            <p>Khám phá công thức dưỡng ẩm chống lão hóa từ thảo mộc thiên nhiên mang lại sức sống tươi trẻ và rạng ngời cho phái đẹp...</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>";
        html = Regex.Replace(html, @"<section class=""from-blog spad"">[\s\S]*?</section>", homeBlog);

        Save("index.html", html);
    }
}
