using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Destinations.Models;

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
    public ActionResult<IEnumerable<Review>> Get(string author, string text)
    {
      var query = _db.Reviews.AsQueryable();

      if (author != null)
      {
        query = query.Where(entry => entry.Author == author);
      }

      if (text != null)
      {
        query = query.Where(entry => entry.Text == text);
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
    public void Delete(int id)
    {
        var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
        _db.Reviews.Remove(reviewToDelete);
        _db.SaveChanges();     
    }
  }
}