using Microsoft.AspNetCore.Mvc;
using Learnonl.Models; 
using System.Linq;
using Learnonl.ViewModels;
using Learnonl.Data;
using Microsoft.EntityFrameworkCore;

namespace Learnonl.Controllers
{
    public class SchedulesController : Controller
    {
        private readonly LearnonlContext _dbContext;

        public SchedulesController(LearnonlContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Đây là phương thức để hiển thị form thêm thời khóa biểu
        [HttpGet]
        public IActionResult AddSchedule()
        {
            return View();
        }

        // Đây là phương thức để xử lý dữ liệu form khi form được submit
        [HttpPost]
        public async Task<IActionResult> AddSchedule(AddScheduleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var schedule = new Schedule
                {
                    LessonId = model.LessonId,
                    NgayHoc = model.NgayHoc != null? DateOnly.FromDateTime(model.NgayHoc) : null, // Chuyển đổi DateTime sang DateOnly
                    Slot = model.Slot,
                    // Điền các thông tin khác từ model vào đây
                };

                _dbContext.Schedules.Add(schedule);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // Phương thức Index để hiển thị danh sách thời khóa biểu
        public IActionResult Index()
        {
            var schedules = _dbContext.Schedules.ToList();
            var viewModel = new ScheduleViewModel
            {
                Schedules = schedules // Đảm bảo rằng Schedules là một thuộc tính hợp lệ của ScheduleViewModel
            };
            return View(viewModel);
        }
    }
}
