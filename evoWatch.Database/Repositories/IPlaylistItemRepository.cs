using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    public interface IPlaylistItemRepository
    {
        Task<PlaylistItem> AddPlaylistItemAsync(PlaylistItem playlistItem);
        Task<PlaylistItem> ModifyPlaylistItemAsync(PlaylistItem modifiedPlaylistItem);
        Task<bool> DeletePlaylistItemAsync(PlaylistItem playlistItem);
    }
}