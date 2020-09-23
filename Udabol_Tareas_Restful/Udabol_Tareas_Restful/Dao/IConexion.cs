using System;
using System.Collections.Generic;
using System.Text;
using Modelo;


namespace Dao
{
    interface IConexion
    {
        public Boolean Conectar(String cadenaDeConexion, Type tipo);

        public List<IObjetoTexto> LeerTabla();

        public List<T> LeerTabla<T>();

        public Boolean EscribirTabla(List<IObjetoTexto> lista);


        public Boolean EliminarRegistro(Int32 numeroLinea);


        public Boolean Guardar();

    }
}
