using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface ISeriesService
    {
        Task<SeriesDTO> AddSeriesAsync(SeriesDTO series);
        Task<IEnumerable<SeriesDTO>> GetSeriesAsync();
        Task<SeriesDTO> GetSeriesByIdAsync(Guid id);
        Task<SeriesDTO> UpdateSeriesAsync(Guid id, SeriesDTO series);
        Task<bool> DeleteSeriesAsync(Guid id);     
    }
}
