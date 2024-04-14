using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Coursecontent
{
    public int CoursecontentId { get; set; }

    public int? LessonId { get; set; }

    public string? Subjecttitle { get; set; }

    public int? LessoncontentId { get; set; }

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();

    public virtual Lesson? Lesson { get; set; }
}
