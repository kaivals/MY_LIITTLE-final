namespace mylittle_project.Application.DTOs
{
    public class AdminUserDto
    {
        // Basic Information
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        // Contact Information
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }

        // Personal Details
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }

        // Address Information
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string Country { get; set; }
        public object ZipPostalCode { get; set; }
        public object StateProvince { get; set; }
    }

}