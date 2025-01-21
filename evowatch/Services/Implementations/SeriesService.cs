using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.DTOs;
using evoWatch.Exceptions;

namespace evoWatch.Services.Implementations
{
    public class SeriesService : ISeriesService
    {
        private readonly ISeriesRepository _seriesRepository;

        public SeriesService(ISeriesRepository seriesRepository) 
        {
            _seriesRepository = seriesRepository;
        }

        public async Task<SeriesDTO> GetSeriesByIdAsync(Guid id)
        {
            var series = await _seriesRepository.GetSeriesByIdAsync(id) ?? throw new SeriesNotFoundException();
            return SeriesDTO.CreateFromSeriesDocument(series);           
        }

        public async Task<SeriesDTO> AddSeriesAsync(SeriesDTO series)
        {
            var newSeries = new Series()
            {
                Id = Guid.NewGuid(),
                Title = series.Title,
                Genre = series.Genre,
                ReleaseYear = series.ReleaseYear,
                FinalYear = series.FinalYear,
                Description = series.Description
            };
            var result = await _seriesRepository.AddSeriesAsync(newSeries);
            return SeriesDTO.CreateFromSeriesDocument(result);    
        }

        public async Task<IEnumerable<SeriesDTO>> GetSeriesAsync()
        {
          var result =  await _seriesRepository.GetSeriesAsync();
          return result.Select(x => SeriesDTO.CreateFromSeriesDocument(x));
        }

        public async Task<SeriesDTO> UpdateSeriesAsync(Guid id, SeriesDTO series)
        {
            var existingSeries = await _seriesRepository.GetSeriesByIdAsync(id) ?? throw new SeriesNotFoundException();

            existingSeries.Title = series.Title;
            existingSeries.Genre = series.Genre;
            existingSeries.ReleaseYear = series.ReleaseYear;
            existingSeries.FinalYear = series.FinalYear;
            existingSeries.Description = series.Description;
            
            var result = await _seriesRepository.UpdateSeriesAsync(existingSeries);
            return SeriesDTO.CreateFromSeriesDocument(result);
        }

        public async Task<bool> DeleteSeriesAsync(Guid id)
        {
            var seriesDelete = await _seriesRepository.GetSeriesByIdAsync(id) ?? throw new SeriesNotFoundException();
            return await _seriesRepository.DeleteSeriesAsync(seriesDelete);
        }      
    }
}
