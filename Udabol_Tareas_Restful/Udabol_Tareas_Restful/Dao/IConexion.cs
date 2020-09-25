using System;
using System.Collections.Generic;
using System.Text;
using Modelo;


namespace Dao
{
    public interface IConexion
    {
        public Boolean Conectar(Type tipo);

        public List<IModeloBase> LeerTabla();

        public List<T> LeerTabla<T>();

        public Boolean EscribirTabla(List<IModeloBase> lista);

        public Boolean Modificar(Dictionary<String, String> campos, KeyValuePair<String, String> condicion);

        public Boolean EliminarRegistro(KeyValuePair<String,String> condicion);

        public Boolean Guardar();

        bool Crear(IModeloBase fuente);
    }
}
