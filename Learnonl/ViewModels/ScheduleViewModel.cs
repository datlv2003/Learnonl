using Learnonl.Data;

namespace Learnonl.ViewModels
{
    public class ScheduleViewModel
    {
        public virtual List<Schedule> Schedules { get; set; }
        // Thêm các thuộc tính khác nếu cần
        public int ScheduleId { get; set; }

        public int? LessonId { get; set; }

        public DateOnly? NgayHoc { get; set; }

        public TimeOnly? StartTime { get; set; }

        public TimeOnly? EndTime { get; set; }

        public int? Slot { get; set; }

        public string? TrangThai { get; set; }

        public string? TeacherName { get; set; }

        public int? Room { get; set; }

        // Các thuộc tính khác của Lesson
        public string Title { get; set; }

        // Navigation property cho Lesson
        public virtual Lesson Lesson { get; set; }

        // Navigation property cho Sch
    }
}
