using System;
using System.Collections.Generic;

namespace IssueReporting.Contracts.Models;

public partial class UserMaster
{
    public int UserId { get; set; }

    public string UserEmail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<IssueDetail> IssueDetails { get; } = new List<IssueDetail>();
}
