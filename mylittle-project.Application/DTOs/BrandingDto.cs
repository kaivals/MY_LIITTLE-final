namespace mylittle_project.Application.DTOs
{
    public class BrandingDto
    {
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AccentColor { get; set; }
        public string BackgroundColor { get; set; }
        public string TextColor { get; set; }

        public List<ColorPresetDto> ColorPresets { get; set; } = new();
        public BrandingTextDto? TextSettings { get; set; }
        public BrandingMediaDto? MediaSettings { get; set; }
    }


}