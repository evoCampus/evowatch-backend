using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class SeriesRepository : ISeriesRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SeriesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Series> AddSeriesAsync(Series series)
        {
            var result = await _databaseContext.Series.AddAsync(series);
            await _databaseContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Series>> GetSeriesAsync()
        {
            return await Task.FromResult(_databaseContext.Series.AsEnumerable());
        }

        public async Task<bool> DeleteSeriesAsync(Series series)
        {
            try
            {
                var result = _databaseContext.Series.Remove(series);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch(InvalidOperationException)
            {
                return false;   
            }          
        }

        public async Task<Series?> GetSeriesByIdAsync(Guid id)
        {
            return await _databaseContext.Series.FindAsync(id);
        }

        public async Task<Series> UpdateSeriesAsync(Series series)
        {
            var result = _databaseContext.Series.Update(series);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;          
        }
    }
}
