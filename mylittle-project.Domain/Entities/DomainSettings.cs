using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class DomainSettings
    {
        public Guid Id { get; set; }
        public string Subdomain { get; set; }
        public string CustomDomain { get; set; }
        public bool EnableApiAccess { get; set; }

        public Guid TenantId { get; set; }
    }
}


