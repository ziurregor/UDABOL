using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Util;
using Negocio;

namespace Modelo
{
    public class Usuario : ModeloBase
    {
        public Int32  Id { get; set; }
        public String Nombre { get; set; }

        public String _contrasena;//variable oculta
        public String Contrasena { get { return _contrasena; } set {_contrasena=Utilidades.encriptarContrasena(Nombre,value); } }

        private Rol _rol;//variable oculta de Tipo Rol
        public Int32 Rol { get { return _rol!=null?_rol.Id:0; } set { _rol = ModeloFactory.Obtener<Rol>(new KeyValuePair<string, string>("Id", value.ToString())); } }

        public Usuario() {
            _rol = new Rol();
        }


        public String Estado { get; set; }

        public Rol GetRol() {
            return _rol;
        }

        public void SetContrasena(String contrasena) {
            _contrasena = contrasena;
        }

        override
        public List<string> OrdenCampos()
        {
            return new List<string>() { "Id", "Nombre", "Contrasena","Rol","Estado" };
        }

        override
        public Dictionary<String, String> Excepciones()
        {
            return new Dictionary<string, string>() { { "Contrasena","SetContrasena"} };
        }

        override
        public String darLlave()
        {
            return "Id";
        }

        override
        public Boolean llaveEsAutoIncremental()
        {
            return true;
        }
    }
}
