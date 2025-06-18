using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class SubscriptionDealerDto
    {
        public int TenantId { get; set; }
        public string PortalName { get; set; } = string.Empty;

        public List<AssignedCategoryDto> Categories { get; set; } = new List<AssignedCategoryDto>();
        public string SubscriptionPlan { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int DurationInMonths { get; set; }

        public bool AutoRenew { get; set; }
        public bool QueueIfUnavailable { get; set; }

        public DateTime PlanStartDate { get; set; }
    }
    public class AssignedCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
