using evoWatch.Database.Models;
using evoWatch.Database.Repositories;
using evoWatch.Database.Repositories.Implementations;
using evoWatch.DTOs;
using evoWatch.Exceptions;

namespace evoWatch.Services.Implementations
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IPlaylistItemRepository _playlistItemRepository;
        private readonly IUserRepository _userRepository;

        public PlaylistService(IPlaylistRepository playlistRepository, IPlaylistItemRepository playlistItemRepository, IUserRepository userRepository)
        {
            _playlistRepository = playlistRepository;
            _playlistItemRepository = playlistItemRepository;
            _userRepository = userRepository;
        }

        public async Task<Playlist> CreatePlaylistAsync(AddPlaylistDTO playlist)
        {
            var user = await _userRepository.GetUserByIdAsync(playlist.UserId) ?? throw new UserNotFoundException();

            var result = new Playlist()
            {
                Id = Guid.NewGuid(),
                Name = playlist.Name,
                Description = playlist.Description,
                Public = playlist.Public,
                User = user
            };
            return await _playlistRepository.CreatePlaylistAsync(result);
        }

        public async Task<Playlist> GetPlaylistByIdAsync(Guid id)
        {
            return await _playlistRepository.GetPlaylistByIdAsync(id) ?? throw new PlaylistNotFoundException();
        }

        public async Task<Playlist> GetPlaylistByUserAsync(User user)
        {
            return await _playlistRepository.GetPlaylistByUserAsync(user) ?? throw new PlaylistNotFoundException();
        }

        public async Task<Playlist> ModifyPlaylistAsync(Playlist modifiedPlaylist)
        {
            return await _playlistRepository.ModifyPlaylistAsync(modifiedPlaylist);
        }

        public async Task<bool> DeletePlaylistAsync(Playlist playlist)
        {
            return await _playlistRepository.DeletePlaylistAsync(playlist);
        }

        public async Task<PlaylistItem> AddPlaylistItemAsync(PlaylistItem playlistItem)
        {
            return await _playlistItemRepository.AddPlaylistItemAsync(playlistItem);
        }

        public async Task<PlaylistItem> ModifyPlaylistItemAsync(PlaylistItem modifiedPlaylistItem)
        {
            return await _playlistItemRepository.ModifyPlaylistItemAsync(modifiedPlaylistItem);
        }

        public async Task<bool> DeletePlaylistItemAsync(PlaylistItem playlistItem)
        {
            return await _playlistItemRepository.DeletePlaylistItemAsync(playlistItem);
        }
    }
}