using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
<<<<<<< HEAD
    public class Usuario : ModeloBase
=======
    class Usuario : ModeloBase
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
    {

        private Int32 _id;
        private String _nombre;
        private String _contrasena;
        private String _estado;
        private Rol _rol;

        public String ObtenerNombre()//Get
        {
            return _nombre;
        }

        public void GuardarNombre(String nombre)//Set
        {
            _nombre = nombre;
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


        public String ObtenerContraseña()
        {
            return _contrasena;
        }

        public void GuardarContrasena(String contrasena)
        {
            _contrasena = contrasena;
        }

<<<<<<< HEAD
        public static Usuario ObtenerUnUsuario(string usuario, string cadenaEncriptada)
        {

            KeyValuePair<String, String> condicion = new KeyValuePair<string, string>("nombre",usuario);
            Usuario _usuario= (Usuario)ModeloBase.Obtener(condicion,Type.GetType("Modelo.Usuario"));
            if (_usuario != null && _usuario.ObtenerContraseña().Equals(cadenaEncriptada)) {
                return _usuario;
            }
            return null;
        }

=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        public String ObtenerEstado()
        {
            return _estado;
        }

        public void GuardarEstado(String estado)
        {
            _estado = estado;
        }

        public Rol ObtenerRol()
        {
            return _rol;
        }

        public void GuardarRol(Rol rol)
        {
            _rol = rol;
        }



        public override string guardarTexto()
        {
            return _id + "\t" + _nombre + "\t" + _contrasena + "\t" + _estado + "\t"+_rol.ObtenerId().ToString() ;
        }

<<<<<<< HEAD
        public override ModeloBase leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");
            if (columnas.Length > 4)
            {
                Usuario usuario = new Usuario
                {
                    _id = Int32.Parse(columnas[0]),
                    _nombre = columnas[1],
                    _contrasena = columnas[2],
                    _estado = columnas[3],
                    _rol = (Rol)(new Rol()).Obtener(new KeyValuePair<string, string>("id", columnas[4]))
                };
                return usuario;
            }
            return null;
=======
        public override IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");

            Usuario usuario = new Usuario();
            usuario._id = Int32.Parse(columnas[0]);
            usuario._nombre = columnas[1];
            usuario._contrasena = columnas[2];
            usuario._estado = columnas[3];
            usuario._rol = (Rol)(new Rol()).Obtener(new KeyValuePair<string, string>("_id",columnas[4])) ;
            return usuario;
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        }
    }
}
