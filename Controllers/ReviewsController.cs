using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Destinations.Models;
using Microsoft.EntityFrameworkCore;

namespace Reviews.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private DestinationsContext _db;

    public ReviewsController(DestinationsContext db)
    {
      _db = db;
    }

    // GET api/animals
  [HttpGet]
    public ActionResult<IEnumerable<Review>> Get(string author, string text, string city, string country)
    {
      var query = _db.Reviews.Include(review => review.Destination).AsQueryable();

      if (author != null)
      {
        query = query.Where(entry => entry.Author == author);
      }

      if (text != null)
      {
        query = query.Where(entry => entry.Text == text);
      }

      if (city != null)
      {
        query = query.Where(entry => entry.Destination.City == city);
      }

      if (country != null)
      {
        query = query.Where(entry => entry.Destination.Country == country);
      }



      return query.ToList();
    }

    // POST api/animals
    [HttpPost]
    public void Post([FromBody] Review review)
    {
      _db.Reviews.Add(review);
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult<Review> Get(int id)
    {
        return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Review review)
    {
        review.ReviewId = id;
        _db.Entry(review).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id, string author)
    {
        var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id && entry.Author == author);
        _db.Reviews.Remove(reviewToDelete);
        _db.SaveChanges();     
    }
  }
}