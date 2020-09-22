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
            return Id.ToString() + "\t" + Nombre+"\t"+SuperUsuario.ToString();
        }

        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");
            if (columnas.Length > 2)
            {
                Rol rol = new Rol
                {
                    Id = Int32.Parse(columnas[0]),
                    Nombre = columnas[1],
                    SuperUsuario = Boolean.Parse(columnas[2])
                }; return rol;
            }
            return null;
        }
    }
}
