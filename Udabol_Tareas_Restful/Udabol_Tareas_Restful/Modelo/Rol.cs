using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negocio;

namespace Modelo
{
    public class Rol : ModeloBase
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean SuperUsuario { get; set; }

        override
        public List<string> OrdenCampos()
        {
            return new List<string>() { "Id","Nombre","SuperUsuario"};
        }

        override
        public String darLlave()
        {
            return "Id";
        }
        
        override
        public Boolean llaveEsAutoIncremental()
        {
            return true;
        }
    }
}
