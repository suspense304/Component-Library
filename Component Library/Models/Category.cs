namespace Component_Library.Models
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Identification { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public Category? Parent { get; set; }

    }
}
