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
    public class UsuarioController : ControllerBase
    {
        private readonly DB_EcommerseContext dbContext;

        public UsuarioController(DB_EcommerseContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            var datos = dbContext.Usuarios.ToArray();
            return Ok(datos);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
            var result = dbContext.Usuarios.Find(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = usuario.IdUsuaro }, usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = dbContext.Usuarios.Find(id);
            if (result == null)
                return NotFound();

            dbContext.Usuarios.Remove(result);
            dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Usuario model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Parametros invalidos");
            }

            var result = dbContext.Usuarios.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            dbContext.Usuarios.Update(result);
            result.NombreUsuario = model.NombreUsuario;
            result.ContrasenaUsuario = model.ContrasenaUsuario;
            result.CorreoUsuario = model.CorreoUsuario;
            

            dbContext.Entry(result).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}


