using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Dao
{
    interface IConexion
    {
        public Boolean Conectar(String cadenaDeConexion, Type tipo);

        public List<ModeloBase> LeerTabla();

        public Boolean EscribirTabla(List<ModeloBase> lista);


        public Boolean EliminarRegistro(Int32 numeroLinea);


        public Boolean Guardar();

    }
}
