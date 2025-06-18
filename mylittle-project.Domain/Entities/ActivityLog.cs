using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class ActivityLog
    {
        public Guid Id { get; set; }
        public string Activity { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid TenantId { get; set; }
    }

}
