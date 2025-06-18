using System.Collections.Generic;

namespace mylittle_project.Application.DTOs
{
    public class UpdateFeatureAccessDto
    {
        public int PortalId { get; set; }
        public List<int> FeatureIds { get; set; }
        public bool IsEnabled { get; set; } // <- This is required to indicate ON/OFF
    }
}
