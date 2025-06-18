using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class Productandlisting
    {
  
        public int Id { get; set; } // Primary key
        public string productname { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }

        // Add this field
        public string Portal { get; set; }

        public Guid TenantId { get; set; } // Required to associate with a tenant

    }

}
