namespace mylittle_project.Domain.Entities
{
    public class BrandingMedia
    {
        public Guid Id { get; set; } // This makes it a valid EF entity
        public string LogoUrl { get; set; } = string.Empty;
        public string FaviconUrl { get; set; } = string.Empty;
        public string BackgroundImageUrl { get; set; } = string.Empty;

        public Guid BrandingId { get; set; } // optional, for relationship
    }

}