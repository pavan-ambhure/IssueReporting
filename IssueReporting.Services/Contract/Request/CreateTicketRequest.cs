namespace IssueReporting.Services.Contract.Request
{
    public class CreateTicketRequest
    {
        public int TypeId { get; set; }

        public int ApplicationId { get; set; }

        public int IssueId { get; set; }

        public string IssueDetails { get; set; } = null!;

        public int CreatedBy { get; set; }

    }
}
