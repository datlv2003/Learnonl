using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Document
{
    public int DocumentId { get; set; }

    public int? CourseId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public string FileUrl { get; set; } = null!;

    public virtual Course? Course { get; set; }
}
