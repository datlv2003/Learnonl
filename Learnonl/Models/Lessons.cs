namespace Learnonl.Models
{
    public class LessonViewModel
    {
        public int LessonId { get; set; }
        public int? CourseId { get; set; }
        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        public int? LessonOrder { get; set; }
        public List<CourseContentViewModel> CourseContents { get; set; }
    }

    public class CourseContentViewModel
    {
        public int CourseContentId { get; set; }
        public int? LessonId { get; set; }
        public string? SubjectTitle { get; set; }
        public int? LessonContentId { get; set; }
        public List<ContentViewModel> Contents { get; set; }
    }

    public class ContentViewModel
    {
        public int ContentId { get; set; }
        public int? CourseContentId { get; set; }
        public string? ContentTitle { get; set; }
        public string? VideoUrl { get; set; }
    }
}
