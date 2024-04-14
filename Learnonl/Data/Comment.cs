using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public int? LessonId { get; set; }

    public string Comment1 { get; set; } = null!;

    public DateTime CommentDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual Account? User { get; set; }
}
