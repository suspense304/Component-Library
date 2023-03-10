using Component_Library.Enums;

namespace Component_Library.Models
{
    public class Asset
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public int Year { get; set; } = DateTime.UtcNow.Year;
        public DeviceType DeviceType { get; set; } = DeviceType.Tracker;
        public string Make { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Identification { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public Tag Tag { get; set; } = new Tag();
    }
}
