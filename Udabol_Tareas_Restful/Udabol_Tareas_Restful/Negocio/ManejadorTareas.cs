using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
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

        public static bool Modificar(JsonElement objetoJson, string sesionId)
        {

            Dictionary<String, String> campos = ModeloFactory.ValidarNulos<Tarea>(objetoJson, "Id");
            if (campos.Count > 0)
            {
                Usuario usuario = Sesion.VerificarSesion(sesionId);


                if (usuario != null && ((campos.ContainsKey("Usuario") && usuario.Id.ToString() == campos["Usuario"]) || usuario.GetRol().SuperUsuario))
                {
                    if (usuario.GetRol().SuperUsuario)
                    {
                        return ModeloFactory.Modificar<Tarea>(campos, new KeyValuePair<string, string>("Id", objetoJson.GetProperty("id").ToString()));
                    }
                    else
                    {
                        //solo puede modificar el Estado
                        if (objetoJson.TryGetProperty("estado", out JsonElement estado))
                        {
                            return ModeloFactory.Modificar<Tarea>(new Dictionary<string, string> { { "Estado", estado.ToString() } }, new KeyValuePair<string, string>("Id", objetoJson.GetProperty("id").ToString()));
                        }
                    }
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
