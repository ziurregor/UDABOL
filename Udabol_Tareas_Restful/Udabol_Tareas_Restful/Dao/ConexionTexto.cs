using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Modelo;
using Negocio;
using Util;

namespace Dao
{
    public class ConexionTexto : IConexion
    {
        private String _archivo;
        private String _contenido;
        private Type _tipo;

        public bool Conectar(Type tipo)
        {
            try
            {
                _tipo = tipo;
                _archivo = tipo.Name+".txt";
                if (File.Exists(_archivo))
                {
                    _contenido = File.ReadAllText(_archivo);
                }
                else _contenido = "";
                return true;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Ha ocurrido un Error: "+ex.Message);
            }
            return false;
        }

        //Update
        public Boolean Modificar(Dictionary<String,String> campos,KeyValuePair<String,String> condicion) {
            List<IModeloBase> listaAModificar = LeerTabla();
            foreach (IModeloBase objeto in listaAModificar)
            {
                Type tipoObjeto = objeto.GetType();
                PropertyInfo _identificadorCondicion = tipoObjeto.GetProperty(condicion.Key);
                String _valor = _identificadorCondicion.GetValue(objeto).ToString();
                //id=2
                //if(objeto.id==2)
                if (_valor.Equals(condicion.Value))
                {
                    Dictionary<String, String> excepciones = objeto.Excepciones();

                    foreach (KeyValuePair<String, String> campo in campos)
                    {
                        PropertyInfo propiedad = tipoObjeto.GetProperty(campo.Key);
                        Utilidades.PasarValorCampo(excepciones,propiedad,objeto,campo.Value);
                    }
                    EscribirTabla(listaAModificar);

                    return true;
                }
            }
            return false;
        }

        


        /* ROL
         * 1    Usuario Comun
         * 2    Super Usuario
         * 
         * Usuario
         * 
         * 1    Fulanito de tal 1
         * 2    SuperUsuario    2
         * 
         * 
         */

        public Boolean EliminarRegistro(KeyValuePair<String,String> condicion)
        {

            List<IModeloBase> listaAEliminar = LeerTabla();
            PropertyInfo[] _propiedadesClase = _tipo.GetProperties();

            foreach (IModeloBase objeto in listaAEliminar)
            {
                Type tipoObjeto = objeto.GetType();
                PropertyInfo _identificadorCondicion = tipoObjeto.GetProperty(condicion.Key);
                String _valor = _identificadorCondicion.GetValue(objeto).ToString();
                if (_valor.Equals(condicion.Value))
                {
                    int nroLinea = listaAEliminar.IndexOf(objeto);

                    String[] lineas = _contenido.Split("\n");
                    _contenido = "";

                    for (int i = 0; i < lineas.Length; i++)
                    {
                        if (i != nroLinea && lineas[i] != null && !lineas[i].Trim().Equals(""))
                        {
                            _contenido += lineas[i] + "\n";
                        }
                    }

                    return true;
                }
            }

            return true;
        }

        public bool EscribirTabla( List<IModeloBase> lista)
        {
            try
            {
                if (lista != null )
                {
                    _contenido = ConvertirATexto(lista);
                    File.WriteAllText(_archivo, _contenido);
                    return true;
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            return false;
        }

        private string ConvertirATexto(List<IModeloBase> lista)
        {
            String contenido = "";
            if (lista.Count > 0)
            {
                PropertyInfo[] propiedades = _tipo.GetProperties();
                List<String> lineas = new List<string>();
                foreach (IModeloBase _objeto in lista)
                {
                    if (_objeto != null)
                    {
                        String[] campos = propiedades.Select(p => p.GetValue(_objeto).ToString()).ToArray();
                        lineas.Add(String.Join("\t",campos));
                    }
                }
                contenido = String.Join("\n",lineas);
            }
            return contenido;
        }

        public bool Guardar()
        {
            try
            {
                File.WriteAllText(_archivo, _contenido, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            return false;
        }

        public List<IModeloBase> LeerTabla()
        {
            return ConvertirDeTexto(_contenido); 
        }

        private List<IModeloBase> ConvertirDeTexto(string contenido)
        {
            List<IModeloBase> lista = new List<IModeloBase>();

            if (contenido != null && !contenido.Trim().Equals("")) {
                String[] lineas = contenido.Split("\n").Select(p=>p.Trim()).ToArray();
                foreach (String linea in lineas)
                {
                    if (!linea.Equals(""))
                    {
                        String[] camposValor = linea.Split("\t").Select(p => p.Trim()).ToArray();
                        IModeloBase objeto = ModeloFactory.darInstancia(_tipo);
                        IngresarContenido(objeto,camposValor);
                        lista.Add(objeto);
                    }
                }
            }

            return lista;
        }

        private void IngresarContenido(IModeloBase objeto,String[] camposValor)
        {
            List<String> listaCampos = objeto.OrdenCampos();
            int indice = 0;

            Dictionary<String, String> excepciones = objeto.Excepciones();

            foreach (String campo in listaCampos)
            {
                if (camposValor.Length > indice && !campo.Trim().Equals("") && !camposValor[indice].Trim().Equals(""))
                {
                    PropertyInfo propiedad = _tipo.GetProperty(campo);
                    Utilidades.PasarValorCampo(excepciones, propiedad, objeto, camposValor[indice]);
                }
                indice++;
            }
        }

        public List<T> LeerTabla<T>()
        {
            return ConvertirDeTexto<T>(_contenido);
        }

        private List<T> ConvertirDeTexto<T>(string contenido)
        {
            List<T> lista = new List<T>();

            if (contenido != null && !contenido.Trim().Equals(""))
            {
                String[] lineas = contenido.Split("\n").Select(p => p.Trim()).ToArray();
                foreach (String linea in lineas)
                {
                    if (!linea.Trim().Equals(""))
                    {
                        String[] camposValor = linea.Split("\t").Select(p => p.Trim()).ToArray();
                        IModeloBase objeto = ModeloFactory.darInstancia(typeof(T));
                        IngresarContenido(objeto, camposValor);
                        lista.Add((T)objeto);
                    }
                }
            }

            return lista;
        }

        public bool Crear(IModeloBase fuente)
        {
            if (fuente != null)
            {
                List<IModeloBase> lista = LeerTabla();
                lista.Add(fuente);
                EscribirTabla(lista);
                return true;
            }
            return false;
        }

    }
}