using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        // GET: Tarea
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
        {
            return Ok(ModeloFactory.Listar("Modelo.Tarea"));

        }
        // GET: Tarea/5
        [HttpGet("{id}")]
        public Tarea GetTarea(int id)
        {
            return (Usuario)ModeloFactory.Obtener(new KeyValuePair<String, String>("id", id.ToString()), "Modelo.Usuario");
        }

        // PUT: Usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                ModeloFactory.Modificar(usuario, "Id");
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
            IObjetoTexto rol = ModeloFactory.Obtener(new KeyValuePair<String, String>("Id",id.ToString()), "Modelo.Usuario");
            return rol!=null;
        }


        // POST: Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            ModeloFactory.Crear(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // DELETE: Usuario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            Usuario usuario = (Usuario)ModeloFactory.Obtener(new KeyValuePair<string, string>("Id", id.ToString()), Type.GetType("Modelo.Usuario"));
            if (usuario == null)
            {
                return NotFound();
            }

            ModeloFactory.Eliminar(new KeyValuePair<string, string>("Id", id.ToString()), usuario.GetType());
            return usuario;
        }
    }
}
