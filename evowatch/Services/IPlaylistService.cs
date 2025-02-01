using System;
using evoWatch.Database.Models;
using evoWatch.DTOs;

namespace evoWatch.Services
{
    public interface IPlaylistService
    {
        Task<Playlist> CreatePlaylistAsync(AddPlaylistDTO playlist);
        Task<Playlist> GetPlaylistByIdAsync(Guid id);
        Task<Playlist> GetPlaylistByUserAsync(User user);
        Task<Playlist> ModifyPlaylistAsync(Playlist modifiedPlaylist);
        Task<bool> DeletePlaylistAsync(Playlist playlist);
        Task<PlaylistItem> AddPlaylistItemAsync(PlaylistItem playlistItem);
        Task<PlaylistItem> ModifyPlaylistItemAsync(PlaylistItem modifiedPlaylistItem);
        Task<bool> DeletePlaylistItemAsync(PlaylistItem playlistItem);
    }
}