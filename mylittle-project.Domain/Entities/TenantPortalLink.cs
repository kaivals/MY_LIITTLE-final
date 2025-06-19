using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class TenentPortalLink
    {
        public int Id { get; set; }

        public int SourcePortalId { get; set; }
        public Portal SourcePortal { get; set; }

        public int TargetPortalId { get; set; }
        public Portal TargetPortal { get; set; }

        public string LinkType { get; set; } // e.g., "Direct", "Cross-Portal", "Multi-Portal"

        public DateTime LinkedSince { get; set; } = DateTime.UtcNow;
    }

}
