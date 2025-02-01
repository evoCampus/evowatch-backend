
using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    public interface IPlaylistRepository
    {
        Task<Playlist> CreatePlaylistAsync(Playlist playlist);
        Task<Playlist?> GetPlaylistByIdAsync(Guid id);
        Task<Playlist?> GetPlaylistByUserAsync(User user);
        Task<Playlist> ModifyPlaylistAsync(Playlist modifiedPlaylist);
        Task<bool> DeletePlaylistAsync(Playlist playlist);
    }
}