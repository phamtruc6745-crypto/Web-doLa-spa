/**
 * DOLA SPA & COSMETICS - JAVASCRIPT APPLICATION
 * Xử lý: Giỏ hàng E-commerce, Modal xem nhanh, Đặt lịch hẹn, Lọc sản phẩm, Đếm ngược Flash sale
 */

// Danh sách sản phẩm đầy đủ với hình ảnh mỹ phẩm & người mẫu Châu Á chất lượng cao
const PRODUCTS_DATA = [
  {
    id: 1,
    name: 'Tẩy Tế Bào Chết Cà Phê & Cúc La Mã Rosetta',
    category: 'cleansing',
    categoryName: 'Làm sạch da',
    price: 120000,
    oldPrice: 160000,
    rating: 5,
    reviews: 148,
    badge: 'Bán chạy',
    badgeType: 'hot',
    image: 'https://images.unsplash.com/photo-1556228720-195a672e8a03?auto=format&fit=crop&w=700&q=80',
    description: 'Hạt scrub cà phê Đắk Lắk xay mịn kết hợp chiết xuất cúc La Mã dịu nhẹ giúp lấy đi lớp sừng già cỗi mà không làm rát da. Cho làn da sáng mịn, mềm mại tức thì ngay lần đầu sử dụng.',
    ingredients: 'Cà phê nguyên chất, Chiết xuất cúc La Mã, Dầu dừa ép lạnh, Vitamin E.'
  },
  {
    id: 2,
    name: 'Son Dưỡng Môi Thảo Mộc Màu Đỏ Cam Tự Nhiên',
    category: 'makeup',
    categoryName: 'Trang điểm tự nhiên',
    price: 180000,
    oldPrice: 220000,
    rating: 5,
    reviews: 215,
    badge: 'Mới',
    badgeType: 'new',
    image: 'https://images.unsplash.com/photo-1586495777744-4413f21062fa?auto=format&fit=crop&w=700&q=80',
    description: 'Son dưỡng có màu sắc tự nhiên chiết xuất từ củ dền và gấc đỏ. Giàu bơ hạt mỡ và dầu quả bơ giúp đôi môi căng bóng, xóa mờ rãnh môi và chống thâm môi hiệu quả.',
    ingredients: 'Bơ hạt mỡ hữu cơ, Dầu quả bơ, Dầu hạnh nhân, Màu khoáng tự nhiên.'
  },
  {
    id: 3,
    name: 'Combo Chăm Sóc Da Căn Bản Trắng Hồng Tinh Chất Trà Xanh',
    category: 'skincare',
    categoryName: 'Dưỡng da chuyên sâu',
    price: 530000,
    oldPrice: 680000,
    rating: 5,
    reviews: 320,
    badge: 'Tiết kiệm',
    badgeType: 'sale',
    image: 'https://images.unsplash.com/photo-1612817288484-6f916006741a?auto=format&fit=crop&w=700&q=80',
    description: 'Bộ combo 3 món thiết yếu: Nước hoa hồng cân bằng pH + Serum cấp ẩm sâu + Kem dưỡng ẩm khóa nước 48h. Thích hợp cho mọi loại da phụ nữ Việt, cải thiện tình trạng da sần sùi và xỉn màu.',
    ingredients: 'Chiết xuất trà xanh Bảo Lộc, Niacinamide 2%, Hyaluronic Acid, Ceramide NP.'
  },
  {
    id: 4,
    name: 'Nước Tẩy Trang Trà Xanh Green Tea Pure Kháng Khuẩn',
    category: 'cleansing',
    categoryName: 'Làm sạch da',
    price: 135000,
    oldPrice: 180000,
    rating: 5,
    reviews: 189,
    badge: 'Yêu thích',
    badgeType: 'hot',
    image: 'https://images.unsplash.com/photo-1571781926291-c477ebfd024b?auto=format&fit=crop&w=700&q=80',
    description: 'Công nghệ hạt Micellar hút sạch bụi mịn PM2.5, bã nhờn và cặn trang điểm lâu trôi. Chiết xuất lá trà xanh nguyên chất giúp làm dịu nốt mụn sưng đỏ và se khít lỗ chân lông.',
    ingredients: 'Trà xanh hữu cơ, Rau má (Centella), Chiết xuất tràm trà, Glycerin thực vật.'
  },
  {
    id: 5,
    name: 'Serum Cấp Nước Phục Hồi Da B5 & Hyaluronic Acid Dola',
    category: 'skincare',
    categoryName: 'Dưỡng da chuyên sâu',
    price: 350000,
    oldPrice: 450000,
    rating: 5,
    reviews: 412,
    badge: 'Best-Seller',
    badgeType: 'hot',
    image: 'https://images.unsplash.com/photo-1620916566398-39f1143ab7be?auto=format&fit=crop&w=700&q=80',
    description: 'Tinh chất phục hồi chuyên sâu chứa 5% Vitamin B5 (Panthenol) cùng đa tầng HA siêu thẩm thấu. Giảm kích ứng, phục hồi màng bảo vệ da hư tổn sau khi nặn mụn hoặc lăn kim tại spa.',
    ingredients: 'Vitamin B5 5%, 4 loại phân tử Hyaluronic Acid, Rau má lên men, Madecassoside.'
  },
  {
    id: 6,
    name: 'Kem Chống Nắng Phổ Rộng Thảo Dược Nâng Tông SPF50+',
    category: 'skincare',
    categoryName: 'Chống nắng & Bảo vệ',
    price: 280000,
    oldPrice: 340000,
    rating: 5,
    reviews: 265,
    badge: 'Mới',
    badgeType: 'new',
    image: 'https://images.unsplash.com/photo-1522337360788-8b13dee7a37e?auto=format&fit=crop&w=700&q=80',
    description: 'Kem chống nắng vật lý lai hóa học với màng lọc hiện đại chống tia UVA/UVB và ánh sáng xanh. Kết cấu mỏng nhẹ tựa lông vũ, nâng tông trắng hồng tự nhiên, kiềm dầu suốt 8 giờ.',
    ingredients: 'Zinc Oxide, Tinosorb S, Chiết xuất hoa cúc, Niacinamide, Dịch ốc sên.'
  },
  {
    id: 7,
    name: 'Mặt Nạ Đất Sét Khoáng Thải Độc Tro Núi Lửa & Trà Xanh',
    category: 'cleansing',
    categoryName: 'Làm sạch sâu',
    price: 220000,
    oldPrice: 280000,
    rating: 5,
    reviews: 176,
    badge: 'Đánh giá cao',
    badgeType: 'hot',
    image: 'https://images.unsplash.com/photo-1535585209827-a15fcdbc4c2d?auto=format&fit=crop&w=700&q=80',
    description: 'Đất sét Bentonite và bột trà xanh matcha thanh lọc độc tố tích tụ, hút sạch dầu thừa ở vùng chữ T, hỗ trợ gom cồi mụn đầu đen nhanh chóng mà không gây khô căng rát da.',
    ingredients: 'Đất sét Kaolin trắng, Tro núi lửa, Tinh bột trà xanh, Tinh dầu bạc hà tự nhiên.'
  },
  {
    id: 8,
    name: 'Tinh Chất Dưỡng Trắng & Mờ Nám Tàn Nhang Vitamin C 15%',
    category: 'skincare',
    categoryName: 'Dưỡng da chuyên sâu',
    price: 490000,
    oldPrice: 620000,
    rating: 5,
    reviews: 198,
    badge: 'Bán chạy',
    badgeType: 'sale',
    image: 'https://images.unsplash.com/photo-1617897903246-719242758050?auto=format&fit=crop&w=700&q=80',
    description: 'Công thức độc quyền kết hợp dẫn xuất Vitamin C 3-O-Ethyl Ascorbic Acid ổn định cao với Arbutin tinh khiết. Đánh bay vết thâm sau mụn, làm sáng da đều màu và kích thích tăng sinh collagen.',
    ingredients: 'Vitamin C 15%, Alpha Arbutin 2%, Ferulic Acid, Tinh chất vỏ cam hữu cơ.'
  }
];

