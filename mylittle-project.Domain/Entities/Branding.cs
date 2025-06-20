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
        public string PrimaryColor { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string AccentColor { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = string.Empty;
        public string TextColor { get; set; } = string.Empty;

        // Optional
        public List<ColorPreset>? ColorPresets { get; set; }

        // Nested objects
        public BrandingText? Text { get; set; }
        public BrandingMedia? Media { get; set; }

        public Guid TenantId { get; set; }
    }


}
