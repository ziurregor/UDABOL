using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;

namespace Modelo
{
    public class Usuario : IObjetoTexto
    {
        public Int32  Id { get; set; }
        public String Nombre { get; set; }

        public String _contrasena;
        public String Contrasena { get { return _contrasena; } set {_contrasena=Utilidades.encriptarContrasena(Nombre,value);} }

        private Rol _rol;
        public Int32 Rol { get { return _rol.Id; } set { _rol = (Rol)ModeloFactory.Obtener(new KeyValuePair<string, string>("Id", value.ToString()), "Modelo.Rol"); } }

        public Usuario() {
            _rol = new Rol();
        }


        public String Estado { get; set; }

        public string guardarTexto()
        {
            return Id.ToString() + "\t" + Nombre+ "\t" + Contrasena+ "\t" + Rol.ToString() + "\t" + Estado;
        }

        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");
            if (columnas.Length > 4)
            {
                Usuario usuario = new Usuario
                {
                    Id = Int32.Parse(columnas[0]),
                    Nombre = columnas[1],
                    Contrasena = columnas[2],
                    Rol = Int32.Parse( columnas[3]),
                    Estado = columnas[4]
                }; return usuario;
            }
            return null;
        }
    }
}
