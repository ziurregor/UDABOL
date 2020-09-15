using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    class Rol : IRol
    {

        private Int32 _id;//0
        private String _nombre;//Fulanito De Tal


        public String ObtenerNombre()
        {
            return _nombre;
        }

        public void GuardarNombre(String nombre)
        {
            _nombre=nombre;
        }

        public Int32 ObtenerId()
        {
            return _id;
        }

        public void GuardarId(Int32 id)
        {
            _id = id;
        }

        public string guardarTexto()
        {
            return _id.ToString() + "\t" + _nombre.ToString();
        }

        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");

            Rol rol = new Rol();
            rol._id = Int32.Parse(columnas[0]);
            rol._nombre = columnas[1];
            return rol;

        }
    }
}
