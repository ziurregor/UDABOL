using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IManejadorRoles
    {
        public IEnumerable<Rol> ObtenerRoles();
        public Rol ObtenerRolPorID(int id);
    }
}
