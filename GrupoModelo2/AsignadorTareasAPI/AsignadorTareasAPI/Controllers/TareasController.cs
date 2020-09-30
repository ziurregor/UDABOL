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
    public class TareasController : ControllerBase
    {
        IManejadorTareas _manejador;
        public TareasController(IManejadorTareas manejador)
        {
            _manejador = manejador;
        }

        // GET: api/<Controller>
        [HttpGet]
        public ActionResult<IEnumerable<MostrarTarea>> Get()
        {
            return Ok(_manejador.ObtenerTareas());
        }

        // GET api/<Controller>/5
        [HttpGet("{id}")]
        public ActionResult<MostrarTarea> GetById(int id)
        {
            MostrarTarea result = _manejador.ObtenerTareaPorID(id);
            if (result == null)
            {
                return NotFound($"La tarea con ID: '{id}', no fue encontrada");
            }
            return Ok(result);
        }

        // POST api/<Controller>
        [HttpPost]
        public ActionResult<Tarea> Post([FromBody] Tarea tarea)
        {
            return Ok(_manejador.CrearTarea(tarea));
        }

        // PUT api/<Controller>/5
        [HttpPut("{id}")]
        public ActionResult<Tarea> Put(int id, [FromBody] Tarea tarea)
        {
            if ( id != tarea.TareaID)
            {
                return BadRequest($"Laos id's no coinciden");
            }
            Tarea result = _manejador.ActualizarTarea(id, tarea);
            if (result == null)
            {
                return BadRequest($"La tarea con ID: '{id}', no fue encontrada");
            }
            return Ok(result);
        }

        // DELETE api/<Controller>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool result = _manejador.EliminarTarea(id);
            if (result)
            {
                return Ok($"Tarea con ID: {id}, fue eliminada ");
            }
            return NotFound($"Tarea con ID: {id}, no fue encontrada ");
        }
    }
}
