using DAO;
using Modelo;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ManejadorRoles : IManejadorRoles
    {
        private IBaseDeDatos _context;
        public ManejadorRoles(IBaseDeDatos context)
        {
            _context = context;
        }

        public IEnumerable<Rol> ObtenerRoles()
        {
            return _context.Rol().ObtenerTodo();
        }

        public Rol ObtenerRolPorID(int id)
        {
            return _context.Rol().ObtenerUno(id);
        }
    }
}
