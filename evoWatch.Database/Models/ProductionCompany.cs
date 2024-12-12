using System.Text.Json;

namespace evoWatch.Database.Models
{
    public class ProductionCompany
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public  DateTime FoundationYear { get; set; }
        public  string Country { get; set; }
        public string Website { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
