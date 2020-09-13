using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    interface ILogin
    {
        public IUsuario AutenticacionUsuario(String usuario, String contrasena);
        public IRol VerificarRolUsuario(IUsuario usuario);

        public List<ITarea> MostrarManejadorTareas(IRol rol);
        
    }
}
