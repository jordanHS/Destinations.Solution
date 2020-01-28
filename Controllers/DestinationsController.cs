using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Destinations.Models;

namespace Destinations.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DestinationsController : ControllerBase
  {
    private DestinationsContext _db;

    public DestinationsController(DestinationsContext db)
    {
      _db = db;
    }

    // GET api/animals
  [HttpGet]
    public ActionResult<IEnumerable<Destination>> Get(string country, string city, int rating)
    {
      var query = _db.Destinations.AsQueryable();

      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if(city != null)
      {
        query = query.Where(entry => entry.Rating == rating);
      }

      return query.ToList();
    }

    // POST api/animals
    [HttpPost]
    public void Post([FromBody] Destination destination)
    {
      _db.Destinations.Add(destination);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Destination> Get(int id)
    {
        return _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Destination destination)
    {
        destination.DestinationId = id;
        _db.Entry(destination).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        var destinationToDelete = _db.Destinations.FirstOrDefault(entry => entry.DestinationId == id);
        _db.Destinations.Remove(destinationToDelete);
        _db.SaveChanges();     
    }
  }
}