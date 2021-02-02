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
    public class CategoriaController : ControllerBase
    {
        private readonly DB_EcommerseContext dbContext;

        public CategoriaController(DB_EcommerseContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Categorium>> Get()
        {
            var datos = dbContext.Categoria.ToArray();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public ActionResult<Categorium> GetById(int id)
        {
            var result = dbContext.Categoria.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Categorium categoria)
        {
            dbContext.Categoria.Add(categoria);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = categoria.IdCategoria }, categoria);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Categoria.Find(id);
            if (result == null)
                return NotFound();

            dbContext.Categoria.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Categorium model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }

            var result = dbContext.Categoria.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            dbContext.Categoria.Update(result);
            result.DescripcionCategoria = model.DescripcionCategoria;


            dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}


