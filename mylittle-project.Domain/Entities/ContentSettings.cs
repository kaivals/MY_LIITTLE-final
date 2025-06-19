using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class ContentSettings
    {
        public Guid Id { get; set; }

        public string WelcomeMessage { get; set; } = string.Empty;
        public string CallToAction { get; set; } = string.Empty;
        public string HomePageContent { get; set; } = string.Empty;
        public string AboutUs { get; set; } = string.Empty;

        public Guid TenantId { get; set; }
    }
}