// Danh sách sản phẩm Flash Sale Khuyến Mãi (PDF trang 3)
const PROMO_PRODUCTS = [
  {
    id: 101,
    name: 'Son Siêu Dưỡng Ẩm Vani - Dừa Nguyên Chất',
    price: 79000,
    oldPrice: 110000,
    discount: '-28%',
    sold: 142,
    totalStock: 180,
    rating: 5,
    reviews: 98,
    categoryName: 'Son & Dưỡng môi',
    description: 'Son siêu dưỡng chiết xuất từ tinh dầu dừa Bến Tre ép lạnh và hương vani dịu ngọt. Cấp ẩm sâu, xóa tan cảm giác môi khô nứt nẻ trong mùa hanh khô.',
    image: 'https://images.unsplash.com/photo-1586495777744-4413f21062fa?auto=format&fit=crop&w=600&q=80'
  },
  {
    id: 102,
    name: 'Nước Tẩy Trang Dịu Nhẹ Green Tea Chiết Xuất Tươi',
    price: 135000,
    oldPrice: 180000,
    discount: '-25%',
    sold: 210,
    totalStock: 250,
    rating: 5,
    reviews: 165,
    categoryName: 'Làm sạch da',
    description: 'Nước tẩy trang trà xanh tươi lành tính cho mọi loại da, hút sạch lớp trang điểm và bụi mịn PM2.5 mà vẫn giữ ẩm mướt mọng cho da.',
    image: 'https://images.unsplash.com/photo-1571781926291-c477ebfd024b?auto=format&fit=crop&w=600&q=80'
  },
  {
    id: 103,
    name: 'Dung Môi Khuếch Tán Tinh Dầu Bưởi & Sả Chanh Spa',
    price: 80000,
    oldPrice: 120000,
    discount: '-33%',
    sold: 95,
    totalStock: 120,
    rating: 5,
    reviews: 74,
    categoryName: 'Tinh dầu trị liệu',
    description: 'Dung môi khuếch tán tinh dầu chiết xuất bưởi hồng và sả chanh giúp thanh lọc không khí, giảm căng thẳng mệt mỏi và mang lại giấc ngủ sâu.',
    image: 'https://images.unsplash.com/photo-1608571423902-eed4a5ad8108?auto=format&fit=crop&w=600&q=80'
  },
  {
    id: 104,
    name: 'Candle Lighter - Đồ Đốt Nến Thơm USB Cao Cấp',
    price: 150000,
    oldPrice: 200000,
    discount: '-25%',
    sold: 78,
    totalStock: 100,
    rating: 5,
    reviews: 52,
    categoryName: 'Phụ kiện spa',
    description: 'Đồ đốt nến thơm tia plasma sạc cổng USB tiện dụng, chống gió, thiết kế thon dài an toàn và thanh lịch, món phụ kiện không thể thiếu cho góc chill tại gia.',
    image: 'https://images.unsplash.com/photo-1517841905240-472988babdf9?auto=format&fit=crop&w=600&q=80'
  }
];

