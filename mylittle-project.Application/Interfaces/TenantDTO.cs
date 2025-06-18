namespace mylittle_project.Application.Interfaces
{
    public class TenantDTO
    {
        public object EnableApiAccess { get; internal set; }
        public string TenantName { get; internal set; }
        public object CustomDomain { get; internal set; }
        public string Description { get; internal set; }
        public string Status { get; internal set; }
        public object Industry { get; internal set; }
    }
}