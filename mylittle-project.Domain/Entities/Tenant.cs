using mylittle_project.Domain.Entities;

public class Tenant
{
    public Store store;

    public Guid Id { get; set; }
    public string TenantName { get; set; }
    public string TenantNickname { get; set; }
    public string Subdomain { get; set; }
    public string IndustryType { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }

    public AdminUser AdminUser { get; set; }
    public Subscription Subscription { get; set; }
    public Store Store { get; set; }
    public Branding Branding { get; set; }
    public ContentSettings ContentSettings { get; set; }
    public FeatureSettings FeatureSettings { get; set; }
    public DomainSettings DomainSettings { get; set; }
    public ICollection<ActivityLog> ActivityLogs { get; set; }
  
}
