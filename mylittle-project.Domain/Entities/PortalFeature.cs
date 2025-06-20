using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class PortalFeature
    {
        public int PortalId { get; set; }
        public Portal Portal { get; set; }

        public int FeatureId { get; set; }
        public Feature Feature { get; set; }

        public bool IsEnabled { get; set; }
    }
}
