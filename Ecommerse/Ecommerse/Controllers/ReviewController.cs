using Ecommerse.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly DB_EcommerseContext dbContext;

        public ReviewController(DB_EcommerseContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get()
        {
            var datos = dbContext.Reviews.ToArray();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetById(int id)
        {
            var result = dbContext.Reviews.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Review review)
        {
            dbContext.Reviews.Add(review);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = review.IdReview }, review);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Reviews.Find(id);
            if (result == null)
                return NotFound();

            dbContext.Reviews.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}


