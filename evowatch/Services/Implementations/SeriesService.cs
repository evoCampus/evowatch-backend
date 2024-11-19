using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.Models;
using evoWatch.Models.DTOs;

namespace evoWatch.Services.Implementations
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository) {

            _seriesRepository = seriesRepository;
        }

        public async Task AddSeriesAsync(SeriesDTO series)
        {
            var result = new Series()
            {
                Id = Guid.NewGuid(),
                Title = series.Title,
                Genre = series.Genre,
                ReleaseYear = series.StartYear,
                FinalYear = series.EndYear

            };

            await _seriesRepository.AddSeriesAsync(result);
        }

        public async Task<List<Series>> GetSeriesAsync()
        {
            return await _seriesRepository.GetSeriesAsync();
        }
    }
}
