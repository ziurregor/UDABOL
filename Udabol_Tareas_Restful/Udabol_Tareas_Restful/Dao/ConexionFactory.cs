using System;
using System.Collections.Generic;
using System.Text;
using Util;

namespace Dao
{
    public class ConexionFactory //patron de diseño Factory....   Singleton.....
    {
        private static Dictionary<String, IConexion> modelos = new Dictionary<String, IConexion>();
        public static IConexion DarConexion(Type tipo) {
            if (modelos.ContainsKey(tipo.Name))//solo devuelve el objeto ya creado
            {
                return modelos[tipo.Name];
            }
            else {// se crea la primera vez que se lo llama
                IConexion conexion = null;
                switch (Configuracion.baseDatos)
                {
                    case Configuracion.Database.SQLite:
                        conexion = new ConexionSqlite();
                        break;
                    default:
                        conexion= new ConexionTexto();
                        break;
                }
                conexion.Conectar(tipo);
                return conexion;
            }
        }

        public static void GuardarConexiones() {//guardar todos los datos en los archivos
            if (modelos != null && modelos.Count > 0) {
                foreach (KeyValuePair<String, IConexion> modeloConexion in modelos)
                {
                    if (modeloConexion.Value != null) {
                        modeloConexion.Value.Guardar();
                    }
                }
            }
        }
    }
}
