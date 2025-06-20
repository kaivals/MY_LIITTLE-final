using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsPremium { get; set; }
        public ICollection<TenantFeature> TenantFeature { get; set; }
        public bool IsEnabled { get; set; }
    }
}
