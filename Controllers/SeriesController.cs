using evoWatch.Models;
using evoWatch.Models.DTO;
using evoWatch.Services;
using Microsoft.AspNetCore.Mvc;


namespace evoWatch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        
        private static List<Series> seriesList = new List<Series>
        {
            new Series { Id = 1, Title = "Breaking Bad", Description = "xy", Genre = "Drama", Seasons = 5 },
            new Series { Id = 2, Title = "Stranger Things", Description = "", Genre = "Science Fiction", Seasons = 4 }
        };

        // GET: api/series
        [HttpGet]
        public ActionResult<IEnumerable<Series>> GetAllSeries()
        {
            return Ok(seriesList);
        }

        // GET: api/series/{id}
        [HttpGet("{id}")]
        public ActionResult<Series> GetSeries(int id)
        {
            Series series = seriesList.FirstOrDefault(s => s.Id == id);
            if (series == null)
            {
                return NotFound();
            }
            return Ok(series);
        }

        // POST: api/series
        [HttpPost]
        public ActionResult<Series> AddSeries([FromBody] Series newSeries)
        {
            newSeries.Id = seriesList.Max(s => s.Id) + 1; 
            seriesList.Add(newSeries);
            return CreatedAtAction(nameof(GetSeries), new { id = newSeries.Id }, newSeries);
        }

        // PUT: api/series/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSeries(int id, [FromBody] Series updatedSeries)
        {
            var existingSeries = seriesList.FirstOrDefault(s => s.Id == id);
            if (existingSeries == null)
            {
                return NotFound();
            }

            existingSeries.Title = updatedSeries.Title;
            existingSeries.Description = updatedSeries.Description;
            existingSeries.Genre = updatedSeries.Genre;
            existingSeries.Seasons = updatedSeries.Seasons;

            return NoContent();
        }

        // DELETE: api/series/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSeries(int id)
        {
            Series series = seriesList.FirstOrDefault(s => s.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            seriesList.Remove(series);
            return NoContent();
        }
    }
}
