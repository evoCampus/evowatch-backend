namespace evoWatch.Models
{

     /*
      * test class, not for the db
      */
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Seasons { get; set; }
    }
}
