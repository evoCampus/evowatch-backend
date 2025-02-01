using evoWatch.Database.Models;
using evoWatch.DTOs;
using evoWatch.Exceptions;
using evoWatch.Services;
using Microsoft.AspNetCore.Mvc;

namespace evoWatch.Controllers
{
    [ApiController]
    [Route("playlist")]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpPost(Name = nameof(CreatePlaylist))]
        public async Task<IActionResult> CreatePlaylist(AddPlaylistDTO playlist)
        {
            try
            {
            var result = await _playlistService.CreatePlaylistAsync(playlist);
            return Ok(result);
            }
            catch (UserNotFoundException)
            {
                return Problem($"User with specified ID: {playlist.UserId} not found", null, StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("GetById", Name = nameof(GetPlaylistById))]
        public async Task<IActionResult> GetPlaylistById(Guid id)
        {
            try
            {
                var result = await _playlistService.GetPlaylistByIdAsync(id);
                return Ok(result);
            }
            catch (PlaylistNotFoundException)
            {
                return Problem($"Playlist with the specified ID: {id} not found", null, StatusCodes.Status404NotFound);
            }
        }

        [HttpGet("getByUser", Name = nameof(GetPlaylistByUser))]
        public async Task<IActionResult> GetPlaylistByUser(User user)
        {
            try
            {
                var result = await _playlistService.GetPlaylistByUserAsync(user);
                return Ok(result);
            }
            catch (PlaylistNotFoundException)
            {
                return Problem($"Playlist with the specified user:{user} not found", null, StatusCodes.Status404NotFound);
            }
        }

        [HttpPut(Name = nameof(ModifyPlaylist))]
        public async Task<IActionResult> ModifyPlaylist(Playlist modifiedPlaylist)
        {
            var result = await _playlistService.ModifyPlaylistAsync(modifiedPlaylist);
            return Ok(result);
        }

        [HttpDelete(Name = nameof(DeletePlaylist))]
        public async Task<IActionResult> DeletePlaylist(Playlist playlist)
        {
            if(!await _playlistService.DeletePlaylistAsync(playlist))
            {
                return Problem("Couldn't delete the playlist");
            }
            return Ok();
        }

        [HttpPost("item", Name = nameof(AddPlaylistItem))]
        public async Task<IActionResult> AddPlaylistItem(PlaylistItem playlistItem)
        {
            var result = await _playlistService.AddPlaylistItemAsync(playlistItem);
            return Ok(result);
        }

        [HttpPut("item", Name = nameof(ModifyPlaylistItem))]
        public async Task<IActionResult> ModifyPlaylistItem(PlaylistItem modifiedPlaylistItem)
        {
            var result = await _playlistService.ModifyPlaylistItemAsync(modifiedPlaylistItem);
            return Ok(result);
        }

        [HttpDelete("item", Name = nameof(DeletePlaylistItem))]
        public async Task<IActionResult> DeletePlaylistItem(PlaylistItem playlistItem)
        {
            if(!await _playlistService.DeletePlaylistItemAsync(playlistItem))
            {
                return Problem("Couldn't delete the playlist item");
            }
            return Ok();
        }
    }
}