// State Quản lý Giỏ hàng
let cart = JSON.parse(localStorage.getItem('dola_spa_cart')) || [
  { id: 1, name: 'Tẩy Tế Bào Chết Cà Phê & Cúc La Mã Rosetta', price: 120000, qty: 1, image: 'https://images.unsplash.com/photo-1556228720-195a672e8a03?auto=format&fit=crop&w=700&q=80' },
  { id: 4, name: 'Nước Tẩy Trang Trà Xanh Green Tea Pure Kháng Khuẩn', price: 135000, qty: 1, image: 'https://images.unsplash.com/photo-1571781926291-c477ebfd024b?auto=format&fit=crop&w=700&q=80' }
];

let wishlist = JSON.parse(localStorage.getItem('dola_spa_wishlist')) || [1, 5];

// Định dạng tiền tệ VND
function formatCurrency(amount) {
  return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(amount);
}

// Lưu giỏ hàng vào LocalStorage
function saveCart() {
  localStorage.setItem('dola_spa_cart', JSON.stringify(cart));
  updateCartUI();
}

// Cập nhật giao diện giỏ hàng
function updateCartUI() {
  const totalCount = cart.reduce((sum, item) => sum + item.qty, 0);
  const cartBadges = document.querySelectorAll('.cart-count-badge');
  cartBadges.forEach(badge => {
    badge.textContent = totalCount;
    badge.style.display = totalCount > 0 ? 'flex' : 'none';
  });

  const cartDrawerItems = document.getElementById('cartDrawerItems');
  const cartSubtotalEl = document.getElementById('cartSubtotal');
  
  if (!cartDrawerItems) return;

  if (cart.length === 0) {
    cartDrawerItems.innerHTML = `
      <div class="cart-empty-state">
        <i class="fa-solid fa-basket-shopping"></i>
        <h4 style="color: var(--color-navy); margin-bottom: 8px;">Giỏ hàng đang trống</h4>
        <p style="color: var(--color-text-muted); font-size: 0.88rem; margin-bottom: 20px;">Hãy chọn thêm sản phẩm chăm sóc da yêu thích của bạn nhé!</p>
        <button class="btn btn-primary btn-sm" onclick="closeCart(); document.getElementById('san-pham').scrollIntoView();">Mua sắm ngay</button>
      </div>
    `;
    if (cartSubtotalEl) cartSubtotalEl.textContent = formatCurrency(0);
    return;
  }

  let totalMoney = 0;
  cartDrawerItems.innerHTML = cart.map(item => {
    const itemTotal = item.price * item.qty;
    totalMoney += itemTotal;
    return `
      <div class="cart-item">
        <div class="cart-item-img">
          <img src="${item.image}" alt="${item.name}">
        </div>
        <div class="cart-item-details">
          <h4>${item.name}</h4>
          <div class="cart-item-price">${formatCurrency(item.price)}</div>
          <div class="cart-item-qty">
            <button class="qty-btn" onclick="changeQuantity(${item.id}, -1)">-</button>
            <input type="text" class="qty-input" value="${item.qty}" readonly>
            <button class="qty-btn" onclick="changeQuantity(${item.id}, 1)">+</button>
          </div>
        </div>
        <button class="btn-remove-item" onclick="removeFromCart(${item.id})" title="Xóa món này">
          <i class="fa-solid fa-trash-can"></i>
        </button>
      </div>
    `;
  }).join('');

  if (cartSubtotalEl) {
    cartSubtotalEl.textContent = formatCurrency(totalMoney);
  }
}

