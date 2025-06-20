using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mylittle_project.Application.DTOs
{
    public class TenentPortalLinkDto
    {
        public int Id { get; set; }
        public Guid SourceTenantId { get; set; }  // Changed from int
        public Guid TargetTenantId { get; set; }  // Changed from int
        public string LinkType { get; set; }
        public DateTime LinkedSince { get; set; } = DateTime.UtcNow;
    }

}

