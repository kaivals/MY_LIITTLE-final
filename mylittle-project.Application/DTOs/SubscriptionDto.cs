namespace mylittle_project.Application.DTOs
{
    public class SubscriptionDto
    {
        public object PlanName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }

        public Guid TenantId { get; set; } // ✅ Proper syntax
    }
}
