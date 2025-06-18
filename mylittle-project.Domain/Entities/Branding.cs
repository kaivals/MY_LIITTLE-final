using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mylittle_project.Domain.Entities
{
    public class Branding
    {
        public Guid Id { get; set; }

        // Color settings
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AccentColor { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }

        // Optional
        public List<ColorPreset> ColorPresets { get; set; }

        // Nested objects
        public BrandingText Text { get; set; }
        public BrandingMedia Media { get; set; }

        public Guid TenantId { get; set; }
    }


}
