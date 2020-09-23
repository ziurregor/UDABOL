using System;
using System.Collections.Generic;
using System.Text;
using Modelo;


namespace Dao
{
    public interface IConexion
    {
        public Boolean Conectar(Type tipo);

        public List<IObjetoTexto> LeerTabla();

        public List<T> LeerTabla<T>();

        public Boolean EscribirTabla(List<IObjetoTexto> lista);


        public Boolean EliminarRegistro(KeyValuePair<String,String> condicion);


        public Boolean Guardar();

    }
}
