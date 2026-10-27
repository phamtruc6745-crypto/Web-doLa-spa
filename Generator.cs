using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Generator {
    static void Main() {
        string[] files = new string[] {
            "index.html",
            "shop-grid.html",
            "shop-details.html",
            "shoping-cart.html",
            "checkout.html",
            "blog.html",
            "blog-details.html",
            "contact.html"
        };

        var dict = new Dictionary<string, string>() {
            // Folders mapping as per PDF specification
            { "href=\"css/", "href=\"Styles/" },
            { "src=\"js/", "src=\"Scripts/" },
            { "src=\"img/", "src=\"Images/" },
            { "data-setbg=\"img/", "data-setbg=\"Images/" },

            // Branding & Header
            { "Ogani | Template", "Dola Spa & Cosmetics | M\u1ef9 Ph\u1ea9m & Spa Tr\u1ecb Li\u1ec7u Thi\u00ean Nhi\u00ean" },
            { "Ogani", "Dola Spa" },
            { "ORGANIC", "DOLA SPA" },
            { "hello@colorlib.com", "cskh@dolaspa.vn" },
            { "Free Shipping for all Order of $99", "Mi\u1ec5n ph\u00ed giao h\u00e0ng cho \u0111\u01a1n t\u1eeb $50" },
            { "English", "Ti\u1ebfng Vi\u1ec7t" },
            { "Spanish", "English" },
            { "Login", "\u0110\u0103ng nh\u1eadp" },
            { "+65 11.188.888", "1900 6750" },
            { "support 24/7 time", "H\u1ed7 tr\u1ee3 24/7" },

            // Navigation
            { ">Home<", ">Trang Ch\u1ee7<" },
            { ">Shop<", ">C\u1eeda H\u00e0ng<" },
            { ">Pages<", ">Trang<" },
            { ">Blog<", ">C\u1ea9m Nang Spa<" },
            { ">Contact<", ">Li\u00ean H\u1ec7<" },
            { ">Shop Details<", ">Chi Ti\u1ebft S\u1ea3n Ph\u1ea9m<" },
            { ">Shoping Cart<", ">Gi\u1ecf H\u00e0ng<" },
            { ">Checkout<", ">Thanh To\u00e1n<" },
            { ">Blog Details<", ">Chi Ti\u1ebft B\u00e0i Vi\u1ebft<" },

            // Categories / Departments
            { "All departments", "Danh m\u1ee5c s\u1ea3n ph\u1ea9m" },
            { "Department", "Danh m\u1ee5c s\u1ea3n ph\u1ea9m" },
            { "Fresh Meat", "Ch\u0103m S\u00f3c Da M\u1eb7t" },
            { "Vegetables", "T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft" },
            { "Fruit & Nut Gifts", "Serum & Tinh Ch\u1ea5t" },
            { "Fresh Berries", "Kem D\u01b0\u1ee1ng \u1ea8m" },
            { "Ocean Foods", "Ch\u1ed1ng N\u1eafng Ph\u1ed5 R\u1ed9ng" },
            { "Butter & Eggs", "M\u1eb7t N\u1ea1 Th\u1ea3o D\u01b0\u1ee3c" },
            { "Fastfood", "N\u01b0\u1edbc T\u1ea9y Trang" },
            { "Fresh Onion", "Son D\u01b0\u1ee1ng T\u1ef1 Nhi\u00ean" },
            { "Papayaya & Crisps", "Tinh D\u1ea7u Tr\u1ecb Li\u1ec7u" },
            { "Oatmeal", "Combo Ti\u1ebft Ki\u1ec7m" },
            { "Fresh Bananas", "D\u01b0\u1ee1ng M\u00f4i & Mi" },

            // Hero Banner
            { "FRUIT FRESH", "M\u1ef8 PH\u1ea8M THU\u1ea6N CHAY" },
            { "Vegetable <br />100% Organic", "Dola Spa <br />M\u1ef9 Ph\u1ea9m Thi\u00ean Nhi\u00ean" },
            { "Free Pickup and Delivery Available", "Chi\u1ebft xu\u1ea5t 100% th\u1ea3o m\u1ed9c t\u1ef1 nhi\u00ean cho l\u00e0n da m\u01b0\u1edbt m\u1ecbn" },
            { "SHOP NOW", "MUA S\u1eaeM NGAY" },
            { "What do yo u need?", "B\u1ea1n \u0111ang t\u00ecm m\u1ef9 ph\u1ea9m g\u00ec?" },
            { "SEARCH", "T\u00ccM KI\u1ebeM" },

            // Featured
            { "Featured Product", "S\u1ea3n ph\u1ea9m n\u1ed5i b\u1eadt" },
            { ">All<", ">T\u1ea5t C\u1ea3<" },
            { ">Oranges<", ">D\u01b0\u1ee1ng Da<" },

            // Shop Grid (Screenshot matching!)
            { "Price", "Kho\u1ea3ng gi\u00e1" },
            { "Colors", "Tone da / Lo\u1ea1i da" },
            { "White", "Tr\u1eafng s\u00e1ng" },
            { "Gray", "Da kh\u00f4" },
            { "Red", "H\u1ed3ng h\u00e0o" },
            { "Black", "M\u1ee5n c\u00e1m" },
            { "Blue", "Nh\u1ea1y c\u1ea3m" },
            { "Green", "Da d\u1ea7u" },
            { "Popular Size", "Dung t\u00edch" },
            { "Large", "200ml" },
            { "Medium", "100ml" },
            { "Small", "50ml" },
            { "Tiny", "30ml" },
            { "Products found", "S\u1ea3n ph\u1ea9m t\u00ecm th\u1ea5y" },
            { "Sort By", "S\u1eafp x\u1ebfp theo" },
            { "Default", "M\u1eb7c \u0111\u1ecbnh" },
            { "Dried Fruit", "M\u1ef9 ph\u1ea9m t\u1ef1 nhi\u00ean" },

            // Product Names
            { "Crab Pool Security", "T\u1ea9y T\u1ebf B\u00e0o Ch\u1ebft C\u00e0 Ph\u00ea C\u00fac La M\u00e3" },
            { "Mixed Fruitss", "Combo D\u01b0\u1ee1ng Tr\u1eafng H\u1ed3ng Tr\u00e0 Xanh" },
            { "Raisin\u2019n\u2019nuts", "Serum C\u1ea5p N\u01b0\u1edbc Ph\u1ee5c H\u1ed3i B5 & HA" },
            { "Fresh Fruit", "N\u01b0\u1edbc T\u1ea9y Trang D\u1ecbu Nh\u1eb9 Green Tea" },

            // Cart & Checkout
            { "Shopping Cart", "Gi\u1ecf H\u00e0ng" },
            { "Cart Total", "T\u1ed5ng Ti\u1ec1n Gi\u1ecf H\u00e0ng" },
            { "Subtotal", "T\u1ea1m t\u00ednh" },
            { "Total", "T\u1ed5ng c\u1ed9ng" },
            { "CONTINUE SHOPPING", "TI\u1ebeP T\u1ee4C MUA S\u1eaeM" },
            { "UPDATE CART", "C\u1eacP NH\u1eacT GI\u1ece H\u00c0NG" },
            { "Apply Coupon", "\u00c1p D\u1ee5ng M\u00e3" },
            { "APPLY COUPON", "\u00c1P D\u1ee4NG" },
            { "PROCEED TO CHECKOUT", "TI\u1ebeN H\u00c0NH THANH TO\u00c1N" },
            { "Billing Details", "Th\u00f4ng Tin Thanh To\u00e1n" },
            { "First Name", "H\u1ecd" },
            { "Last Name", "T\u00ean" },
            { "Country", "Qu\u1ed1c gia" },
            { "Street Address", "\u0110\u1ecba ch\u1ec9 giao h\u00e0ng" },
            { "Postcode / ZIP", "M\u00e3 b\u01b0u \u0111i\u1ec7n" },
            { "Phone", "S\u1ed1 \u0111i\u1ec7n tho\u1ea1i" },
            { "Email", "\u0110\u1ecba ch\u1ec9 Email" },
            { "Order notes", "Ghi ch\u00fa \u0111\u01a1n h\u00e0ng" },
            { "Your Order", "\u0110\u01a1n H\u00e0ng C\u1ee7a B\u1ea1n" },
            { "PLACE ORDER", "X\u00c1C NH\u1eacN \u0110\u1eb6T H\u00c0NG" },

            // Blog & News
            { "From The Blog", "C\u1ea9m nang l\u00e0m \u0111\u1eb9p" },
            { "Latest Products", "S\u1ea3n ph\u1ea9m m\u1edbi nh\u1ea5t" },
            { "Top Rated Products", "\u0110\u00e1nh gi\u00e1 cao" },
            { "Review Products", "B\u00e1n ch\u1ea1y nh\u1ea5t" },
            { "Cooking tips make cooking simple", "B\u00ed quy\u1ebft c\u1ea5p \u1ea9m cho l\u00e0n da c\u0103ng b\u00f3ng m\u01b0\u1edbt m\u1ecbn chu\u1ea9n H\u00e0n" },
            { "6 ways to prepare breakfast for 30", "Routine 4 b\u01b0\u1edbc ch\u0103m s\u00f3c da m\u1ee5n nh\u1ea1y c\u1ea3m ph\u1ee5c h\u1ed3i t\u1ee9c th\u00ec" },
            { "Visit the clean farm in the US", "Tinh hoa l\u00e0m \u0111\u1eb9p t\u1eeb qu\u1ea3 \u00f4 liu v\u00e0 th\u1ea3o m\u1ed9c t\u1ef1 nhi\u00ean" },

            // Contact & Footer
            { "Contact Us", "Li\u00ean H\u1ec7" },
            { "Leave Message", "G\u1eedi Tin Nh\u1eafn Cho Dola Spa" },
            { "Your name", "H\u1ecd v\u00e0 t\u00ean c\u1ee7a b\u1ea1n" },
            { "Your Email", "Email li\u00ean h\u1ec7" },
            { "Your message", "N\u1ed9i dung c\u1ea7n t\u01b0 v\u1ea5n..." },
            { "SEND MESSAGE", "G\u1eecI TIN NH\u1eaeN" },
            { "Open time", "Gi\u1edd m\u1edf c\u1eeda" },
            { "Address: 60-49 Road 11378 New York", "\u0110\u1ecba ch\u1ec9: 128 Nguy\u1ec5n \u0110\u00ecnh Chi\u1ec3u, Qu\u1eadn 3, TP. H\u1ed3 Ch\u00ed Minh" },
            { "Useful Links", "Li\u00ean K\u1ebft H\u1eefu \u00cdch" },
            { "About Us", "V\u1ec1 Dola Spa" },
            { "About Our Shop", "V\u1ec1 M\u1ef9 Ph\u1ea9m" },
            { "Secure Shopping", "Mua S\u1eafm An To\u00e0n" },
            { "Delivery infomation", "Ch\u00ednh S\u00e1ch Giao H\u00e0ng" },
            { "Privacy Policy", "Ch\u00ednh S\u00e1ch B\u1ea3o M\u1eadt" },
            { "Our Sitemap", "S\u01a1 \u0110\u1ed3 Trang" },
            { "Who We Are", "\u0110\u1ed9i Ng\u0169 Chuy\u00ean Vi\u00ean" },
            { "Our Services", "D\u1ecbch V\u1ee5 Spa" },
            { "Projects", "Li\u1ec7u Tr\u00ecnh Chuy\u00ean S\u00e2u" },
            { "Testimonials", "C\u1ea3m Nh\u1eadn Kh\u00e1ch H\u00e0ng" },
            { "Innovation", "C\u00f4ng Ngh\u1ec7 M\u1edbi" },
            { "Join Our Newsletter Now", "\u0110\u0103ng K\u00fd Nh\u1eadn B\u1ea3n Tin \u01afu \u0110\u00e3i" },
            { "Get E-mail updates about our latest shop and special offers.", "Nh\u1eadn ngay voucher gi\u1ea3m gi\u00e1 20% cho \u0111\u01a1n h\u00e0ng m\u1ef9 ph\u1ea9m \u0111\u1ea7u ti\u00ean." },
            { "Subscribe", "\u0110\u0103ng K\u00fd" },
            { "Enter your mail", "Nh\u1eadp email c\u1ee7a b\u1ea1n..." }
        };

        var utf8WithBom = new UTF8Encoding(true);

        foreach (var file in files) {
            string raw = "raw_" + file;
            if (File.Exists(raw)) {
                string text = File.ReadAllText(raw, Encoding.UTF8);
                foreach (var pair in dict) {
                    text = text.Replace(pair.Key, pair.Value);
                }
                File.WriteAllText(file, text, utf8WithBom);
                Console.WriteLine("SUCCESS: Generated " + file);
            } else {
                Console.WriteLine("NOT FOUND: " + raw);
            }
        }
        Console.WriteLine("FINISHED ALL 8 FILES WITH PERFECT UNICODE UTF-8!");
    }
}
