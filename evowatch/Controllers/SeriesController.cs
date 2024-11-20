using System.Net.Mime;
using evoWatch.Exceptions;
using evoWatch.Models.DTOs;
using evoWatch.Services;
using evoWatch.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace evoWatch.Controllers
{
    [ApiController]
    [Route("series")]

    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService _seriesService;

        public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var result = await _seriesService.GetSeriesAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSeriesById(Guid id)
        {
            try
            {
                var result = await _seriesService.GetSeriesByIdAsync(id);
                return Ok(result);
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("series not found");
            }
        }

        [HttpPost(Name = nameof(AddSeries))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSeries([FromBody] SeriesDTO series)
        {
            var result = await _seriesService.AddSeriesAsync(series);
            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSeries(Guid id, [FromBody] SeriesDTO series)
        {
            try
            {
                var result = await _seriesService.UpdateSeriesAsync(id, series);
                return Ok(result);
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("series not found");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSeriesAsync(Guid id)
        {
            try
            {
                var result = await _seriesService.DeleteSeriesAsync(id);             

                if (!result)
                {
                    return Problem("Failed to delete");
                }
                else
                {
                    return Ok();
                }
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("series not found");
            }
        }


    }
}
