    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace mylittle_project.Domain.Entities
    {
        public class Portal
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool IsActive { get; set; }
            public DateTime LastAccessed { get; set; }
            public ICollection<PortalFeature> PortalFeatures { get; set; }
        }
    }
