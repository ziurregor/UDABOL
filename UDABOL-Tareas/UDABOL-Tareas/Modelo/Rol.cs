using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo
{
<<<<<<< HEAD
    public class Rol :ModeloBase
=======
    class Rol :ModeloBase
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
    {

        private Int32 _id;//0
        private String _nombre;//Super Usuario/Usuario Comun
<<<<<<< HEAD
        private Boolean _superUsuario;


        //Getters and Setter

        public Boolean esSuperUsuario()//Get
        {
            return _superUsuario;
        }

        public Boolean ObtenerSuperUsuario() {
            return esSuperUsuario();
        }

        public void GuardarSuperUsuario(Boolean superUsuario)//Set
        {
            _superUsuario = superUsuario;
        }

=======


        //Getters and Setter
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
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
<<<<<<< HEAD
        public ModeloBase leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");
            if (columnas.Length > 2)
            {
                Rol rol = new Rol
                {
                    _id = Int32.Parse(columnas[0]),
                    _nombre = columnas[1],
                    _superUsuario=Boolean.Parse(columnas[2])
                }; return rol;
            }
            return null;
=======
        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");

            Rol rol = new Rol();
            rol._id = Int32.Parse(columnas[0]);
            rol._nombre = columnas[1];
            return rol;
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        }
    }
}
