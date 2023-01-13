using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiTemplate.Contracts.Models.DTOs;

namespace IssueReporting.Contracts.Models.DTOs
{
    public class IssueDetailDTO
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

    public  ApplicationMasterDTO Application { get; set; } = null!;

    public  UserDTO User { get; set; } = null!;

    public  IssueMasterDTO Issue { get; set; } = null!;

    public  TypeDTO Type { get; set; } = null!;
    }
}
