using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public DateOnly EnrollmentDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public virtual Course? Course { get; set; }

    public virtual Account? User { get; set; }
}
