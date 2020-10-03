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

<<<<<<< HEAD
        public List<ModeloBase > MostrarManejadorTareas(Rol rol);
=======
        public List<Tarea> MostrarManejadorTareas(Rol rol);
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        
    }
}
