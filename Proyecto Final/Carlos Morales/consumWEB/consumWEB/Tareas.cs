using System;
using System.Collections.Generic;

namespace consumWEB
{
    public class Tarea : ModeloBase
    {

        public Int32 Id;//{ get; set; }
        public String Fecha;//{ get; set; }
        public String Nombre;//{ get; set; }

        private Usuario _usuario;
        public Int32 Usuario;//{ get { return _usuario != null ? _usuario.Id : 0; } set { _usuario = ModeloFactory.Obtener<Usuario>(new KeyValuePair<string, string>("Id", value.ToString())); } }
        public String Estado;//{ get; set; }

        public Tarea()
        {
            _usuario = new Usuario();
        }


        public Usuario GetUsuario()
        {
            return _usuario;
        }

        override
        public List<string> OrdenCampos()
        {
            return new List<string>() { "Id", "Fecha", "Nombre", "Usuario", "Estado" };
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
