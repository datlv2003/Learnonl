using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? FileImage { get; set; }

    public decimal? Price { get; set; }

    public decimal? Discount { get; set; }

    public string? Teacher { get; set; }

    public int? CourseId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
