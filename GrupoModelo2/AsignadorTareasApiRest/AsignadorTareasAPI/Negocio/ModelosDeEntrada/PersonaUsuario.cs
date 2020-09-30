using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class PersonaUsuario
    {
        //public int PersonaID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        //public int UsuarioID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EstadoUsuarioID { get; set; }
        public int RolID { get; set; }
    }
}
