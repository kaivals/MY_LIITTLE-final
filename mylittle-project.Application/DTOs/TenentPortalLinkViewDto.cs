using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkViewDto
    {
        public Guid SourceTenantId { get; set; }     // Changed from int
        public string SourceTenantName { get; set; }

        public Guid TargetTenantId { get; set; }     // Changed from int
        public string TargetTenantName { get; set; }

        public string LinkType { get; set; }
        public DateTime LinkedSince { get; set; }
    }

}

