namespace mylittle_project.Application.DTOs
{
    public class SubscriptionDto
    {
        public string PlanName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsTrial { get; set; }
        public bool IsActive { get; set; }
    }

}
