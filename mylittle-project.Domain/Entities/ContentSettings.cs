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

        public string WelcomeMessage { get; set; }
        public string CallToAction { get; set; }
        public string HomePageContent { get; set; }
        public string AboutUs { get; set; }

        public Guid TenantId { get; set; }
    }
}

