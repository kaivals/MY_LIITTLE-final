using System;

namespace mylittle_project.Domain.Entities
{
    public class ColorPreset
    {
        public Guid Id { get; set; }           // Primary key
        public string Name { get; set; }       // e.g. "Dark Mode"
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AccentColor { get; set; }

        public Guid BrandingId { get; set; }   // FK if linked to Branding
    }
}
