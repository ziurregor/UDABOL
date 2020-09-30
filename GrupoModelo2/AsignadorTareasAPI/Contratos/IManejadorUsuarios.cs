using Modelo;
using System.Collections.Generic;

namespace Negocio
{
    public interface IManejadorUsuarios
    {
        public IEnumerable<MostrarUsuario> ObtenerUsuarios();
        public MostrarUsuario ObtenerUsuarioPorID(int id);
        public MostrarUsuario CrearUsuario(PersonaUsuario usuario);
        public MostrarUsuario ActualizarUsuario(int id, PersonaUsuario usuario);
        public bool EliminarUsuario(int id);
    }
}
