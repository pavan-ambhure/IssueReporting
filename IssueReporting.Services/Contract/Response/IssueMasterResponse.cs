namespace IssueReporting.Services.Contract.Response
{
    public class IssueMasterResponse
    {
        public int IssueId { get; set; }

        public string IssueName { get; set; } = null!;

        public int ApplicationId { get; set; }
    }
}
