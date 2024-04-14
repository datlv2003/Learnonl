using Learnonl.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Learnonl.ViewModels;
public class AddScheduleViewModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ScheduleId { get; set; }
    public int LessonId { get; set; }
    public DateTime NgayHoc { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public int Slot { get; set; }
    public string TrangThai { get; set; }
    public int TeacherName { get; set; }
    public int Room { get; set; }

    public virtual Lesson Lesson { get; set; }
    // Bạn cần thêm các navigation properties cho Instructor và Room nếu có trong model của bạn
}
