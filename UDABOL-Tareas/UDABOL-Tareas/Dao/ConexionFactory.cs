using System;
using System.Collections.Generic;
using System.Text;

namespace Dao
{
    public class ConexionFactory
    {
        private static Dictionary<String, ConexionTexto> modelos = new Dictionary<String, ConexionTexto>();
        public static ConexionTexto DarConexion(Type tipo) {
            if (modelos.ContainsKey(tipo.Name))
            {
                return modelos[tipo.Name];
            }
            else {
                ConexionTexto conexion = new ConexionTexto();
                conexion.Conectar(tipo.Name + ".txt", tipo);
                return conexion;
            }
        }

        public static void GuardarConexiones() {
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
