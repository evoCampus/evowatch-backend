using evoWatch.Database.Models;
using evoWatch.Models.DTOs;

namespace evoWatch.Services
{
    public interface ISeriesService
    {
        Task AddSeriesAsync(SeriesDTO series);
        Task<List<Series>> GetSeriesAsync(); 
    }
}
