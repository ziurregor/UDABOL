using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Modelo;
using Util;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // GET: Todos los Usuarios
        [HttpGet]
        public Mensaje GetRoles()
        {
            return Mensaje.INGRESA_LOGIN;
        }
        // GET: Usuario
        [HttpGet("{sesionId}")]
        public Object GetUsuarios(String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId,true) != null)
            {
                return ModeloFactory.Listar<Usuario>();
            }
            return Mensaje.SESION_INCORRECTA;
        }
        // GET: Usuario/5
        [HttpGet("{id}/{sesionId}")]
        public Object GetUsuario(int id,String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                return ModeloFactory.Obtener<Usuario>(new KeyValuePair<String, String>("id", id.ToString()));
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // GET: Usuario/tareas/5
        [HttpGet("tareas/{id}/{sesionId}")]
        public Object GetUsuarioTareas(int id, String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                return ModeloFactory.Obtener<Tarea>(new KeyValuePair<String, String>("usuario", id.ToString()));
            }
            return Mensaje.SESION_INCORRECTA;
        }


        // PUT: Usuario/5
        [HttpPut("{id}/{sesionId}")]
        public Mensaje PutUsuario(int id,String sesionId, JsonElement objeto)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                if (objeto.TryGetProperty("id", out JsonElement jsonId) && !jsonId.ToString().Equals(id.ToString()))
                {
                    return Mensaje.DATOS_ID;
                }
                String identificador = "Id";
                Dictionary<String, String> campos = ModeloFactory.ValidarNulos<Usuario>(objeto, identificador);
                if (campos.Count > 0)
                {
                    KeyValuePair<String, String> condicion = new KeyValuePair<string, string>(identificador, campos[identificador]);
                    if (objeto.TryGetProperty("contrasena",out JsonElement jsonCon)) {
                        campos["Contrasena"] = Utilidades.encriptarContrasena(campos["Nombre"],campos["Contrasena"]);
                    }
                    if (ModeloFactory.Modificar<Usuario>(campos, condicion))
                    {
                        return Mensaje.MODIFICO_EXITO;
                    }
                }
                return Mensaje.NO_MODIFICAR;
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // POST: Usuario
        [HttpPost("{sesionId}")]
        public Object PostUsuario(String sesionId,Usuario usuario)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                if (ModeloFactory.Crear(usuario))
                {
                    return GetUsuario(usuario.Id, sesionId);
                }
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // DELETE: Usuario/5
        [HttpDelete("{id}/{sesionId}")]
        public Object DeleteUsuario(int id,String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                Usuario usuario = ModeloFactory.Obtener<Usuario>(new KeyValuePair<string, string>("Id", id.ToString()));
                if (usuario == null)
                {
                    return Mensaje.DATOS_ID;
                }

                if (ModeloFactory.Eliminar<Usuario>(new KeyValuePair<string, string>("Id", id.ToString())))
                {
                    return usuario;
                }

            }
            return Mensaje.SESION_INCORRECTA;
            
        }
    }
}
