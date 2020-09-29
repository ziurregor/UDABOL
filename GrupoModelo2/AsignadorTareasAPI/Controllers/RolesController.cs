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
    public class RolesController : ControllerBase
    {
        IManejadorRoles _manejadorRoles;
        public RolesController(IManejadorRoles manejadorRoles)
        {
            _manejadorRoles = manejadorRoles;
        }
        // GET: api/<RolController>
        [HttpGet]
        public IEnumerable<Rol> Get()
        {
            return _manejadorRoles.ObtenerRoles();
        }
    }
}
