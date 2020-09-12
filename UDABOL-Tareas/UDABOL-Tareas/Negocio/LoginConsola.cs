using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    public class LoginConsola : ILogin
    {
        public bool AutenticacionUsuario(string usuario, string contrasena)
        {
            throw new NotImplementedException();
        }

        public List<ITarea> MostrarManejadorTareas(IRol rol)
        {
            throw new NotImplementedException();
        }

        public IRol VerificarRolUsuario(IUsuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
