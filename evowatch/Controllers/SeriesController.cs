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

        /// <summary>
        ///  List of all series.
        /// </summary>
        /// <response code="200">The list of series was successfully listed.</response>
        [HttpGet(Name = nameof(GetSeries))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(IEnumerable<SeriesDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSeries()
        {
            var result = await _seriesService.GetSeriesAsync();
            return Ok(result);
        }

        /// <summary>
        /// List a series by id.
        /// </summary>
        /// <param name="id">The unique identifier of the series.</param>
        /// <response code="200">The series was successfully retrieved.</response>
        /// <response code="404">The series was not found.</response>
        [HttpGet("{id:guid}", Name = nameof(GetSeriesById))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SeriesDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSeriesById(Guid id)
        {
            try
            {
                var result = await _seriesService.GetSeriesByIdAsync(id);
                return Ok(result);
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("Series not found");
            }
        }

        /// <summary>
        /// Adds a new series.
        /// </summary>
        /// <param name="series">The series data to add.</param>
        /// <response code="200">The series was successfully added.</response>
        [HttpPost(Name = nameof(AddSeries))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SeriesDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddSeries([FromBody] SeriesDTO series)
        {
            var result = await _seriesService.AddSeriesAsync(series);
            return Ok(result);
        }

        /// <summary>
        /// Updates an existing series id.
        /// </summary>
        /// <param name="id">The unique identifier of the series to update.</param>
        /// <param name="series">The updated series data.</param>
        /// <response code="200">The series was successfully updated.</response>
        /// <response code="404">The series was not found.</response>
        [HttpPut("{id:guid}", Name = nameof(UpdateSeries))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(SeriesDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateSeries(Guid id, [FromBody] SeriesDTO series)
        {
            try
            {
                var result = await _seriesService.UpdateSeriesAsync(id, series);
                return Ok(result);
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("Series not found");
            }
        }

        /// <summary>
        /// Deletes a series id.
        /// </summary>
        /// <param name="id">The unique identifier of the series to delete.</param>
        /// <response code="200">The series was successfully deleted.</response>
        /// <response code="404">The series was not found.</response>
        /// <response code="500">Failed to delete the series.</response>
        [HttpDelete("{id:guid}", Name = nameof(DeleteSeriesAsync))]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSeriesAsync(Guid id)
        {
            try
            {
                var result = await _seriesService.DeleteSeriesAsync(id);

                if (!result)
                {
                    return Problem("Failed to delete", null, StatusCodes.Status500InternalServerError);
                }
                else
                {
                    return Ok();
                }
            }
            catch (SeriesNotFoundException)
            {
                return NotFound("Series not found");
            }
        }


    }
}
