using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class UpdateAllFeatureAccessDto
    {
        public int PortalId { get; set; }
        public List<int> FeatureIds { get; set; } // 👈 This must be defined
        public bool IsEnabled { get; set; }
    }
}

