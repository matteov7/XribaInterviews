using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class EmployeeTerritory
{
    public long EmployeeTerritoryId { get; set; }

    public long EmployeeId { get; set; }

    public string TerritoryId { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Territory Territory { get; set; } = null!;
}
