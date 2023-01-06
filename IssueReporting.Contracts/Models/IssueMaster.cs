using System;
using System.Collections.Generic;

namespace IssueReporting.Contracts.Models;

public partial class IssueMaster
{
    public int IssueId { get; set; }

    public string IssueName { get; set; } = null!;

    public int ApplicationId { get; set; }

    public virtual ApplicationMaster Application { get; set; } = null!;

    public virtual ICollection<IssueDetail> IssueDetails { get; } = new List<IssueDetail>();
}
