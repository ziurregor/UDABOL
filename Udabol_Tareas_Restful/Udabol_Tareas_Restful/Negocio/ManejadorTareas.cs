using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modelo;

namespace Negocio
{
    public static class ManejadorTareas
    {
        public static List<Tarea> Listar() {
                return ModeloFactory.Listar<Tarea>();
        }


        //un usuario solo puede modificar sus propias tareas a menos que sea un SuperUsuario
        public static bool Modificar(Tarea tarea, string sesionId)
        {
            Usuario usuario = Sesion.VerificarSesion(sesionId);
            tarea = ModeloFactory.ValidarNulos<Tarea>(tarea, "Id");
            if (usuario != null && tarea != null && tarea.GetUsuario() != null && (usuario.Id == tarea.GetUsuario().Id || usuario.GetRol().SuperUsuario))
            {
                if (usuario.GetRol().SuperUsuario)
                {
                    return ModeloFactory.Modificar(tarea, "Id");
                }
                else
                {
                    //solo puede modificar el Estado
                    return ModeloFactory.Modificar<Tarea>(new Dictionary<string, string> { { "Estado", tarea.Estado } }, new KeyValuePair<string, string>("Id", tarea.Id.ToString()));
                }
            }
            return false;
        }

        

        public static bool Crear(Tarea tarea, string sesionId)
        {
            Usuario usuario = Sesion.VerificarSesion(sesionId, true);
            if (usuario != null) {
                return ModeloFactory.Crear(tarea);
            }
            return false;
        }

        public static Tarea Obtener(int id)
        {
            return ModeloFactory.Obtener<Tarea>(new KeyValuePair<String, String>("id", id.ToString()));
        }

        public static Tarea Eliminar(int id, string sesionId)
        {
            if (Sesion.VerificarSesion(sesionId, true) != null)
            {
                Tarea tarea = ModeloFactory.Obtener<Tarea>(new KeyValuePair<string, string>("Id", id.ToString()));
                if (tarea != null)
                {
                    if (ModeloFactory.Eliminar<Tarea>(new KeyValuePair<string, string>("Id", id.ToString())))
                    {
                        return tarea;
                    }
                }
            }
            return null;
        }
    }
}
