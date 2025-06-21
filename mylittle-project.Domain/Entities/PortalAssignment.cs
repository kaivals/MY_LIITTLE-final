using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    using System;
    using mylittle_project.Domain.Entities;

    namespace mylittle_project.Domain.Entities
    {
        public class PortalAssignment
        {
            public int Id { get; set; }

            public Guid DealerUserId { get; set; }
            public UserDealer? DealerUser { get; set; }

            public Guid AssignedPortalTenantId { get; set; }
            public Tenant? AssignedPortal { get; set; }

            public string Category { get; set; } = string.Empty;
            public DateTime AssignedOn { get; set; } = DateTime.UtcNow;
        }
    }
}
