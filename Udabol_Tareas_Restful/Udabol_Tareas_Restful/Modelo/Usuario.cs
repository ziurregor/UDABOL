using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario : IObjetoTexto
    {
        public Int32  Id { get; set; }
        public String Nombre { get; set; }
        public String Contrasena { get; set; }
        public Rol Rol { get; set; }
        public String Estado { get; set; }

        public string guardarTexto()
        {
            throw new NotImplementedException();
        }

        public ModeloFactory leerTexto(string texto)
        {
            throw new NotImplementedException();
        }
    }
}
