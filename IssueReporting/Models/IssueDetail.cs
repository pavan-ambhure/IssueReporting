using System;
using System.Collections.Generic;

namespace IssueReporting.Api.Models;

public partial class IssueDetail
{
    public int TicketId { get; set; }

    public int TypeId { get; set; }

    public int ApplicationId { get; set; }

    public int IssueId { get; set; }

    public string IssueDetails { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Status { get; set; }

    public DateTime LastUpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public int? UpdatedRemark { get; set; }

    public virtual ApplicationMaster Application { get; set; } = null!;

    public virtual UserMaster CreatedByNavigation { get; set; } = null!;

    public virtual IssueMaster Issue { get; set; } = null!;

    public virtual TypeMaster Type { get; set; } = null!;

    public virtual UserMaster? UpdatedByNavigation { get; set; }
}
