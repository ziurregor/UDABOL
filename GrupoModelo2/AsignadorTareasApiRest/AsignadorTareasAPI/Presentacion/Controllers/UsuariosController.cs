using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        IManejadorUsuarios _manejador;
        public UsuariosController(IManejadorUsuarios manejador)
        {
            _manejador = manejador;
        }
        // GET: api/<UsuariosController>
        [HttpGet]
        public ActionResult<IEnumerable<MostrarUsuario>> Get()
        {
            return Ok(_manejador.ObtenerUsuarios());
        }

        // GET api/<Controller>/5
        [HttpGet("{id}")]
        public ActionResult<MostrarUsuario> GetById(int id)
        {
            MostrarUsuario result = _manejador.ObtenerUsuarioPorID(id);
            if (result == null)
            {
                return NotFound($"El usuario con ID: '{id}', no fue encontrado");
            }
            return Ok(result);
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult<MostrarUsuario> Post([FromBody] PersonaUsuario usuario)
        {
            MostrarUsuario resultado = _manejador.CrearUsuario(usuario);
            if (resultado == null) BadRequest($"el nombre de usuario (username) '{usuario.Username}', ya esta en uso, elija otro");
            return Ok(resultado);
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult<MostrarUsuario> Put(int id, [FromBody] PersonaUsuario usuario)
        {
            MostrarUsuario result = _manejador.ActualizarUsuario(id, usuario);
            if (result == null)
            {
                return BadRequest($"El usuario con ID: '{id}', no fue encontrado");
            }
            return Ok(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result = _manejador.EliminarUsuario(id);
            if (result)
            {
                return Ok(result);
            }
            return NotFound($"Usuario con ID: {id}, no fue encontrado");
        }
    }
}
