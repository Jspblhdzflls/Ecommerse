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
    public class CarritoControler : ControllerBase
    {

        private readonly DB_EcommerseContext dbContext;

        public CarritoControler(DB_EcommerseContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Carrito>> Get()
        {
            var datos = dbContext.Carritos.ToArray();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public ActionResult<Carrito> GetById(int id)
        {
            var result = dbContext.Carritos.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Carrito carrito)
        {
            dbContext.Carritos.Add(carrito);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = carrito.IdCarrito }, carrito);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Carritos.Find(id);
            if (result == null)
                return NotFound();

            dbContext.Carritos.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }


    }
}


