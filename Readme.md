## Controller
-Là một lớp kế thừa thừ lớp controller : Microsoft.AspNetCore.Mvc.controller
-Action trong controller là một phương thức public (không được static)
-Action trả về bất kỳ kiểu dữ liệu nào, thông thường là IActionResult
-Các dịch vụ inject vào controller qua hàm tạo
## View
-la file cs.html
-View cho Action lưu tạo : /View/CotrollerName/ActionName.cshtml
-thêm thư mục lưu trữ View:
//{0} => tên Action
//{1} => tên Controller
//{2} => tên Area
options.ViewLocationFormats.Add("/MyView{1}/{0} + RazorViewEngine.ViewExtension);
## Truyền dữ liệu sang View
-Model
-ViewData
-ViewBag
-TemData
## Areas
-Là tên người dùng để routing
-Là cấu trúc thư mục chứa M.V.C
-Thiết lập Area cho controller bằng ```(Area("AreaName"))```
-Tạo cấu trúc thư mục

dotnet aspnet-codegenerator area Product
