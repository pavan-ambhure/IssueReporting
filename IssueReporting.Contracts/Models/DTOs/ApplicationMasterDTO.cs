using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueReporting.Contracts.Models.DTOs
{
    public class ApplicationMasterDTO
    {
        public int ApplicationId { get; set; }

        public string ApplcationName { get; set; } = null!;

        public int TypeId { get; set; }
    }
}
