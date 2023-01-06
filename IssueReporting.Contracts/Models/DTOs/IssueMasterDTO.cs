namespace IssueReporting.Contracts.Models.DTOs
{
    public class IssueMasterDTO
    {
        public int IssueId { get; set; }

        public string IssueName { get; set; } = null!;

        public int ApplicationId { get; set; }
    }
}
