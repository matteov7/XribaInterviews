using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class ProductsByCategory
{
    public string? CategoryName { get; set; }

    public string? ProductName { get; set; }

    public string? QuantityPerUnit { get; set; }

    public long? UnitsInStock { get; set; }

    public byte[]? Discontinued { get; set; }
}
