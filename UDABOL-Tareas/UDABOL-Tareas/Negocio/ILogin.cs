using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    interface ILogin
    {
        public Usuario AutenticacionUsuario(String usuario, String contrasena);
        public Rol VerificarRolUsuario(Usuario usuario);

        public List<Tarea> MostrarManejadorTareas(Rol rol);
        
    }
}
