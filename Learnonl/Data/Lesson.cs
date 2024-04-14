using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Lesson
{
    public int LessonId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? VideoUrl { get; set; }

    public int? LessonOrder { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Course? Course { get; set; }

    public virtual ICollection<Coursecontent> Coursecontents { get; set; } = new List<Coursecontent>();

    public virtual ICollection<Progress> Progresses { get; set; } = new List<Progress>();
}
