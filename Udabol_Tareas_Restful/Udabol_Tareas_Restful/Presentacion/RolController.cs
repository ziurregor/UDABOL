using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        // GET: Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRoles()
        {
            return Ok(ModeloFactory.Listar("Modelo.Rol"));

        }
        // GET: Rol/5
        [HttpGet("{id}")]
        public Rol GetRol(int id)
        {
            return (Rol)ModeloFactory.Obtener(new KeyValuePair<String, String>("id", id.ToString()), "Modelo.Rol");
        }

        // PUT: Rol/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.Id)
            {
                return BadRequest();
            }

            try
            {
                ModeloFactory.Modificar(rol, "Id");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool RolExists(int id)
        {
            IObjetoTexto rol = ModeloFactory.Obtener(new KeyValuePair<String, String>("Id",id.ToString()), "Modelo.Rol");
            return rol!=null;
        }


        // POST: Rol
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            ModeloFactory.Crear(rol);
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

        // DELETE: Rol/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            Rol rol = (Rol)ModeloFactory.Obtener(new KeyValuePair<string, string>("Id", id.ToString()), Type.GetType("Modelo.Rol"));
            if (rol == null)
            {
                return NotFound();
            }

            ModeloFactory.Eliminar(new KeyValuePair<string, string>("Id", id.ToString()), rol.GetType());
            return rol;
        }
    }
}
