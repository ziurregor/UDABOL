using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Modelo;
using Util;
using System.Text.Json;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {

        // GET: Todas las Tareas
        [HttpGet]
        public Mensaje GetTareas()
        {
            return Mensaje.INGRESA_LOGIN;
        }

        // GET: Todas las Tareas
        [HttpGet("{sesionId}")]
        public Object GetTareas(String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId) !=null)
            {
                return ManejadorTareas.Listar();
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // GET: Tarea/5
        [HttpGet("{id}/{sesionId}")]
        public Object GetTarea(int id,String sesionId)
        {
            if (Sesion.VerificarSesion(sesionId) != null)
            {
                return ManejadorTareas.Obtener(id);
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // PUT: Tarea/5
        [HttpPut("{id}/{sesionId}")]
        public Mensaje PutTarea(int id,String sesionId, JsonElement objeto)
        {
            if (Sesion.VerificarSesion(sesionId) != null)
            {
                if (objeto.TryGetProperty("id", out JsonElement jsonId) && !jsonId.ToString().Equals(id.ToString()))
                {
                    return Mensaje.DATOS_ID;
                }


                if (ManejadorTareas.Modificar(objeto,sesionId))
                {
                    return Mensaje.MODIFICO_EXITO;
                }

                return Mensaje.NO_MODIFICAR;
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // POST: Tarea
        [HttpPost("{sesionId}")]
        public Object PostTarea(String sesionId, Tarea tarea)
        {
            if (ManejadorTareas.Crear(tarea, sesionId))
            {
                return GetTarea(tarea.Id, sesionId);
            }
            return Mensaje.SESION_INCORRECTA;
        }

        // DELETE: Tarea/5
        [HttpDelete("{id}/{sesionId}")]
        public Object DeleteTarea(int id, string sesionId)
        {
            Tarea tarea = ManejadorTareas.Eliminar(id, sesionId);
            if (tarea != null)
            {
                return tarea;
            }
            return Mensaje.SESION_INCORRECTA;
        }
    }
}
