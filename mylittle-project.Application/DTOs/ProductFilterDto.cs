namespace mylittle_project.Application.DTOs
{
    public class ProductFilterDto
    {
        public string Name { get; set; }               // e.g. "Availability", "Rating", "Color"
        public string Description { get; set; }        // e.g. "Basic filter", "Attributes filter"
        public bool IsActive { get; set; }             // toggle button status
        public string Type { get; set; }               // e.g. "toggle", "range", "multiselect"
        public string Category { get; set; }           // e.g. "Basic", "Attributes", "Pricing"

        // For range type
        public double? RangeStart { get; set; }        // for rating/discount, e.g. 0
        public double? RangeEnd { get; set; }          // e.g. 5, 100
        public double? Step { get; set; }              // e.g. 0.1, 5

        // For multiselect type
        public List<string> Options { get; set; }      // e.g. ["Red", "Blue", "Green"]
    }

}