# Laura Coffee

Website menu và đặt món cho **Laura Coffee**, xây dựng bằng ASP.NET Core MVC (.NET 10), Entity Framework Core và SQL Server LocalDB.

## Có sẵn

- Toàn bộ menu Laura Coffee được nạp sẵn khi chạy lần đầu.
- Giỏ hàng theo phiên làm việc, biểu mẫu đặt món và lưu đơn hàng vào SQL Server.
- Trang xem/cập nhật trạng thái đơn: `/Admin/Orders`.
- Tệp lược đồ SQL độc lập: `Database/LauraCoffee.sql`.

## Chạy trong Visual Studio 2022

1. Cài **.NET 10 SDK** và workload **ASP.NET and web development**.
2. Mở `LauraCoffee.Web.csproj` bằng Visual Studio (hoặc mở `LauraCoffee.sln`).
3. Nhấn **F5**. Ứng dụng sẽ tự tạo `LauraCoffeeDb` trong `(localdb)\\MSSQLLocalDB` và nhập menu.

Chuỗi kết nối nằm ở `appsettings.json`. Khi đưa lên máy chủ, thay chuỗi này bằng SQL Server thật và thêm hệ thống đăng nhập để bảo vệ trang quản trị.