// Thêm sản phẩm vào giỏ hàng
function addToCart(productId, qty = 1) {
  let prod = PRODUCTS_DATA.find(p => p.id === productId);
  if (!prod) {
    prod = PROMO_PRODUCTS.find(p => p.id === productId);
  }
  if (!prod) return;

  const existingItem = cart.find(item => item.id === productId);
  if (existingItem) {
    existingItem.qty += qty;
  } else {
    cart.push({
      id: prod.id,
      name: prod.name,
      price: prod.price,
      qty: qty,
      image: prod.image
    });
  }

  saveCart();
  showToast(`Đã thêm "${prod.name}" vào giỏ hàng!`, 'fa-circle-check');
}

// Xóa sản phẩm khỏi giỏ hàng
function removeFromCart(productId) {
  const item = cart.find(i => i.id === productId);
  cart = cart.filter(i => i.id !== productId);
  saveCart();
  if (item) {
    showToast(`Đã xóa "${item.name}" khỏi giỏ hàng!`, 'fa-trash-can');
  }
}

// Thay đổi số lượng
function changeQuantity(productId, delta) {
  const item = cart.find(i => i.id === productId);
  if (!item) return;

  item.qty += delta;
  if (item.qty <= 0) {
    removeFromCart(productId);
  } else {
    saveCart();
  }
}

