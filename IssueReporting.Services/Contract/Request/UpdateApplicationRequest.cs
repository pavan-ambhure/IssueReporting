namespace IssueReporting.Services.Contract.Request
{
    public class UpdateApplicationRequest
    {
        public int ApplicationId { get; set; }

        public string ApplcationName { get; set; } = null!;

        public int TypeId { get; set; }
    }
}
