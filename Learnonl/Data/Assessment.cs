using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Assessment
{
    public int AssessmentId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual Course? Course { get; set; }
}