// Mở & Đóng Giỏ hàng
function openCart() {
  document.getElementById('cartDrawerOverlay')?.classList.add('open');
}

function closeCart() {
  document.getElementById('cartDrawerOverlay')?.classList.remove('open');
}

// Lọc sản phẩm theo danh mục
function filterProducts(category, btnElement) {
  const tabs = document.querySelectorAll('.tab-btn');
  tabs.forEach(tab => tab.classList.remove('active'));
  if (btnElement) btnElement.classList.add('active');

  const container = document.getElementById('productsGrid');
  if (!container) return;

  const filtered = category === 'all' 
    ? PRODUCTS_DATA 
    : PRODUCTS_DATA.filter(p => p.category === category);

  container.innerHTML = filtered.map(product => renderProductCard(product)).join('');
}

// Render HTML thẻ sản phẩm nổi bật
function renderProductCard(product) {
  const isWish = wishlist.includes(product.id);
  const starsHtml = '<i class="fa-solid fa-star"></i>'.repeat(product.rating);

  return `
    <div class="product-card" data-category="${product.category}">
      <div class="product-thumb-wrap">
        <img src="${product.image}" alt="${product.name}" class="product-thumb" loading="lazy">
        <div class="product-badge-group">
          <span class="p-badge p-badge-${product.badgeType}">${product.badge}</span>
        </div>
        <button class="product-wishlist-btn ${isWish ? 'active' : ''}" onclick="toggleWishlist(${product.id}, this)" title="Thêm vào yêu thích">
          <i class="${isWish ? 'fa-solid' : 'fa-regular'} fa-heart"></i>
        </button>
        <div class="product-overlay-actions">
          <button class="btn-quickview" onclick="openQuickView(${product.id})">
            <i class="fa-regular fa-eye"></i> Xem ngay
          </button>
        </div>
      </div>
      <div class="product-info">
        <span class="product-category">${product.categoryName}</span>
        <h4 class="product-name">
          <a href="javascript:void(0)" onclick="openQuickView(${product.id})">${product.name}</a>
        </h4>
        <div class="product-rating">
          <div class="stars">${starsHtml}</div>
          <span class="count">(${product.reviews} đánh giá)</span>
        </div>
        <div class="product-price-box">
          <span class="price-current">${formatCurrency(product.price)}</span>
          <span class="price-old">${formatCurrency(product.oldPrice)}</span>
        </div>
        <div class="product-card-actions">
          <button class="btn-add-cart" onclick="addToCart(${product.id})">
            <i class="fa-solid fa-bag-shopping"></i> Thêm vào giỏ
          </button>
          <button class="btn-view-quick" onclick="openQuickView(${product.id})" title="Xem chi tiết">
            <i class="fa-solid fa-arrow-up-right-from-square"></i>
          </button>
        </div>
      </div>
    </div>
  `;
}

// Render HTML sản phẩm khuyến mãi Flash Sale
function renderSaleProducts() {
  const container = document.getElementById('saleProductsGrid');
  if (!container) return;

  container.innerHTML = PROMO_PRODUCTS.map(item => {
    const percent = Math.round((item.sold / item.totalStock) * 100);
    return `
      <div class="sale-card">
        <div class="sale-card-thumb-wrap">
          <img src="${item.image}" alt="${item.name}" loading="lazy">
          <span class="sale-discount-tag">${item.discount}</span>
        </div>
        <div class="sale-card-body">
          <h4 class="sale-card-title">${item.name}</h4>
          <div class="sale-card-prices">
            <span class="sale-price-new">${formatCurrency(item.price)}</span>
            <span class="sale-price-old">${formatCurrency(item.oldPrice)}</span>
          </div>
          <div class="sale-progress-box">
            <div class="sale-progress-label">
              <span>Đã bán: ${item.sold}</span>
              <span>Còn lại: ${item.totalStock - item.sold}</span>
            </div>
            <div class="sale-progress-bar">
              <div class="sale-progress-fill" style="width: ${percent}%;"></div>
            </div>
          </div>
          <button class="btn btn-primary btn-block btn-sm" onclick="addToCart(${item.id})">
            <i class="fa-solid fa-cart-shopping"></i> Săn Deal Ngay
          </button>
        </div>
      </div>
    `;
  }).join('');
}

