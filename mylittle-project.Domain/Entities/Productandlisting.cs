using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class Productandlisting
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }  // ✅ Must exist
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }  // ✅ Must exist
        public Guid TenantId { get; set; }
    }


}