using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udabol_Tareas_Restful.Models
{
    public class Usuario
    {
        public Int32  Id { get; set; }
        public String Nombre { get; set; }
        public String Contrasena { get; set; }
        public Rol Rol { get; set; }
        public String Estado { get; set; }
    }
}
