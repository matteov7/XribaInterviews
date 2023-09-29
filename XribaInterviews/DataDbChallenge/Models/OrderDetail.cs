using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class OrderDetail
{
    public long OrderDetailId { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public double UnitPrice { get; set; }

    public long Quantity { get; set; }

    public double Discount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
