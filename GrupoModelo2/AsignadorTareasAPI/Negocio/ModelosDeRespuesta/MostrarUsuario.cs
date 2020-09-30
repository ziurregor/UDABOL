using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class MostrarUsuario
    {
        public int PersonaID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public int UsuarioID { get; set; }
        public string Username { get; set; }

        public MostrarEstadoUsuario EstadoUsuario { get; set; }
        public Rol Rol { get; set; }
    }
}
