using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    class Usuario : ModeloBase
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
        }
    }
}
