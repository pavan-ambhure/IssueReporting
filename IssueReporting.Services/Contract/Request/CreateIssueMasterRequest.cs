using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Services.Contract.Request
{
    public class CreateIssueMasterRequest
    {
        public string IssueName { get; set; } = null!;

        public int ApplicationId { get; set; }
    }
}
