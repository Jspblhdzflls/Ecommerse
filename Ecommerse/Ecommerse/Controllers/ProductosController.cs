using Ecommerse.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ecommerse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly DB_EcommerseContext dbContext;
        
        public ProductosController(DB_EcommerseContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            var datos = dbContext.Productos.ToArray();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var result = dbContext.Productos.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Producto producto)
        {
            dbContext.Productos.Add(producto);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = producto.IdProducto }, producto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Productos.Find(id);
            if (result == null)
                return NotFound();

            dbContext.Productos.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Producto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }

            var result = dbContext.Productos.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            dbContext.Productos.Update(result);
            result.DescripcionProducto = model.DescripcionProducto;
            result.IdCategoria = model.IdCategoria;
            result.PrecioProducto = model.PrecioProducto;
            result.Cantidad = model.Cantidad;

            dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}


