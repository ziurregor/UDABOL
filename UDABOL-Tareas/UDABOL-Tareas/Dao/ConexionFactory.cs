using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public class ConexionFactory //patron de diseño Factory....   Singleton.....
    {
        private static Dictionary<String, ConexionTexto> modelos = new Dictionary<String, ConexionTexto>();
        public static ConexionTexto DarConexion(Type tipo) {
            if (modelos.ContainsKey(tipo.Name))//solo devuelve el objeto ya creado
            {
                return modelos[tipo.Name];
            }
            else {// se crea la primera vez que se lo llama
                ConexionTexto conexion = new ConexionTexto();
                conexion.Conectar(tipo.Name + ".txt", tipo);
                return conexion;
            }
        }

        public static void GuardarConexiones() {//guardar todos los datos en los archivos
            if (modelos != null && modelos.Count > 0) {
                foreach (KeyValuePair<String,ConexionTexto> modeloConexion in modelos)
                {
                    if (modeloConexion.Value != null) {
                        modeloConexion.Value.Guardar();
                    }
                }
            }
        }
    }
}
