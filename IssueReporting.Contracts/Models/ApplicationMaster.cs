using System;
using System.Collections.Generic;

namespace IssueReporting.Contracts.Models;

public partial class ApplicationMaster
{
    public int ApplicationId { get; set; }

    public string ApplcationName { get; set; } = null!;

    public int TypeId { get; set; }

    public virtual ICollection<IssueDetail> IssueDetails { get; } = new List<IssueDetail>();

    public virtual ICollection<IssueMaster> IssueMasters { get; } = new List<IssueMaster>();

    public virtual TypeMaster Type { get; set; } = null!;
}