// Mở Modal Xem Nhanh Sản Phẩm (Quick View)
function openQuickView(productId) {
  let prod = PRODUCTS_DATA.find(p => p.id === productId);
  if (!prod) {
    prod = PROMO_PRODUCTS.find(p => p.id === productId);
  }
  if (!prod) return;

  const modalBody = document.getElementById('quickViewModalBody');
  if (!modalBody) return;

  const starsHtml = '<i class="fa-solid fa-star"></i>'.repeat(prod.rating || 5);

  modalBody.innerHTML = `
    <div class="quickview-grid">
      <div class="quickview-img">
        <img src="${prod.image}" alt="${prod.name}">
      </div>
      <div class="quickview-details">
        <span class="section-tag" style="margin-bottom: 8px;">Mỹ phẩm thiên nhiên</span>
        <h3>${prod.name}</h3>
        <div class="product-rating" style="margin-bottom: 12px;">
          <div class="stars">${starsHtml}</div>
          <span class="count">(${prod.reviews || 120} đánh giá khách hàng)</span>
        </div>
        <div class="quickview-price">${formatCurrency(prod.price)} <span style="font-size: 0.9rem; text-decoration: line-through; color: #94a3b8; margin-left: 8px;">${formatCurrency(prod.oldPrice)}</span></div>
        <p class="quickview-desc">${prod.description || 'Sản phẩm chăm sóc da thảo dược độc quyền từ Dola Spa, mang lại làn da sáng mịn và mướt mát tự nhiên.'}</p>
        
        <ul class="quickview-features">
          <li><i class="fa-solid fa-circle-check"></i> Chiết xuất 100% thảo mộc hữu cơ tự nhiên</li>
          <li><i class="fa-solid fa-circle-check"></i> Không cồn, không paraben, an toàn tuyệt đối</li>
          <li><i class="fa-solid fa-circle-check"></i> Được chuyên viên da liễu Dola Spa khuyên dùng</li>
        </ul>

        <div style="display: flex; gap: 12px; margin-top: auto;">
          <div class="cart-item-qty" style="padding: 6px 10px;">
            <button class="qty-btn" id="qvQtyMinus">-</button>
            <input type="text" id="qvQtyVal" class="qty-input" value="1" readonly>
            <button class="qty-btn" id="qvQtyPlus">+</button>
          </div>
          <button class="btn btn-primary" style="flex-grow: 1;" id="qvAddBtn">
            <i class="fa-solid fa-bag-shopping"></i> Thêm vào giỏ hàng
          </button>
        </div>
      </div>
    </div>
  `;

  // Gán sự kiện số lượng trong quick view
  let currentQty = 1;
  const qvQtyMinus = document.getElementById('qvQtyMinus');
  const qvQtyPlus = document.getElementById('qvQtyPlus');
  const qvQtyVal = document.getElementById('qvQtyVal');
  const qvAddBtn = document.getElementById('qvAddBtn');

  qvQtyMinus?.addEventListener('click', () => {
    if (currentQty > 1) {
      currentQty--;
      qvQtyVal.value = currentQty;
    }
  });

  qvQtyPlus?.addEventListener('click', () => {
    currentQty++;
    qvQtyVal.value = currentQty;
  });

  qvAddBtn?.addEventListener('click', () => {
    addToCart(prod.id, currentQty);
    closeQuickView();
  });

  document.getElementById('quickViewModalOverlay')?.classList.add('open');
}

function closeQuickView() {
  document.getElementById('quickViewModalOverlay')?.classList.remove('open');
}

