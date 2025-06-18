namespace mylittle_project.Application.DTOs
{
    public class StoreDto
    {
        public bool EnableTaxCalculation;

        // Store Configuration
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public bool EnableTaxCalculations { get; set; }
        public bool EnableShipping { get; set; }

        // Dynamic Product Filters
        public bool EnableFilters { get; set; }

        public List<ProductFilterDto> ProductFilters { get; set; } = new();
    }

}