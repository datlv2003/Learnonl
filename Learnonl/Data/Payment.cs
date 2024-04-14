using System;
using System.Collections.Generic;

namespace Learnonl.Data;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? UserId { get; set; }

    public int? CourseId { get; set; }

    public decimal Amount { get; set; }

    public DateTime PaymentDate { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Account? User { get; set; }
}
