using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class SeriesRepository : ISeriesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SeriesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddSeriesAsync(Series series)
        {
            _databaseContext.Series.Add(series);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<List<Series>> GetSeriesAsync()
        {
           return await _databaseContext.Series.ToListAsync();
        }

        public Task DeleteSeriesAsync(Series series)
        {
            throw new NotImplementedException();
        }


        public Task UpdateSeriesAsync(Series series)
        {
            throw new NotImplementedException();
        }
    }
}
