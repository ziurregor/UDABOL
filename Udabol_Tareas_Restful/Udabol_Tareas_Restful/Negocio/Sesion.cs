using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;
using Modelo;

namespace Negocio
{
    public static class Sesion
    {
        public static String CrearSesion(Usuario usuario) {
            if (usuario != null) {
                return EncriptaSesion(usuario);
            }
            return "";
        }

        private static string EncriptaSesion(Usuario usuario)
        {
            return Utilidades.ABase64(usuario.Contrasena + "," + DateTime.Now.AddMinutes(Configuracion.tiempoSesion).ToFileTime().ToString());
        }

        public static Usuario VerificarSesion(String sesionId,Boolean superUsuario)
        {
            if (sesionId != null && !sesionId.Equals(""))
            {
                KeyValuePair<Usuario, DateTime>? usuarioTiempo = DecriptaSesion(sesionId);
                if (usuarioTiempo != null && usuarioTiempo.HasValue)
                {
                    DateTime tiempo = usuarioTiempo.Value.Value;
                    if (tiempo > DateTime.Now && usuarioTiempo.Value.Key != null && (usuarioTiempo.Value.Key.GetRol().SuperUsuario == superUsuario || usuarioTiempo.Value.Key.GetRol().SuperUsuario))
                    {

                        return usuarioTiempo.Value.Key;
                    }
                }
            }
            return null;
        }

        public static DateTime ObtenerTiempoExpiracion(String sesionId) {
            if (sesionId != null && !sesionId.Equals(""))
            {
                KeyValuePair<Usuario, DateTime>? usuarioTiempo = DecriptaSesion(sesionId);
                if (usuarioTiempo != null && usuarioTiempo.HasValue)
                {
                    if (usuarioTiempo.Value.Value != null) {
                        return usuarioTiempo.Value.Value;
                    }
                }
            }
            return DateTime.Now;
        }

        public static Usuario VerificarSesion(String sesionId) {
            return VerificarSesion(sesionId, false);
        }

        public static KeyValuePair<Usuario, DateTime>? DecriptaSesion(String sesionId) {
            if (sesionId != null && !sesionId.Equals("")) {
                String[] texto=Utilidades.DeBase64(sesionId).Split(",");
                if (texto.Length > 1)
                {
                    Usuario usuario = ModeloFactory.Obtener<Usuario>(new KeyValuePair<string, string>("contrasena", texto[0]));
                    if (usuario != null) {
                        return new KeyValuePair<Usuario, DateTime>(usuario, DateTime.FromFileTime(Int64.Parse(texto[1])));
                    }
                }
            }
            return null;
        }


    }
}
