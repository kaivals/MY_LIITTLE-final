public class AdminUser
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string PhoneNumber { get; set; }

    public Guid TenantId { get; set; }
    public string CountryCode { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Gender { get; set; }

    // Add these new properties
    public string StreetAddress { get; set; }
    public string City { get; set; }

    public string Country { get; set; }
    public string StateProvince { get; set; }

    public string ZipPostalCode { get; set; }
}
