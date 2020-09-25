using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Modelo;
using Util;
using System.Reflection;
using System.Text.Json;
using static System.Text.Json.JsonElement;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {

        // GET: Todos los Roles
        [HttpGet]
        public Mensaje GetRoles()
        {
            return Mensaje.INGRESA_LOGIN;
        }

        // GET: Rol
        [HttpGet("{sesionId}")]
        public Object GetRoles(String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId,true) != null)
            {
                return ModeloFactory.Listar<Rol>();
            }
            return Mensaje.SESION_INCORRECTA;

        }
        // GET: Rol/5
        [HttpGet("{id}/{sesionId}")]
        public Object GetRol(int id, String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                return ModeloFactory.Obtener<Rol>(new KeyValuePair<String, String>("id", id.ToString()));
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // PUT: Rol/5
        [HttpPut("{id}/{sesionId}")]
        public Mensaje PutRol(int id, String sesionId, JsonElement objeto)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {

                if (objeto.TryGetProperty("id",out JsonElement jsonId) && !jsonId.ToString().Equals(id.ToString()))
                {
                    return Mensaje.DATOS_ID;
                }

                if (ModeloFactory.Modificar<Rol>(objeto, "Id"))
                {
                    return Mensaje.MODIFICO_EXITO;
                }

                return Mensaje.NO_MODIFICAR;
            }
            return Mensaje.SESION_INCORRECTA;
        }


        // POST: Rol
        [HttpPost("{sesionId}")]
        public Object PostRol(String sesionId, Rol rol)
        {
            if (Sesion.VerificarSesion(sesionId,true) != null)
            {
                if (ModeloFactory.Crear(rol))
                {
                    return GetRol(rol.Id, sesionId);
                }
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // DELETE: Rol/5
        [HttpDelete("{id}/{sesionId}")]
        public Object DeleteRol(int id,String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId,true) != null)
            {
                Rol rol = ModeloFactory.Obtener<Rol>(new KeyValuePair<string, string>("Id", id.ToString()));
                if (rol == null)
                {
                    return Mensaje.DATOS_ID;
                }

                if (ModeloFactory.Eliminar<Rol>(new KeyValuePair<string, string>("Id", id.ToString())))
                {
                    return rol;
                }
            }
            return Mensaje.SESION_INCORRECTA;
        }
    }
}
