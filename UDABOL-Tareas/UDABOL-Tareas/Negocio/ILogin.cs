using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    interface ILogin
    {
        public Usuario AutenticacionUsuario(String usuario, String contrasena);
        public Rol VerificarRolUsuario(Usuario usuario);

        public List<ModeloBase > MostrarManejadorTareas(Rol rol);
        
    }
}
