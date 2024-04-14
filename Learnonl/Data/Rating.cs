using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Rating
{
    public int RatingId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public double Rating1 { get; set; }

    public DateTime RatingDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Account? User { get; set; }
}
