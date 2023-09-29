using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class SummaryOfSalesByYear
{
    public byte[]? ShippedDate { get; set; }

    public long? OrderId { get; set; }

    public byte[]? Subtotal { get; set; }
}
