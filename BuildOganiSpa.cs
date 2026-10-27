using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class BuildOganiSpa {
    static void Main() {
        var utf8 = new UTF8Encoding(true);

        // 1. Process contact.html
        if (File.Exists("raw_contact.html")) {
            string contact = File.ReadAllText("raw_contact.html", Encoding.UTF8);
            contact = FixCommon(contact);
            contact = contact.Replace("+01-3-8888-6868", "1900 6750");
            contact = contact.Replace("60-49 Road 11378 New York", "128 Nguy\u1ec5n \u0110\u00ecnh Chi\u1ec3u, Qu\u1eadn 3, TP.HCM");
            contact = contact.Replace("10:00 am to 23:00 pm", "08:00 am - 21:30 pm (C\u1ea3 tu\u1ea7n)");
            contact = contact.Replace("New York", "Dola Spa TP.HCM");
            contact = contact.Replace("+12-345-6789", "1900 6750");
            contact = contact.Replace("16 Creek Ave. Farmingdale, NY", "128 Nguy\u1ec5n \u0110\u00ecnh Chi\u1ec3u, P. V\u00f5 Th\u1ecb S\u00e1u, Qu\u1eadn 3");
            File.WriteAllText("contact.html", contact, utf8);
            Console.WriteLine("Built contact.html");
        }

        // 2. Process shop-grid.html
        if (File.Exists("raw_shop-grid.html")) {
            string grid = File.ReadAllText("raw_shop-grid.html", Encoding.UTF8);
            grid = FixCommon(grid);
            grid = BuildShopGridContent(grid);
            File.WriteAllText("shop-grid.html", grid, utf8);
            Console.WriteLine("Built shop-grid.html");
        }

        // 3. Process index.html
        if (File.Exists("raw_index.html")) {
            string index = File.ReadAllText("raw_index.html", Encoding.UTF8);
            index = FixCommon(index);
            index = BuildIndexContent(index);
            File.WriteAllText("index.html", index, utf8);
            Console.WriteLine("Built index.html");
        }

        // 4. Process shop-details.html
        if (File.Exists("raw_shop-details.html")) {
            string details = File.ReadAllText("raw_shop-details.html", Encoding.UTF8);
            details = FixCommon(details);
            details = BuildShopDetailsContent(details);
            File.WriteAllText("shop-details.html", details, utf8);
            Console.WriteLine("Built shop-details.html");
        }

        // 5. Process shoping-cart.html
        if (File.Exists("raw_shoping-cart.html")) {
            string cart = File.ReadAllText("raw_shoping-cart.html", Encoding.UTF8);
            cart = FixCommon(cart);
            cart = BuildCartContent(cart);
            File.WriteAllText("shoping-cart.html", cart, utf8);
            Console.WriteLine("Built shoping-cart.html");
        }

        // 6. Process checkout.html
        if (File.Exists("raw_checkout.html")) {
            string checkout = File.ReadAllText("raw_checkout.html", Encoding.UTF8);
            checkout = FixCommon(checkout);
            checkout = BuildCheckoutContent(checkout);
            File.WriteAllText("checkout.html", checkout, utf8);
            Console.WriteLine("Built checkout.html");
        }

        // 7. Process blog.html & blog-details.html
        if (File.Exists("raw_blog.html")) {
            string blog = File.ReadAllText("raw_blog.html", Encoding.UTF8);
            blog = FixCommon(blog);
            blog = BuildBlogContent(blog);
            File.WriteAllText("blog.html", blog, utf8);
            Console.WriteLine("Built blog.html");
        }

        if (File.Exists("raw_blog-details.html")) {
            string blogDetails = File.ReadAllText("raw_blog-details.html", Encoding.UTF8);
            blogDetails = FixCommon(blogDetails);
            File.WriteAllText("blog-details.html", blogDetails, utf8);
            Console.WriteLine("Built blog-details.html");
        }

        Console.WriteLine("ALL 8 OGANI SPA PAGES BUILT SUCCESSFULLY!");
    }

    static string FixCommon(string html) {
        // Assets paths per PDF
        html = html.Replace("href=\"css/", "href=\"Styles/");
        html = html.Replace("src=\"js/", "src=\"Scripts/");
        html = html.Replace("src=\"img/", "src=\"Images/");
        html = html.Replace("data-setbg=\"img/", "data-setbg=\"Images/");

        // Header and branding
        html = html.Replace("Ogani | Template", "Dola Spa & Cosmetics | M\u1ef9 Ph\u1ea9m & Spa Tr\u1ecb Li\u1ec7u Thi\u00ean Nhi\u00ean");
        html = html.Replace("Ogani", "Dola Spa");
        html = html.Replace("ORGANIC", "DOLA SPA");
        html = html.Replace("hello@colorlib.com", "cskh@dolaspa.vn");
        html = html.Replace("Free Shipping for all Order of $99", "Mi\u1ec5n ph\u00ed giao h\u00e0ng cho \u0111\u01a1n t\u1eeb $50");
        html = html.Replace("English", "Ti\u1ebfng Vi\u1ec7t");
        html = html.Replace("Spanish", "English");
        html = html.Replace("Login", "\u0110\u0103ng nh\u1eadp");
        html = html.Replace("+65 11.188.888", "1900 6750");
        html = html.Replace("support 24/7 time", "H\u1ed7 tr\u1ee3 24/7");

        // Search & categories bar
        html = html.Replace("What do yo u need?", "B\u1ea1n \u0111ang t\u00ecm m\u1ef9 ph\u1ea9m g\u00ec?");
        html = html.Replace("All Categories", "T\u1ea5t c\u1ea3 danh m\u1ee5c");
        html = html.Replace(">SEARCH<", ">T\u00ccM KI\u1ebeM<");
        html = html.Replace("Check Out", "Thanh To\u00e1n");

        // Contact Us breadcrumbs & widgets
        html = html.Replace("<h2>Contact Us</h2>", "<h2>Li\u00ean H\u1ec7</h2>");
        html = html.Replace("<span>Contact Us</span>", "<span>Li\u00ean H\u1ec7</span>");
        html = html.Replace("<h4>Phone</h4>", "<h4>S\u1ed1 \u0111i\u1ec7n tho\u1ea1i</h4>");
        html = html.Replace("<h4>Address</h4>", "<h4>\u0110\u1ecba ch\u1ec9 Spa</h4>");
        html = html.Replace("<h4>Open time</h4>", "<h4>Gi\u1edd m\u1edf c\u1eeda</h4>");
        html = html.Replace("<h4>Email</h4>", "<h4>\u0110\u1ecba ch\u1ec9 Email</h4>");
        html = html.Replace("Leave Message", "G\u1eedi Tin Nh\u1eafn Cho Dola Spa");
        html = html.Replace("Your name", "H\u1ecd v\u00e0 t\u00ean c\u1ee7a b\u1ea1n");
        html = html.Replace("Your Email", "Email c\u1ee7a b\u1ea1n");
        html = html.Replace("Your message", "N\u1ed9i dung c\u1ea7n t\u01b0 v\u1ea5n l\u00e0m \u0111\u1eb9p...");
        html = html.Replace("SEND MESSAGE", "G\u1eecI TIN NH\u1eaeN");

        // Menu items
        html = html.Replace(">Home<", ">Trang Ch\u1ee7<");
        html = html.Replace(">Shop<", ">C\u1eeda H\u00e0ng<");
        html = html.Replace(">Pages<", ">Trang<");
        html = html.Replace(">Blog<", ">C\u1ea9m Nang Spa<");
        html = html.Replace(">Contact<", ">Li\u00ean H\u1ec7<");
        html = html.Replace(">Shop Details<", ">Chi Ti\u1ebft S\u1ea3n Ph\u1ea9m<");
        html = html.Replace(">Shoping Cart<", ">Gi\u1ecf H\u00e0ng<");
        html = html.Replace(">Checkout<", ">Thanh To\u00e1n<");
        html = html.Replace(">Blog Details<", ">Chi Ti\u1ebft B\u00e0i Vi\u1ebft<");

        // Department / Categories
        html = html.Replace("All departments", "Danh m\u1ee5c m\u1ef9 ph\u1ea9m");
        html = html.Replace("Department", "Danh m\u1ee5c s\u1ea3n ph\u1ea9m");
        html = html.Replace("Fresh Meat", "Ch\u0103m S\u00f3c Da M\u1eb7t");
        html = html.Replace("Vegetables", "T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft");
        html = html.Replace("Fruit & Nut Gifts", "Serum & Tinh Ch\u1ea5t");
        html = html.Replace("Fresh Berries", "Kem D\u01b0\u1ee1ng \u1ea8m");
        html = html.Replace("Ocean Foods", "Ch\u1ed1ng N\u1eafng Ph\u1ed5 R\u1ed9ng");
        html = html.Replace("Butter & Eggs", "M\u1eb7t N\u1ea1 Th\u1ea3o D\u01b0\u1ee3c");
        html = html.Replace("Fastfood", "N\u01b0\u1edbc T\u1ea9y Trang");
        html = html.Replace("Fresh Onion", "Son D\u01b0\u1ee1ng T\u1ef1 Nhi\u00ean");
        html = html.Replace("Papayaya & Crisps", "Tinh D\u1ea7u Tr\u1ecb Li\u1ec7u");
        html = html.Replace("Oatmeal", "Combo Ti\u1ebft Ki\u1ec7m");
        html = html.Replace("Fresh Bananas", "D\u01b0\u1ee1ng M\u00f4i & Mi");

        // Footer & Common elements
        html = html.Replace("Address: 60-49 Road 11378 New York", "\u0110\u1ecba ch\u1ec9: 128 Nguy\u1ec5n \u0110\u00ecnh Chi\u1ec3u, Qu\u1eadn 3, TP.HCM");
        html = html.Replace("Useful Links", "Li\u00ean K\u1ebft H\u1eefu \u00cdch");
        html = html.Replace("About Us", "V\u1ec1 Dola Spa");
        html = html.Replace("About Our Shop", "V\u1ec1 M\u1ef9 Ph\u1ea9m");
        html = html.Replace("Secure Shopping", "Mua S\u1eafm An To\u00e0n");
        html = html.Replace("Delivery infomation", "Ch\u00ednh S\u00e1ch Giao H\u00e0ng");
        html = html.Replace("Privacy Policy", "Ch\u00ednh S\u00e1ch B\u1ea3o M\u1eadt");
        html = html.Replace("Our Sitemap", "S\u01a1 \u0110\u1ed3 Trang");
        html = html.Replace("Who We Are", "\u0110\u1ed9i Ng\u0169 Chuy\u00ean Vi\u00ean");
        html = html.Replace("Our Services", "D\u1ecbch V\u1ee5 Spa");
        html = html.Replace("Projects", "Li\u1ec7u Tr\u00ecnh Chuy\u00ean S\u00e2u");
        html = html.Replace("Testimonials", "C\u1ea3m Nh\u1eadn Kh\u00e1ch H\u00e0ng");
        html = html.Replace("Innovation", "C\u00f4ng Ngh\u1ec7 M\u1edbi");
        html = html.Replace("Join Our Newsletter Now", "\u0110\u0103ng K\u00fd Nh\u1eadn B\u1ea3n Tin \u01afu \u0110\u00e3i");
        html = html.Replace("Get E-mail updates about our latest shop and special offers.", "Nh\u1eadn ngay voucher gi\u1ea3m gi\u00e1 20% cho \u0111\u01a1n h\u00e0ng m\u1ef9 ph\u1ea9m \u0111\u1ea7u ti\u00ean.");
        html = html.Replace("Subscribe", "\u0110\u0103ng K\u00fd");
        html = html.Replace("Enter your mail", "Nh\u1eadp email c\u1ee7a b\u1ea1n...");
        html = html.Replace("item: <span>$150.00</span>", "m\u00f3n: <span>$150.00</span>");

        return html;
    }

    static string BuildShopGridContent(string html) {
        // Sidebar terms
        html = html.Replace("Price", "Kho\u1ea3ng gi\u00e1");
        html = html.Replace("Colors", "Tone da / Lo\u1ea1i da");
        html = html.Replace("White", "Tr\u1eafng s\u00e1ng");
        html = html.Replace("Gray", "Da kh\u00f4");
        html = html.Replace("Red", "H\u1ed3ng h\u00e0o");
        html = html.Replace("Black", "M\u1ee5n c\u00e1m");
        html = html.Replace("Blue", "Nh\u1ea1y c\u1ea3m");
        html = html.Replace("Green", "Da d\u1ea7u");
        html = html.Replace("Popular Size", "Dung t\u00edch");
        html = html.Replace("Large", "200ml");
        html = html.Replace("Medium", "100ml");
        html = html.Replace("Small", "50ml");
        html = html.Replace("Tiny", "30ml");
        html = html.Replace("Products found", "S\u1ea3n ph\u1ea9m t\u00ecm th\u1ea5y");
        html = html.Replace("Sort By", "S\u1eafp x\u1ebfp theo");
        html = html.Replace("Default", "M\u1eb7c \u0111\u1ecbnh");

        // Sale Off block matching screenshot
        string saleOffCustom = @"
<div class=""product__discount"">
    <div class=""section-title product__discount__title"">
        <h2>Sale Off</h2>
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
                        <span>Ch\u0103m s\u00f3c da m\u1eb7t</span>
                        <h5><a href=""shop-details.html"">Combo D\u01b0\u1ee1ng Tr\u1eafng H\u1ed3ng Tr\u00e0 Xanh</a></h5>
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
                        <span>Serum chuy\u00ean s\u00e2u</span>
                        <h5><a href=""shop-details.html"">Serum C\u1ea5p N\u01b0\u1edbc Ph\u1ee5c H\u1ed3i B5 & HA</a></h5>
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
                        <span>T\u1ea9y t\u1ebf b\u00e0o ch\u1ebft</span>
                        <h5><a href=""shop-details.html"">T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft C\u00e0 Ph\u00ea C\u00fac La M\u00e3</a></h5>
                        <div class=""product__item__price"">$30.00 <span>$36.00</span></div>
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
                        <span>L\u00e0m s\u1ea1ch da</span>
                        <h5><a href=""shop-details.html"">N\u01b0\u1edbc T\u1ea9y Trang D\u1ecbu Nh\u1eb9 Green Tea</a></h5>
                        <div class=""product__item__price"">$18.00 <span>$24.00</span></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>";

        saleOffCustom = Regex.Unescape(saleOffCustom);

        // Replace the Sale Off block
        var saleOffRegex = new Regex(@"<div class=""product__discount"">[\s\S]*?</div>\s*</div>\s*</div>\s*</div>", RegexOptions.IgnoreCase);
        if (saleOffRegex.IsMatch(html)) {
            html = saleOffRegex.Replace(html, saleOffCustom, 1);
        }

        // Main 16 Products Grid
        string mainProductsGrid = @"
<div class=""filter__item"">
    <div class=""row"">
        <div class=""col-lg-4 col-md-5"">
            <div class=""filter__sort"">
                <span>S\u1eafp x\u1ebfp theo</span>
                <select>
                    <option value=""0"">M\u1eb7c \u0111\u1ecbnh</option>
                    <option value=""1"">Gi\u00e1 t\u0103ng d\u1ea7n</option>
                    <option value=""2"">Gi\u00e1 gi\u1ea3m d\u1ea7n</option>
                    <option value=""3"">B\u00e1n ch\u1ea1y nh\u1ea5t</option>
                </select>
            </div>
        </div>
        <div class=""col-lg-4 col-md-4"">
            <div class=""filter__found"">
                <h6><span>16</span> S\u1ea3n ph\u1ea9m t\u00ecm th\u1ea5y</h6>
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
                <h6><a href=""shop-details.html"">T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft C\u00e0 Ph\u00ea C\u00fac La M\u00e3</a></h6>
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
                <h6><a href=""shop-details.html"">Son D\u01b0\u1ee1ng M\u00f4i M\u00e0u \u0110\u1ecf Cam T\u1ef1 Nhi\u00ean</a></h6>
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
                <h6><a href=""shop-details.html"">Combo Ch\u0103m S\u00f3c Da C\u0103n B\u1ea3n Tr\u1eafng H\u1ed3ng</a></h6>
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
                <h6><a href=""shop-details.html"">N\u01b0\u1edbc T\u1ea9y Trang Tr\u00e0 Xanh Green Tea Pure</a></h6>
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
                <h6><a href=""shop-details.html"">Serum C\u1ea5p N\u01b0\u1edbc Ph\u1ee5c H\u1ed3i Da B5 & HA</a></h6>
                <h5>$35.00</h5>
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
                <h6><a href=""shop-details.html"">Kem Ch\u1ed1ng N\u1eafng Ph\u1ed5 R\u1ed9ng Th\u1ea3o D\u01b0\u1ee3c SPF50+</a></h6>
                <h5>$28.00</h5>
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
                <h6><a href=""shop-details.html"">M\u1eb7t N\u1ea1 \u0110\u1ea5t S\u00e9t Kho\u00e1ng Tro N\u00fai L\u1eeda</a></h6>
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
                <h6><a href=""shop-details.html"">Tinh Ch\u1ea5t D\u01b0\u1ee1ng Tr\u1eafng Vitamin C 15%</a></h6>
                <h5>$49.00</h5>
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
                <h6><a href=""shop-details.html"">Dung M\u00f4i Khu\u1ebfch T\u00e1n Tinh D\u1ea7u B\u01b0\u1edfi S\u1ea3</a></h6>
                <h5>$12.00</h5>
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
                <h6><a href=""shop-details.html"">X\u1ecbt Kho\u00e1ng T\u1ebf B\u00e0o G\u1ed1c Hoa Sen C\u1ea5p \u1ea8m</a></h6>
                <h5>$16.00</h5>
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
                <h6><a href=""shop-details.html"">Kem D\u01b0\u1ee1ng \u1ea8m Ph\u1ee5c H\u1ed3i Ceramide & B5</a></h6>
                <h5>$32.00</h5>
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
                <h6><a href=""shop-details.html"">S\u1eefa R\u1eeda M\u1eb7t D\u1ecbu Nh\u1eb9 Rau M\u00e1 L\u00ean Men</a></h6>
                <h5>$15.00</h5>
            </div>
        </div>
    </div>
</div>";

        mainProductsGrid = Regex.Unescape(mainProductsGrid);
        var filterBlockRegex = new Regex(@"<div class=""filter__item"">[\s\S]*?<div class=""product__pagination"">", RegexOptions.IgnoreCase);
        if (filterBlockRegex.IsMatch(html)) {
            html = filterBlockRegex.Replace(html, mainProductsGrid + "\n<div class=\"product__pagination\">", 1);
        }

        return html;
    }

    static string BuildIndexContent(string html) {
        // Hero texts
        html = html.Replace("FRUIT FRESH", "M\u1ef8 PH\u1ea8M THU\u1ea6N CHAY");
        html = html.Replace("Vegetable <br />100% Organic", "Dola Spa <br />M\u1ef9 Ph\u1ea9m Thi\u00ean Nhi\u00ean");
        html = html.Replace("Free Pickup and Delivery Available", "Chi\u1ebft xu\u1ea5t 100% th\u1ea3o m\u1ed9c h\u1eefu c\u01a1 cho l\u00e0n da c\u0103ng b\u00f3ng m\u01b0\u1edbt m\u1ecbn");
        html = html.Replace("SHOP NOW", "MUA S\u1eaeM NGAY");
        html = html.Replace("What do yo u need?", "B\u1ea1n \u0111ang t\u00ecm m\u1ef9 ph\u1ea9m g\u00ec?");
        html = html.Replace("SEARCH", "T\u00ccM KI\u1ebeM");

        // Categories Slider Names
        html = html.Replace("Fresh Fruit", "D\u01b0\u1ee1ng Da M\u1eb7t");
        html = html.Replace("Dried Fruit", "T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft");
        html = html.Replace("Vegetables", "Serum & Kem");
        html = html.Replace("drink fruits", "M\u1eb7t N\u1ea1 Th\u1ea3o D\u01b0\u1ee3c");

        // Featured filters
        html = html.Replace("Featured Product", "S\u1ea3n Ph\u1ea9m N\u1ed5i B\u1eadt");
        html = html.Replace(">All<", ">T\u1ea5t C\u1ea3<");
        html = html.Replace(">Oranges<", ">D\u01b0\u1ee1ng Da<");
        html = html.Replace(">Fresh Meat<", ">L\u00e0m S\u1ea1ch<");
        html = html.Replace(">Fastfood<", ">Son & Makeup<");

        // Featured item names
        html = html.Replace("Crab Pool Security", "T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft C\u00e0 Ph\u00ea C\u00fac La M\u00e3");

        // Latest products block
        html = html.Replace("Latest Products", "S\u1ea3n ph\u1ea9m m\u1edbi nh\u1ea5t");
        html = html.Replace("Top Rated Products", "\u0110\u00e1nh gi\u00e1 cao");
        html = html.Replace("Review Products", "B\u00e1n ch\u1ea1y nh\u1ea5t");

        // Blog section
        html = html.Replace("From The Blog", "C\u1ea9m nang l\u00e0m \u0111\u1eb9p");
        html = html.Replace("Cooking tips make cooking simple", "B\u00ed quy\u1ebft c\u1ea5p \u1ea9m s\u00e2u cho l\u00e0n da c\u0103ng b\u00f3ng m\u01b0\u1edbt m\u1ecbn chu\u1ea9n H\u00e0n");
        html = html.Replace("6 ways to prepare breakfast for 30", "Routine 4 b\u01b0\u1edbc ch\u0103m s\u00f3c da m\u1ee5n nh\u1ea1y c\u1ea3m ph\u1ee5c h\u1ed3i t\u1ee9c th\u00ec");
        html = html.Replace("Visit the clean farm in the US", "Tinh hoa l\u00e0m \u0111\u1eb9p t\u1eeb qu\u1ea3 \u00f4 liu v\u00e0 th\u1ea3o m\u1ed9c t\u1ef1 nhi\u00ean");

        return html;
    }

    static string BuildShopDetailsContent(string html) {
        html = html.Replace("Vetgetables\u2019 package", "Combo Ch\u0103m S\u00f3c Da C\u0103n B\u1ea3n Tr\u1eafng H\u1ed3ng");
        html = html.Replace("(18 reviews)", "(148 \u0111\u00e1nh gi\u00e1 kh\u00e1ch h\u00e0ng)");
        html = html.Replace("ADD TO CART", "TH\u00caM V\u00c0O GI\u1ece H\u00c0NG");
        html = html.Replace("Availability", "T\u00ecnh tr\u1ea1ng");
        html = html.Replace("In Stock", "C\u00f2n h\u00e0ng");
        html = html.Replace("Shipping", "V\u1eadn chuy\u1ec3n");
        html = html.Replace("01 day shipping. Free pickup today", "Giao h\u00e0ng h\u1ecfa t\u1ed1c 24h. Mi\u1ec5n ph\u00ed t\u1eeb $50");
        html = html.Replace("Weight", "Dung t\u00edch");
        html = html.Replace("0.5 kg", "150ml");
        html = html.Replace("Share on", "Chia s\u1ebb");
        html = html.Replace("Description", "M\u00f4 t\u1ea3 s\u1ea3n ph\u1ea9m");
        html = html.Replace("Information", "Th\u00e0nh ph\u1ea7n & C\u00f4ng d\u1ee5ng");
        html = html.Replace("Reviews (1)", "\u0110\u00e1nh gi\u00e1 (148)");
        html = html.Replace("Products Infomation", "Th\u00f4ng Tin S\u1ea3n Ph\u1ea9m");
        html = html.Replace("Related Product", "S\u1ea3n Ph\u1ea9m Li\u00ean Quan");
        return html;
    }

    static string BuildCartContent(string html) {
        html = html.Replace("Shopping Cart", "Gi\u1ecf H\u00e0ng C\u1ee7a B\u1ea1n");
        html = html.Replace("Products", "S\u1ea3n ph\u1ea9m");
        html = html.Replace("Price", "\u0110\u01a1n gi\u00e1");
        html = html.Replace("Quantity", "S\u1ed1 l\u01b0\u1ee3ng");
        html = html.Replace("Total", "Th\u00e0nh ti\u1ec1n");
        html = html.Replace("Vegetable\u2019s Package", "Combo Ch\u0103m S\u00f3c Da C\u0103n B\u1ea3n Tr\u1eafng H\u1ed3ng");
        html = html.Replace("Fresh Garden Vegetable", "Serum C\u1ea5p N\u01b0\u1edbc Ph\u1ee5c H\u1ed3i B5 & HA");
        html = html.Replace("Organic Bananas", "N\u01b0\u1edbc T\u1ea9y Trang D\u1ecbu Nh\u1eb9 Green Tea");
        html = html.Replace("CONTINUE SHOPPING", "TI\u1ebeP T\u1ee4C MUA S\u1eaeM");
        html = html.Replace("UPDATE CART", "C\u1eacP NH\u1eacT GI\u1ece H\u00c0NG");
        html = html.Replace("Cart Total", "T\u1ed5ng Ti\u1ec1n Gi\u1ecf H\u00e0ng");
        html = html.Replace("Subtotal", "T\u1ea1m t\u00ednh");
        html = html.Replace("Apply Coupon", "\u00c1p D\u1ee5ng M\u00e3");
        html = html.Replace("APPLY COUPON", "\u00c1P D\u1ee4NG");
        html = html.Replace("PROCEED TO CHECKOUT", "TI\u1ebeN H\u00c0NH THANH TO\u00c1N");
        return html;
    }

    static string BuildCheckoutContent(string html) {
        html = html.Replace("Billing Details", "Th\u00f4ng Tin Thanh To\u00e1n");
        html = html.Replace("First Name", "H\u1ecd v\u00e0 t\u00ean \u0111\u1ec7m");
        html = html.Replace("Last Name", "T\u00ean");
        html = html.Replace("Country", "Qu\u1ed1c gia / Khu v\u1ef1c");
        html = html.Replace("Street Address", "\u0110\u1ecba ch\u1ec9 giao h\u00e0ng");
        html = html.Replace("Apartment, suite, unite ect (optinal)", "S\u1ed1 nh\u00e0, c\u0103n h\u1ed9, t\u00f2a nh\u00e0 (kh\u00f4ng b\u1eaft bu\u1ed9c)");
        html = html.Replace("Town/City", "T\u1ec9nh / Th\u00e0nh ph\u1ed1");
        html = html.Replace("Country/State", "Qu\u1eadn / Huy\u1ec7n");
        html = html.Replace("Postcode / ZIP", "M\u00e3 b\u01b0u \u0111i\u1ec7n");
        html = html.Replace("Phone", "S\u1ed1 \u0111i\u1ec7n tho\u1ea1i li\u00ean h\u1ec7");
        html = html.Replace("Email", "\u0110\u1ecba ch\u1ec9 Email");
        html = html.Replace("Order notes", "Ghi ch\u00fa \u0111\u01a1n h\u00e0ng");
        html = html.Replace("Notes about your order, e.g. special notes for delivery.", "Ghi ch\u00fa v\u1ec1 th\u1eddi gian giao ho\u1eb7c ch\u1ec9 d\u1eabn giao h\u00e0ng.");
        html = html.Replace("Your Order", "\u0110\u01a1n H\u00e0ng C\u1ee7a B\u1ea1n");
        html = html.Replace("Products", "S\u1ea3n ph\u1ea9m");
        html = html.Replace("Total", "T\u1ed5ng c\u1ed9ng");
        html = html.Replace("Subtotal", "T\u1ea1m t\u00ednh");
        html = html.Replace("Check Payment", "Thanh to\u00e1n khi nh\u1eadn h\u00e0ng (COD)");
        html = html.Replace("Paypal", "Chuy\u1ec3n kho\u1ea3n ng\u00e2n h\u00e0ng / VNPAY / MoMo");
        html = html.Replace("PLACE ORDER", "\u0110\u1eb6T H\u00c0NG NGAY");
        return html;
    }

    static string BuildBlogContent(string html) {
        html = html.Replace("Categories", "Chuy\u00ean m\u1ee5c l\u00e0m \u0111\u1eb9p");
        html = html.Replace("Recent News", "B\u00e0i vi\u1ebft m\u1edbi nh\u1ea5t");
        html = html.Replace("Search By", "T\u00ecm ki\u1ebfm theo th\u1ebb");
        html = html.Replace("All", "T\u1ea5t c\u1ea3");
        html = html.Replace("Beauty", "Ch\u0103m s\u00f3c da");
        html = html.Replace("Food", "M\u1ef9 ph\u1ea9m thuần chay");
        html = html.Replace("Life Style", "Phong c\u00e1ch s\u1ed1ng");
        html = html.Replace("Travel", "Tr\u1ecb li\u1ec7u Spa");
        return html;
    }
}
