using System.Net.Mime;
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

        [HttpPost(Name = nameof(AddSeries))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSeries([FromBody]SeriesDTO series)
        {
            await _seriesService.AddSeriesAsync(series);
            return Ok(series);
        }

        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            var result = await _seriesService.GetSeriesAsync();
            return Ok(result);
        }
    }
}
