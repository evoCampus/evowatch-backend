using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class ProductionCompany
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required DateTime FoundationYear { get; set; }
        public required string Country { get; set; }
        public required string Website { get; set; }
    }
}
