using Learnonl.Data;
using Microsoft.AspNetCore.Mvc;
using Learnonl.Models;
using Microsoft.EntityFrameworkCore;

namespace Learnonl.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly LearnonlContext _context;

        public AdminController(ILogger<AdminController> logger, LearnonlContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Index(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");

            // Kiểm tra xem người dùng có vai trò Admin hay không
            if (userRole != "Admin")
            {
                // Nếu không phải Admin, chuyển hướng về trang Index của Home
                return RedirectToAction("Index", "Home");
            }
            var categories = _context.Categories.AsQueryable();
            if (id.HasValue)
            {
                categories = categories.Where(p => p.CategoryId == id.Value);
            }
            var result = categories.Select(p => new Category
            {
                Name = p.Name,
                CategoryId = p.CategoryId,
                FileImage = p.FileImage,
                Price = p.Price,
                Discount = p.Discount,
                Teacher = p.Teacher,
                CourseId = p.CourseId,
            });
            /*ViewBag.CourseId = result.Select(x => x.CourseId).FirstOrDefault(); // Lấy CourseId từ kết quả đầu tiên*/

            /* ViewBag.CourseId = null; // Khởi tạo ViewBag.CourseId là null trước khi gán giá trị từ vòng lặp

             foreach (var item in result)
             {
                 ViewBag.CourseId = item.CourseId; // Gán giá trị p.CourseId cho ViewBag.CourseId trong mỗi lần lặp
                                                   // Thực hiện các thao tác khác tại đây (nếu cần)
             }*/
            //ViewBag.Price = result.FirstOrDefault()?.Price;// Lưu danh sách Price vào ViewBag.Price
            ViewBag.Prices = result.Select(x => x.Price).ToList();

            ViewBag.CourseIds = result.Select(x => x.CourseId).ToList(); // Lưu danh sách CourseId vào ViewBag.CourseIds
            return View(result);
            // Nếu là Admin, hiển thị View Admin
        }
    }
}