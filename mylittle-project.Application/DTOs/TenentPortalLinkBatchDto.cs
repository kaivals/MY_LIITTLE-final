using System;
using System.Collections.Generic;

namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkBatchDto
    {
        public int SourcePortalId { get; set; }
        public List<int> TargetPortalIds { get; set; }
        public string LinkType { get; set; }
    }
}
