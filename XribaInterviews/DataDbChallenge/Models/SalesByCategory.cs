﻿using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class SalesByCategory
{
    public long? CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? ProductName { get; set; }

    public byte[]? ProductSales { get; set; }
}
