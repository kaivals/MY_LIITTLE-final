namespace mylittle_project.Application.DTOs
{
    public class AdminUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string CountryCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }

        public string StateProvince { get; set; }  // ✅ ensure type is string
        public string ZipPostalCode { get; set; }  // ✅ ensure type is string
        public string Country { get; set; }
    }


}