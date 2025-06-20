using System;
using System.Collections.Generic;

namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkBatchDto
    {
        public Guid SourceTenantId { get; set; }          // Changed from int
        public List<Guid> TargetTenantIds { get; set; }   // Changed from List<int>
        public string LinkType { get; set; }
    }

}
