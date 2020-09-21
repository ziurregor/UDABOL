using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo;

namespace Modelo
{
    public class Rol:IObjetoTexto
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Boolean SuperUsuario { get; set; }

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
