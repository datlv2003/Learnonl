using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Schedule
{
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

    // Navigation property cho Schedule
}
