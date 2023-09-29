using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class OrderSubtotal
{
    public long? OrderId { get; set; }

    public byte[]? Subtotal { get; set; }
}
