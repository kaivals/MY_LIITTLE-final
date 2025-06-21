namespace mylittle_project.Application.DTOs
{
    public class ProductandlistingDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public Guid TenantId { get; set; }
    }
}
