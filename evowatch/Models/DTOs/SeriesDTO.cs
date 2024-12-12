using evoWatch.Database.Models;

namespace evoWatch.Models.DTOs
{
    public class SeriesDTO
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public int FinalYear { get; set; }
        public string Description { get; set; }


        public static SeriesDTO CreateFromSeriesDocument(Series series)
        {
            return new SeriesDTO
            {
                Title = series.Title,
                Genre = series.Genre,
                ReleaseYear = series.ReleaseYear,
                FinalYear = series.FinalYear,
                Description = series.Description

            };
        }

    }

    
}
