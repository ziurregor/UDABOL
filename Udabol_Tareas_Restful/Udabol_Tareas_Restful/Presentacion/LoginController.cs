using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Modelo;
using Negocio;
using Util;

namespace Udabol_Tareas_Restful.Presentacion
{
    [EnableCors]
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: Login
        [HttpGet]
        public Mensaje GetLogin()
        {
            return Mensaje.USUARIO_CONTRASENA;
        }

        // GET: Login/usuario/contrasena
        [HttpGet("{usuario}/{contrasena}")]
        public Mensaje GetLogin(String usuario,String contrasena)
        {
            //Nullable 
            KeyValuePair<Usuario,String>? usuarioLlave= Login.Autenticar(usuario, contrasena);
            if (usuarioLlave != null && usuarioLlave.HasValue) {
                return new Mensaje() {
                    Texto = "Bienvenido Usuario: " + usuarioLlave.Value.Key.Nombre + ", del tipo: " + usuarioLlave.Value.Key.GetRol().Nombre+", Su sesion expira: "+Sesion.ObtenerTiempoExpiracion(usuarioLlave.Value.Value),
                    Llave=usuarioLlave.Value.Value
                };
            }
            return Mensaje.AUTENTICACION_INCORRECTA;
        }

        // POST: Login
        [HttpPost]
        public Mensaje PostLogin(LoginDatos datos)
        {
            return GetLogin(datos.Usuario,datos.Contrasena);
        }

    }
}