// Mở & Đóng Modal Đặt Lịch Hẹn
function openBookingModal(serviceName = '') {
  const modal = document.getElementById('bookingModalOverlay');
  if (modal) {
    if (serviceName) {
      const select = document.getElementById('bookingService');
      if (select) {
        for (let i = 0; i < select.options.length; i++) {
          if (select.options[i].text.includes(serviceName)) {
            select.selectedIndex = i;
            break;
          }
        }
      }
    }
    modal.classList.add('open');
  }
}

function closeBookingModal() {
  document.getElementById('bookingModalOverlay')?.classList.remove('open');
}

// Xử lý gửi Form Đặt Lịch
function handleBookingSubmit(event) {
  event.preventDefault();
  const name = document.getElementById('bookingName')?.value;
  const phone = document.getElementById('bookingPhone')?.value;
  const branch = document.getElementById('bookingBranch')?.value;
  const service = document.getElementById('bookingService')?.value;
  const date = document.getElementById('bookingDate')?.value;

  if (!name || !phone) {
    showToast('Vui lòng điền họ tên và số điện thoại liên hệ!', 'fa-circle-exclamation');
    return;
  }

  closeBookingModal();
  showToast(`Cảm ơn bạn ${name}! Dola Spa sẽ gọi điện xác nhận lịch hẹn sớm nhất.`, 'fa-circle-check');
  event.target.reset();
}

// Yêu thích (Wishlist)
function toggleWishlist(productId, btnElement) {
  const index = wishlist.indexOf(productId);
  const heartIcon = btnElement.querySelector('i');
  
  if (index > -1) {
    wishlist.splice(index, 1);
    btnElement.classList.remove('active');
    heartIcon.classList.replace('fa-solid', 'fa-regular');
    showToast('Đã xóa khỏi danh sách yêu thích!', 'fa-heart');
  } else {
    wishlist.push(productId);
    btnElement.classList.add('active');
    heartIcon.classList.replace('fa-regular', 'fa-solid');
    showToast('Đã lưu vào danh sách yêu thích!', 'fa-heart');
  }
  
  localStorage.setItem('dola_spa_wishlist', JSON.stringify(wishlist));
  
  const wishBadges = document.querySelectorAll('.wish-count-badge');
  wishBadges.forEach(b => {
    b.textContent = wishlist.length;
    b.style.display = wishlist.length > 0 ? 'flex' : 'none';
  });
}

// Đồng hồ đếm ngược Flash Sale (24h)
function initCountdown() {
  const daysEl = document.getElementById('countdownDays');
  const hoursEl = document.getElementById('countdownHours');
  const minutesEl = document.getElementById('countdownMinutes');
  const secondsEl = document.getElementById('countdownSeconds');

  if (!hoursEl) return;

  // Đếm ngược 2 ngày 14 giờ từ bây giờ
  let targetTime = new Date().getTime() + (2 * 24 * 60 * 60 * 1000) + (14 * 60 * 60 * 1000);

  setInterval(() => {
    const now = new Date().getTime();
    const distance = targetTime - now;

    if (distance < 0) {
      targetTime = new Date().getTime() + (24 * 60 * 60 * 1000);
      return;
    }

    const days = Math.floor(distance / (1000 * 60 * 60 * 24));
    const hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    const minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((distance % (1000 * 60)) / 1000);

    if (daysEl) daysEl.textContent = String(days).padStart(2, '0');
    if (hoursEl) hoursEl.textContent = String(hours).padStart(2, '0');
    if (minutesEl) minutesEl.textContent = String(minutes).padStart(2, '0');
    if (secondsEl) secondsEl.textContent = String(seconds).padStart(2, '0');
  }, 1000);
}

