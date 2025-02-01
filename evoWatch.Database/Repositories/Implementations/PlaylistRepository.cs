using evoWatch.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace evoWatch.Database.Repositories.Implementations
{
    internal class PlaylistRepository : IPlaylistRepository
    {
        private readonly DatabaseContext _databaseContext;
        
        public PlaylistRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Playlist> CreatePlaylistAsync(Playlist playlist)
        {
            var result = await _databaseContext.Playlist.AddAsync(playlist);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<Playlist?> GetPlaylistByIdAsync(Guid id)
        {
            return await _databaseContext.Playlist.AsNoTracking().FirstOrDefaultAsync(playlist => playlist.Id == id);
        }
        
        public async Task<Playlist?> GetPlaylistByUserAsync(User user)
        {
            return await _databaseContext.Playlist.SingleOrDefaultAsync(playlist => playlist.User == user);
        }
        
        public async Task<Playlist> ModifyPlaylistAsync(Playlist modifiedPlaylist)
        {
            var result = _databaseContext.Update(modifiedPlaylist);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }
        
        public async Task<bool> DeletePlaylistAsync(Playlist playlist)
        {
            try
            {
                _databaseContext.PlaylistItem.RemoveRange(playlist.Items);
                _databaseContext.Playlist.Remove(playlist);
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