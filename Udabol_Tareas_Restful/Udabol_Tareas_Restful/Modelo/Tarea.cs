using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Negocio;

namespace Modelo
{
    public class Tarea : IObjetoTexto
    {

        public Int32 Id { get; set; }
        public String Fecha { get; set; }
        public String Nombre { get; set; }

        private Usuario _usuario;
        public Int32 Usuario { get { return _usuario.Id; } set { _usuario = ModeloFactory.Obtener<Usuario>(new KeyValuePair<string, string>("Id", value.ToString())); } }
        public String Estado { get; set; }

        public Tarea()
        {
            _usuario = new Usuario();
        }


        public Usuario GetUsuario() {
            return _usuario;
        }


        public string guardarTexto()
        {
            return Id.ToString() + "\t" + Fecha + "\t" + Nombre + "\t" + Usuario.ToString() + "\t" + Estado;
        }

        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");

            if (columnas.Length > 4)
            {
                return new Tarea
                {
                    Id = Int32.Parse(columnas[0]),
                    Fecha = columnas[1],
                    Nombre = columnas[2],
                    Usuario = Int32.Parse(columnas[3]),
                    Estado = columnas[4]
                };
            }

            return null;
        }
    }
}
