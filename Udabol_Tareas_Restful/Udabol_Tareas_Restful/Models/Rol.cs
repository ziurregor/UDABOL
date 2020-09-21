using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Udabol_Tareas_Restful.Models
{
    public class Rol
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean SuperUsuario { get; set; }
    }
}