// Thông báo Toast góc trái
function showToast(message, iconClass = 'fa-circle-check') {
  let toastContainer = document.getElementById('toastContainer');
  if (!toastContainer) {
    toastContainer = document.createElement('div');
    toastContainer.id = 'toastContainer';
    toastContainer.className = 'toast-container';
    document.body.appendChild(toastContainer);
  }

  const toast = document.createElement('div');
  toast.className = 'toast';
  toast.innerHTML = `
    <i class="fa-solid ${iconClass}"></i>
    <span>${message}</span>
  `;

  toastContainer.appendChild(toast);

  setTimeout(() => {
    toast.style.animation = 'slideToast 0.3s ease reverse forwards';
    setTimeout(() => toast.remove(), 300);
  }, 3500);
}

// Mở Modal Video Spa
function openVideoModal() {
  const modal = document.getElementById('videoModalOverlay');
  if (modal) modal.classList.add('open');
}

function closeVideoModal() {
  const modal = document.getElementById('videoModalOverlay');
  if (modal) modal.classList.remove('open');
}

// Áp mã giảm giá trong Giỏ hàng
function applyCoupon() {
  const input = document.getElementById('couponCodeInput');
  const code = input?.value.trim().toUpperCase();
  if (!code) {
    showToast('Vui lòng nhập mã giảm giá!', 'fa-ticket');
    return;
  }

  if (code === 'DOLASPA20') {
    showToast('Áp dụng mã DOLASPA20 thành công: Giảm 20% cho đơn hàng!', 'fa-circle-check');
    input.value = '';
  } else {
    showToast('Mã giảm giá không hợp lệ hoặc đã hết hạn!', 'fa-circle-xmark');
  }
}

// Checkout hành động mẫu
function checkoutCart() {
  if (cart.length === 0) {
    showToast('Giỏ hàng trống! Hãy chọn thêm sản phẩm nhé.', 'fa-circle-exclamation');
    return;
  }
  closeCart();
  showToast('Cảm ơn quý khách! Đang chuyển hướng tới cổng thanh toán an toàn...', 'fa-shield-halved');
}

// Khởi chạy khi DOM load xong
document.addEventListener('DOMContentLoaded', () => {
  // 1. Render sản phẩm nổi bật ban đầu
  const productsGrid = document.getElementById('productsGrid');
  if (productsGrid) {
    productsGrid.innerHTML = PRODUCTS_DATA.map(p => renderProductCard(p)).join('');
  }

  // 2. Render sản phẩm khuyến mãi
  renderSaleProducts();

  // 3. Khởi tạo giỏ hàng UI
  updateCartUI();

  // 4. Khởi tạo đồng hồ đếm ngược
  initCountdown();

  // 5. Sticky Header & Back to top button
  const header = document.querySelector('.site-header');
  const backToTopBtn = document.getElementById('backToTopBtn');

  window.addEventListener('scroll', () => {
    if (window.scrollY > 80) {
      header?.classList.add('scrolled');
      backToTopBtn?.classList.add('show');
    } else {
      header?.classList.remove('scrolled');
      backToTopBtn?.classList.remove('show');
    }
  });

  backToTopBtn?.addEventListener('click', () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  });

  // 6. Mobile menu toggle
  const mobileToggle = document.getElementById('mobileMenuToggle');
  const mainNav = document.getElementById('mainNav');

  mobileToggle?.addEventListener('click', () => {
    mainNav?.classList.toggle('open');
  });

  // Đóng mobile nav khi click vào link
  const navLinks = document.querySelectorAll('.nav-link');
  navLinks.forEach(link => {
    link.addEventListener('click', () => {
      mainNav?.classList.remove('open');
    });
  });

  // 7. Booking Form Listener
  const bookingForm = document.getElementById('bookingForm');
  bookingForm?.addEventListener('submit', handleBookingSubmit);

  // 8. Newsletter Form
  const newsletterForm = document.getElementById('newsletterForm');
  newsletterForm?.addEventListener('submit', (e) => {
    e.preventDefault();
    const email = document.getElementById('newsletterEmail')?.value;
    if (email) {
      showToast(`Đăng ký nhận ưu đãi thành công cho email: ${email}!`, 'fa-envelope-circle-check');
      newsletterForm.reset();
    }
  });
});
