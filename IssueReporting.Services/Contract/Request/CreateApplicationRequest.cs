using System.ComponentModel;

namespace IssueReporting.Services.Contract.Request
{
    public class CreateApplicationRequest
    {
        [DisplayName("Application")]
        public string ApplcationName { get; set; } = null!;

        public int TypeId { get; set; }
    }
}
