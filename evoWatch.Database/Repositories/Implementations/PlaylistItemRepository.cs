
using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories.Implementations
{
    public class PlaylistItemRepository : IPlaylistItemRepository
    {
        private readonly DatabaseContext _databaseContext;
        
        public PlaylistItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<PlaylistItem> AddPlaylistItemAsync(PlaylistItem playlistItem)
        {
            var result = await _databaseContext.PlaylistItem.AddAsync(playlistItem);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<PlaylistItem> ModifyPlaylistItemAsync(PlaylistItem modifiedPlaylistItem)
        {
            var result = _databaseContext.Update(modifiedPlaylistItem);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<bool> DeletePlaylistItemAsync(PlaylistItem playlistItem)
        {
            try
            {
                _databaseContext.PlaylistItem.Remove(playlistItem);
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
    }
}