using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Application.DTOs
{
    public class ProductDto
    {
        public string ProductName { get; set; }  // ✅ Keep this one
        public string Category { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
        public string Portal { get; set; }
        public string Description { get; set; }
        public Guid TenantId { get; set; }
    }

}

