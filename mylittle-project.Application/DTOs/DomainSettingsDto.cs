namespace mylittle_project.Application.DTOs
{
    public class DomainSettingsDto
    {
        public string Subdomain { get; set; }
        public string CustomDomain { get; set; }
        public bool EnableApiAccess { get; set; }
    }
}
