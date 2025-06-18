using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace mylittle_project.Domain.Entities
{
    public class Store
    {
        public Guid Id { get; set; }

        // Store Configuration
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public bool EnableTaxCalculations { get; set; }
        public bool EnableShipping { get; set; }

        // Filters
        public bool EnableFilters { get; set; }

        public Guid TenantId { get; set; }

        public ICollection<Filter> ProductFilters { get; set; } = new List<Filter>();
    }
}
