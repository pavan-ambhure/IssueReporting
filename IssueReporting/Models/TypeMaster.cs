using System;
using System.Collections.Generic;

namespace IssueReporting.Api.Models;

public partial class TypeMaster
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<ApplicationMaster> ApplicationMasters { get; } = new List<ApplicationMaster>();

    public virtual ICollection<IssueDetail> IssueDetails { get; } = new List<IssueDetail>();
}
