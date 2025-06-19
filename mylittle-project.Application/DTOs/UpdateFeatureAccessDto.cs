using System.Collections.Generic;

namespace mylittle_project.Application.DTOs
{
    public class UpdateFeatureAccessDto
    {
        public int PortalId { get; set; }
        public int FeatureId { get; set; }
        public bool IsEnabled { get; set; }
    }

}
