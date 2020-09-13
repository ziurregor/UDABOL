using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    interface IConexion
    {
        public Boolean Conectar(String cadenaDeConexion, Type tipo);

        public List<Object> LeerTabla();

        public Boolean EscribirTabla(List<Object> lista);


        public Boolean EliminarTabla(Int32 numeroLinea);


        public Boolean Guardar();

    }
}
