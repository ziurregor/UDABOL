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
    public class EstadosController : ControllerBase
    {
        IManejadorEstados _manejador;
        public EstadosController(IManejadorEstados manejador)
        {
            _manejador = manejador;
        }
        // GET: api/<EstadoController>/info
        [Route("info")]
        [HttpGet]
        public ActionResult<string> GetEstadoController()
        {
            return Ok("Estados Controller");
        }
        // GET: api/<EstadoController>/tarea
        [Route("tareas")]
        [HttpGet]
        public ActionResult<IEnumerable<MostrarEstadoTarea>> GetEstadoTareas()
        {
            return Ok(_manejador.ObtenerEstadosTareas());
        }
        // GET: api/<EstadoController>/usuario
        [Route("usuarios")]
        [HttpGet]
        public ActionResult<IEnumerable<MostrarEstadoUsuario>> GetEstadoUsuarios()
        {
            return Ok(_manejador.ObtenerEstadosUsuario());
        }
    }
}
