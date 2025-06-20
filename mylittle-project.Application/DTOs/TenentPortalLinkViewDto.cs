using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkViewDto
    {
        public int SourcePortalId { get; set; }
        public string SourcePortalName { get; set; }

        public int TargetPortalId { get; set; }
        public string TargetPortalName { get; set; }

        public string LinkType { get; set; }
        public DateTime LinkedSince { get; set; }
    }
}

