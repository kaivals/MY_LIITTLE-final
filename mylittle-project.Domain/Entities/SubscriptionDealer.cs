using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class SubscriptionDealer
    {
        public int Id { get; set; }

        public int TenantId { get; set; }  // Linked Tenant ID
        public string PortalName { get; set; } = string.Empty; // Portal name (e.g. “Select tenant portal”)

        public List<AssignedCategory> Categories { get; set; } = new();

        public string SubscriptionPlan { get; set; } = string.Empty;  // Essentials, Premium, Elite
        public decimal Price { get; set; }
        public int DurationInMonths { get; set; }

        public bool AutoRenew { get; set; }
        public bool QueueIfUnavailable { get; set; }

        public DateTime PlanStartDate { get; set; }
    }
    public class AssignedCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;       // e.g., Cars, Bikes
        public bool IsAvailable { get; set; }   // true if available to assign
    }
}
