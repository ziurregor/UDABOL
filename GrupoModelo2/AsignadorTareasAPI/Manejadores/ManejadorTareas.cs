using DAO;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ManejadorTareas : IManejadorTareas
    {
        private IBaseDeDatos _context;
        public ManejadorTareas(IBaseDeDatos context)
        {
            _context = context;
        }

        public Tarea ActualizarTarea(int id, Tarea tarea)
        {
            return _context.Tarea().Editar(id, tarea);
        }

        public Tarea CrearTarea(Tarea tarea)
        {
            return _context.Tarea().Crear(tarea);
        }

        public bool EliminarTarea(int id)
        {
            return _context.Tarea().Eliminar(id);
        }

        public MostrarTarea ObtenerTareaPorID(int id)
        {
            return ObtenerTareas().FirstOrDefault(ot => ot.TareaID == id);
        }

        public IEnumerable<MostrarTarea> ObtenerTareas()
        { 
            IEnumerable<Tarea> tareas = _context.Tarea().ObtenerTodo();
            IEnumerable<EstadoTarea> estadosTareas = _context.EstadoTarea().ObtenerTodo();
            IEnumerable<Persona> personas = _context.Persona().ObtenerTodo();
            IEnumerable<Usuario> usuarios = _context.Usuario().ObtenerTodo();
            IEnumerable<Estado> estados = _context.Estado().ObtenerTodo();
            return tareas.Join(estadosTareas, tarea => tarea.EstadoTareaID, estadoTarea => estadoTarea.EstadoTareaID,
                (tarea, estadoTarea) => new { tarea, estadoTarea })
                .Join(personas, te => te.tarea.PersonaID, persona => persona.PersonaID,
                (te, persona) => new { te.tarea, te.estadoTarea, persona })
                .Join(usuarios, tep => tep.persona.UsuarioID, usuario => usuario.UsuarioID,
                (tep, usuario) => new { tep.tarea, tep.estadoTarea, tep.persona, usuario})
                .Join(estados, teps => teps.estadoTarea.EstadoID, estado => estado.EstadoID,
                (teps, estado) => new { teps.tarea, teps.estadoTarea, teps.persona, teps.usuario, estado })
                .Select(tepse => new MostrarTarea
                {
                    TareaID = tepse.tarea.TareaID,
                    NombreTarea = tepse.tarea.NombreTarea,
                    Fecha = tepse.tarea.Fecha,
                    EstadoTarea = new MostrarEstadoTarea 
                    {
                        EstadoTareaID = tepse.tarea.EstadoTareaID,
                        EstadoID = tepse.estadoTarea.EstadoID,
                        NombreEstado = tepse.estado.NombreEstado
                    },
                    Usuario = new MostrarUsuario
                    {
                        PersonaID = tepse.persona.PersonaID,
                        Nombres = tepse.persona.Nombres,
                        Apellidos = tepse.persona.Apellidos,
                        UsuarioID = tepse.usuario.UsuarioID,
                        Username = tepse.usuario.Username
                    }
                });
        }
    }
}
