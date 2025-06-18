namespace mylittle_project.Application.DTOs
{
    public class ColorPresetDto
    {
        public string Name { get; set; }                // e.g. "Blue", "Green"
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public string AccentColor { get; set; }
    }

}