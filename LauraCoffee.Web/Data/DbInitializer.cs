using LauraCoffee.Web.Models;

namespace LauraCoffee.Web.Data;

public static class DbInitializer
{
    public static void Seed(CoffeeDbContext db)
    {
        if (db.Categories.Any()) return;

        var categories = new[]
        {
            new Category { Name = "Cà phê", Icon = "☕", DisplayOrder = 1 },
            new Category { Name = "Trà & Trà sữa", Icon = "🍵", DisplayOrder = 2 },
            new Category { Name = "Đá xay & Cacao", Icon = "🥤", DisplayOrder = 3 },
            new Category { Name = "Nước ép & Sinh tố", Icon = "🍊", DisplayOrder = 4 },
            new Category { Name = "Đồ ăn nhanh", Icon = "🍟", DisplayOrder = 5 },
            new Category { Name = "Tráng miệng", Icon = "🍮", DisplayOrder = 6 },
            new Category { Name = "Bánh ngọt & Bánh kem cắt miếng", Icon = "🍰", DisplayOrder = 7 },
            new Category { Name = "Bánh kem nguyên chiếc", Icon = "🎂", DisplayOrder = 8 },
            new Category { Name = "Combo Laura", Icon = "✨", DisplayOrder = 9 }
        };
        db.Categories.AddRange(categories);
        db.SaveChanges();

        int Id(string name) => categories.Single(c => c.Name == name).CategoryId;
        var products = new (string Cat, string Name, decimal Price, string? Unit, string? Note)[]
        {
            ("Cà phê","Cà phê đen đá",25000,null,null),("Cà phê","Cà phê sữa đá",29000,null,null),("Cà phê","Bạc xỉu",32000,null,null),("Cà phê","Cà phê muối",35000,null,null),("Cà phê","Cà phê dừa",39000,null,null),("Cà phê","Americano",35000,null,null),("Cà phê","Cappuccino",45000,null,null),("Cà phê","Latte",45000,null,null),("Cà phê","Caramel Macchiato",49000,null,null),
            ("Trà & Trà sữa","Trà đào cam sả",39000,null,null),("Trà & Trà sữa","Trà vải",39000,null,null),("Trà & Trà sữa","Trà sen vàng",42000,null,null),("Trà & Trà sữa","Trà chanh dây",35000,null,null),("Trà & Trà sữa","Trà sữa truyền thống",35000,null,null),("Trà & Trà sữa","Trà sữa ô long",39000,null,null),("Trà & Trà sữa","Matcha Latte",45000,null,null),
            ("Đá xay & Cacao","Chocolate đá xay",49000,null,null),("Đá xay & Cacao","Matcha đá xay",49000,null,null),("Đá xay & Cacao","Cookies & Cream đá xay",49000,null,null),("Đá xay & Cacao","Cacao nóng/đá",39000,null,null),
            ("Nước ép & Sinh tố","Nước ép cam",39000,null,null),("Nước ép & Sinh tố","Nước ép dưa hấu",35000,null,null),("Nước ép & Sinh tố","Nước ép dứa",35000,null,null),("Nước ép & Sinh tố","Sinh tố xoài",45000,null,null),("Nước ép & Sinh tố","Sinh tố bơ",49000,null,null),("Nước ép & Sinh tố","Sinh tố dâu",49000,null,null),
            ("Đồ ăn nhanh","Khoai tây chiên",35000,"phần",null),("Đồ ăn nhanh","Khoai tây lắc phô mai",39000,"phần",null),("Đồ ăn nhanh","Gà viên chiên",45000,"phần",null),("Đồ ăn nhanh","Gà rán",49000,"2 miếng",null),("Đồ ăn nhanh","Xúc xích nướng",35000,"2 cây",null),("Đồ ăn nhanh","Sandwich trứng phô mai",39000,"phần",null),("Đồ ăn nhanh","Sandwich gà",45000,"phần",null),("Đồ ăn nhanh","Burger bò phô mai",59000,"cái",null),("Đồ ăn nhanh","Mì Ý sốt bò bằm",65000,"phần",null),("Đồ ăn nhanh","Pizza mini xúc xích phô mai",59000,"cái",null),
            ("Tráng miệng","Bánh flan caramel",25000,"phần",null),("Tráng miệng","Panna cotta dâu",35000,"ly",null),("Tráng miệng","Sữa chua trái cây",39000,"ly",null),("Tráng miệng","Kem vani hoặc chocolate",29000,"2 viên",null),("Tráng miệng","Waffle mật ong",45000,"phần",null),("Tráng miệng","Waffle kem trái cây",59000,"phần",null),
            ("Bánh ngọt & Bánh kem cắt miếng","Croissant bơ",29000,"cái",null),("Bánh ngọt & Bánh kem cắt miếng","Muffin chocolate",32000,"cái",null),("Bánh ngọt & Bánh kem cắt miếng","Brownie chocolate",35000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Tiramisu",45000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Cheesecake chanh dây",45000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Bánh kem dâu",49000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Bánh kem chocolate",49000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Bánh kem matcha",49000,"miếng",null),("Bánh ngọt & Bánh kem cắt miếng","Bánh mousse xoài",45000,"miếng",null),
            ("Bánh kem nguyên chiếc","Bánh kem vani",250000,null,"Đường kính 16 cm. Đặt trước tối thiểu 24 giờ."),("Bánh kem nguyên chiếc","Bánh kem chocolate",280000,null,"Đường kính 16 cm. Đặt trước tối thiểu 24 giờ."),("Bánh kem nguyên chiếc","Bánh kem dâu",290000,null,"Đường kính 16 cm. Đặt trước tối thiểu 24 giờ."),("Bánh kem nguyên chiếc","Bánh kem matcha",290000,null,"Đường kính 16 cm. Đặt trước tối thiểu 24 giờ."),("Bánh kem nguyên chiếc","Bánh mousse xoài",280000,null,"Đường kính 16 cm. Đặt trước tối thiểu 24 giờ."),
            ("Combo Laura","Bữa sáng",49000,null,"Cà phê sữa đá + Croissant bơ"),("Combo Laura","Trưa nhẹ",69000,null,"Americano + Sandwich gà"),("Combo Laura","Chiều ngọt",75000,null,"Trà đào cam sả + Tiramisu"),("Combo Laura","Ăn vui",99000,null,"Trà chanh dây + Gà viên + Khoai tây chiên")
        };
        db.Products.AddRange(products.Select((p, i) => new Product { CategoryId = Id(p.Cat), Name = p.Name, Price = p.Price, Unit = p.Unit, Description = p.Note, IsFeatured = i < 9 }));
        db.AddOns.AddRange(new AddOn { Name = "Thêm một shot espresso", Price = 10000 }, new AddOn { Name = "Thêm trân châu", Price = 8000 }, new AddOn { Name = "Thêm thạch trái cây", Price = 8000 }, new AddOn { Name = "Thêm kem cheese", Price = 12000 });
        db.SaveChanges();
    }
}
