using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    public interface ISeriesRepository
    {
        Task<IEnumerable<Series>> GetSeriesAsync();
        Task<Series> AddSeriesAsync(Series series);
        Task<Series> UpdateSeriesAsync(Series series);
        Task<Series?> GetSeriesByIdAsync(Guid id);  
        Task<bool> DeleteSeriesAsync(Series series);
    }
}
