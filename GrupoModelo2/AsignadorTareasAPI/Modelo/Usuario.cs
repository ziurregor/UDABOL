using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EstadoUsuarioID { get; set; }
        public int RolID { get; set; }

        public virtual EstadoUsuario EstadoUsuario { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
