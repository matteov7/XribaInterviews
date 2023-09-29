using System;
using System.Collections.Generic;

namespace XribaInterviews.DataDbChallenge.Models;

public partial class Region
{
    public long RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public virtual ICollection<Territory> Territories { get; set; } = new List<Territory>();
}
