using DAO;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ManejadorEstados : IManejadorEstados
    {
        private IBaseDeDatos _context;
        public ManejadorEstados(IBaseDeDatos context)
        {
            _context = context;
        }

        public IEnumerable<MostrarEstadoUsuario> ObtenerEstadosUsuario()
        {
            IEnumerable<Estado> estados = _context.Estado().ObtenerTodo();
            IEnumerable<EstadoUsuario> estadoUsuarios = _context.EstadoUsuario().ObtenerTodo();
            return estadoUsuarios.Join(estados, estadoUsuario => estadoUsuario.EstadoID, estado => estado.EstadoID,
                (estadoUsuario, estado) => new { estadoUsuario, estado })
                .Select(elemento => 
                new MostrarEstadoUsuario
                {
                    EstadoID = elemento.estadoUsuario.EstadoID,
                    EstadoUsuarioID = elemento.estadoUsuario.EstadoUsuarioID,
                    NombreEstado = elemento.estado.NombreEstado
                });
        }

        public IEnumerable<MostrarEstadoTarea> ObtenerEstadosTareas()
        {
            IEnumerable<Estado> estados = _context.Estado().ObtenerTodo();
            IEnumerable<EstadoTarea> estadoTareas = _context.EstadoTarea().ObtenerTodo();
            return estadoTareas.Join(estados, estadoTarea => estadoTarea.EstadoID, estado => estado.EstadoID,
                (estadoTarea, estado) => new { estadoTarea, estado })
                .Select(elemento =>
                new MostrarEstadoTarea
                {
                    EstadoID = elemento.estadoTarea.EstadoID,
                    EstadoTareaID = elemento.estadoTarea.EstadoTareaID,
                    NombreEstado = elemento.estado.NombreEstado
                });
        }

        public Estado ObtenerRolPorID(int id)
        {
            return _context.Estado().ObtenerUno(id);
        }
    }
}
