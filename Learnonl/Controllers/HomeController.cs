using Learnonl.Data;
using Learnonl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Learnonl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LearnonlContext _context;

        public HomeController(ILogger<HomeController> logger, LearnonlContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            var categories = _context.Categories.AsQueryable();
            if (id.HasValue)
            {
                categories = categories.Where(p => p.CategoryId == id.Value);
            }
            var result = categories.Select(p => new Categories
            {
                Name = p.Name,
                CategoryId = p.CategoryId,
                Description = p.Description,
                FileImage = p.FileImage,
                Price = p.Price,
                Discount = p.Discount,
                Teacher = p.Teacher,
                CourseId = p.CourseId,
            });
            //ViewBag.Price = result.FirstOrDefault()?.Price;// Lưu danh sách Price vào ViewBag.Price
            ViewBag.Prices = result.Select(x => x.Price).ToList();

            ViewBag.CourseIds = result.Select(x => x.CourseId).ToList(); // Lưu danh sách CourseId vào ViewBag.CourseIds
            return View(result);
            /* return View();*/
        }

        public IActionResult Content(int id)
        {
            // Lấy dữ liệu bằng Entity Framework Core (giả sử bạn có một DbContext)
            var lessonData = _context.Lessons
                .Include(l => l.Coursecontents)
                .Select(l => new LessonViewModel // Ánh xạ sang LessonViewModel
                {
                    LessonId = l.LessonId,
                    CourseId = l.CourseId,
                    Title = l.Title,
                    VideoUrl = l.VideoUrl,
                    LessonOrder = l.LessonOrder,
                    CourseContents = l.Coursecontents.Select(cc => new CourseContentViewModel // Ánh xạ sang CourseContentViewModel
                    {
                        CourseContentId = cc.CoursecontentId,
                        LessonId = cc.LessonId,
                        SubjectTitle = cc.Subjecttitle,
                        LessonContentId = cc.LessoncontentId,
                        Contents = cc.Contents.Select(c => new ContentViewModel // Ánh xạ sang ContentViewModel
                        {
                            ContentId = c.ContentId,
                            CourseContentId = c.CoursecontentId,
                            ContentTitle = c.ContentTitle,
                            VideoUrl = c.VideoUrl
                        }).ToList()
                    }).ToList()
                })
                    .Where(l => l.CourseId == id) // Lọc dựa trên id nhận được
                    .ToList();

            return View(lessonData); // Truyền dữ liệu cho View
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
