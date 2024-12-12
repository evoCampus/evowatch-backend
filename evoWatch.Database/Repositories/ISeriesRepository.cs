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
        Task AddSeriesAsync(Series series);
        Task<List<Series>> GetSeriesAsync();
        Task UpdateSeriesAsync(Series series);
        Task DeleteSeriesAsync(Series series);
        
    }
}
