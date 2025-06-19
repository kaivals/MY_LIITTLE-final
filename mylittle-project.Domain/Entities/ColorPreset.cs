using System;

namespace mylittle_project.Domain.Entities
{
    public class ColorPreset
    {
        public Guid Id { get; set; }           // Primary key
        public string Name { get; set; } = string.Empty;     // e.g. "Dark Mode"
        public string PrimaryColor { get; set; } = string.Empty;
        public string SecondaryColor { get; set; } = string.Empty;
        public string AccentColor { get; set; } = string.Empty;

        public Guid BrandingId { get; set; }   // FK if linked to Branding
    }
}
