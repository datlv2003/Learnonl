using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Content
{
    public int ContentId { get; set; }

    public int? CoursecontentId { get; set; }

    public string? ContentTitle { get; set; }

    public string? VideoUrl { get; set; }

    public virtual Coursecontent? Coursecontent { get; set; }
}
