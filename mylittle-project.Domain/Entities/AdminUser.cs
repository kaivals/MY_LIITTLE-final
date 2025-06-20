public class AdminUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public Guid TenantId { get; set; }
    public string CountryCode { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty;

    // Add these new properties
    public string StreetAddress { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;
    public string StateProvince { get; set; } = string.Empty;

    public string ZipPostalCode { get; set; } = string.Empty;
}
