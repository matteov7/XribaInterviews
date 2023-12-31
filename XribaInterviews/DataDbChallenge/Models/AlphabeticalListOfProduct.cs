﻿using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class AlphabeticalListOfProduct
{
    public long? ProductId { get; set; }

    public string? ProductName { get; set; }

    public long? SupplierId { get; set; }

    public long? CategoryId { get; set; }

    public string? QuantityPerUnit { get; set; }

    public double? UnitPrice { get; set; }

    public long? UnitsInStock { get; set; }

    public long? UnitsOnOrder { get; set; }

    public long? ReorderLevel { get; set; }

    public byte[]? Discontinued { get; set; }

    public string? CategoryName { get; set; }
}
