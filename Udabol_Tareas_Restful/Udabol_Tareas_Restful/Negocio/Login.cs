using System;
using System.Collections.Generic;
using Util;
using Modelo;

namespace Negocio
{
    public static class Login
    {
        public static KeyValuePair<Usuario, String>? Autenticar(String usuario, String contrasena)
        {
            contrasena = Utilidades.encriptarContrasena(usuario, contrasena);
            Usuario _usuario = ModeloFactory.Obtener<Usuario>(new KeyValuePair<string, string>("nombre", usuario));
            if (_usuario != null && _usuario.Contrasena.Equals(contrasena))
            {

                return new KeyValuePair<Usuario, string>(_usuario, Sesion.CrearSesion(_usuario));
            }
            return null;
        }

        public static KeyValuePair<Usuario, String>? Autenticar(String sesionId)
        {
            Usuario _usuario = Sesion.VerificarSesion(sesionId);
            if (_usuario != null)
            {
                return new KeyValuePair<Usuario, string>(_usuario, Sesion.CrearSesion(_usuario));
            }
            return null;
        }
    }
}
