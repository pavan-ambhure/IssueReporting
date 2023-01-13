using IssueReporting.Contracts.Models;
using WebApiTemplate.Services.Contract.Response;

namespace IssueReporting.Services.Contract.Response
{
    public class IssueDetailResponse
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

        //public  ApplicationResponse Application { get; set; } = null!;

        //public  UserResponse User { get; set; } = null!;

        //public  IssueMasterResponse Issue { get; set; } = null!;

        //public  TypeResponse Type { get; set; } = null!;
    }
}
