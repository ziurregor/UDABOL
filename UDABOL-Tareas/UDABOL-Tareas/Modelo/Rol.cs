using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
    class Rol :ModeloBase
    {

        private Int32 _id;//0
        private String _nombre;//Super Usuario/Usuario Comun


        //Getters and Setter
        public String ObtenerNombre()//Get
        {
            return _nombre;
        }

        public void GuardarNombre(String nombre)//Set
        {
            _nombre=nombre;
            //guardar Historial de modificacion del Nombre del Rol
        }

        public Int32 ObtenerId()
        {
            return _id;
        }

        public void GuardarId(Int32 id)
        {
            _id = id;
        }

        override
        public string guardarTexto()
        {
            return _id.ToString() + "\t" + _nombre.ToString();
        }

        override
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
