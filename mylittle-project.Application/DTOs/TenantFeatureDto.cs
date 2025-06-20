using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class TenantFeatureDto
    {
        public Guid TenantId { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; } // Optional, useful for display
        public bool IsEnabled { get; set; }
    }
}

