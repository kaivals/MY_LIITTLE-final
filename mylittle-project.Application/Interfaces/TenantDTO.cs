namespace mylittle_project.Application.Interfaces
{
    public class TenantDTO
    {
        public object? EnableApiAccess { get; internal set; } 
        public string TenantName { get; internal set; } = string.Empty;
        public object? CustomDomain { get; internal set; } 
        public string Description { get; internal set; } = string.Empty;
        public string Status { get; internal set; } = string.Empty;
        public object? Industry { get; internal set; }
    }
}