using DAO;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Negocio
{
    public class ManejadorUsuarios : IManejadorUsuarios
    {
        private IBaseDeDatos _context;
        public ManejadorUsuarios(IBaseDeDatos context)
        {
            _context = context;
        }

        public MostrarUsuario ActualizarUsuario(int id, PersonaUsuario personaUsuario)
        {
            MostrarUsuario viejoUsuario = ObtenerUsuarioPorID(id);
            if (viejoUsuario != null)
            {
                Persona viejaPersona = _context.Persona().ObtenerTodo().FirstOrDefault(p => p.UsuarioID == viejoUsuario.UsuarioID);
                Usuario nuevoUsuario = new Usuario
                {
                    UsuarioID = viejoUsuario.UsuarioID,
                    Username = personaUsuario.Username,
                    Password = personaUsuario.Password,
                    EstadoUsuarioID = personaUsuario.EstadoUsuarioID,
                    RolID = personaUsuario.RolID
                };
                nuevoUsuario = _context.Usuario().Editar(id, nuevoUsuario);
                Persona nuevaPersona = new Persona
                {
                    PersonaID = viejaPersona.PersonaID,
                    Nombres = personaUsuario.Nombres,
                    Apellidos = personaUsuario.Apellidos,
                    UsuarioID = nuevoUsuario.UsuarioID
                };
                nuevaPersona = _context.Persona().Editar(viejaPersona.PersonaID, nuevaPersona);
                return ObtenerUsuarioPorID(nuevoUsuario.UsuarioID);
            }
            return null;
        }

        public MostrarUsuario CrearUsuario(PersonaUsuario personaUsuario)
        {
            Usuario usuario = new Usuario
            {
                Username = personaUsuario.Username,
                Password = personaUsuario.Password,
                EstadoUsuarioID = personaUsuario.EstadoUsuarioID,
                RolID = personaUsuario.RolID
            };
            usuario = _context.Usuario().Crear(usuario);
            Persona persona = new Persona
            {
                Nombres = personaUsuario.Nombres,
                Apellidos = personaUsuario.Apellidos,
                UsuarioID = usuario.UsuarioID
            };
            persona = _context.Persona().Crear(persona);
            if (persona == null) return null;
            return ObtenerUsuarioPorID(usuario.UsuarioID);
        }

        public bool EliminarUsuario(int id)
        {
            return _context.Usuario().Eliminar(id);
        }

        public MostrarUsuario ObtenerUsuarioPorID(int id)
        {
            return ObtenerUsuarios().FirstOrDefault(mu => mu.UsuarioID == id);
        }

        public IEnumerable<MostrarUsuario> ObtenerUsuarios()
        {
            IEnumerable<Usuario> usuarios = _context.Usuario().ObtenerTodo();
            IEnumerable<Persona> personas = _context.Persona().ObtenerTodo();
            IEnumerable<EstadoUsuario> estadosUsuarios = _context.EstadoUsuario().ObtenerTodo();
            IEnumerable<Estado> estados = _context.Estado().ObtenerTodo();
            IEnumerable<Rol> roles = _context.Rol().ObtenerTodo();
            return usuarios
                .Join(personas, usuario => usuario.UsuarioID, persona => persona.UsuarioID,
                (usuario, persona) => new { usuario, persona })
                .Join(estadosUsuarios, up => up.usuario.EstadoUsuarioID, estadoUsuario => estadoUsuario.EstadoUsuarioID,
                (up, estadoUsuario) => new { up.usuario, up.persona, estadoUsuario })
                .Join(estados, upe => upe.estadoUsuario.EstadoID, estado => estado.EstadoID,
                (upe, estado) => new { upe.usuario, upe.persona, upe.estadoUsuario, estado })
                .Join(roles, upee => upee.usuario.RolID, rol => rol.RolID,
                (upee, rol) => new { upee.usuario, upee.persona, upee.estadoUsuario, upee.estado, rol })
                .Select(upeer => new MostrarUsuario
                {
                    PersonaID = upeer.persona.PersonaID,
                    Nombres = upeer.persona.Nombres,
                    Apellidos = upeer.persona.Apellidos,
                    UsuarioID = upeer.usuario.UsuarioID,
                    Username = upeer.usuario.Username,
                    Rol = upeer.rol,
                    EstadoUsuario = new MostrarEstadoUsuario
                    {
                        EstadoUsuarioID = upeer.estadoUsuario.EstadoUsuarioID,
                        EstadoID = upeer.estado.EstadoID,
                        NombreEstado = upeer.estado.NombreEstado
                    }
                });
        }
    }
}
