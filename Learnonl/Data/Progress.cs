using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Progress
{
    public int ProgressId { get; set; }

    public int? UserId { get; set; }

    public int? LessonId { get; set; }

    public DateOnly? CompletionDate { get; set; }

    public virtual Lesson? Lesson { get; set; }

    public virtual Account? User { get; set; }
}
