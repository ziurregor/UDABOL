using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Dao;
using Modelo;
using Util;

namespace Negocio
{
    public class ModeloFactory
    {
        //CRUD....
        //Create Crear
        //Retreive Obtener
        //Update Modificar
        //Delete Eliminar

        //Reflection ----> Ingenieria Inversa... Analizar o modificar la estructura de un objeto

        //Id: 1
        // Nombre: Fulanito de Tal
        // Estado: Habilitado
        // Insert Usuario(id,nombre,contrasena,estado)values(1,Fulanito de tal,******,Habilitado)


        public static Boolean Crear(IModeloBase fuente)
        {
            if (fuente != null)
            {
                IConexion conexion = ConexionFactory.DarConexion(fuente.GetType());
                String llave = fuente.darLlave();
                Boolean esAutoIncremental = fuente.llaveEsAutoIncremental();

                if(llave!=null && !llave.Equals("") && esAutoIncremental){
                    PropertyInfo propiedad = fuente.GetType().GetProperty(llave);
                    if (propiedad != null && (propiedad.GetValue(fuente)==null || (propiedad.GetValue(fuente) != null && propiedad.PropertyType.Name.Equals("Int32") && propiedad.GetValue(fuente).Equals(0)))) {
                        int max=Int32.Parse(conexion.LeerTabla().Max(p => propiedad.GetValue(p)).ToString());
                        propiedad.SetValue(fuente, max + 1);
                    }
                }

                return conexion.Crear(fuente);
            }
            return false;
        }


        //Rol (Id Nombre  SuperUsuario)(1 UsuarioComun false)
        // Modficar (id,SuperUsuario)(1 true)
        // Usuario (Id Nombre Contrasena Rol Estado) (1 fulanito xxxxxx 1 Habilitado)
        // Modificar (id,Estado)(1 Deshabilitado)----->(id,Nombre Contrasena Rol,Estado)(1  fulanito xxxxxx 1 Deshabilitado)

        public static Boolean Modificar<T>(T fuente, String identificador)
        {
            if (fuente!= null)
            {
                Type tipo = typeof(T);
                PropertyInfo propiedad = tipo.GetProperty(identificador);
                PropertyInfo[] propiedades = tipo.GetProperties();
                KeyValuePair<String, String> condicion = new KeyValuePair<String, String>(identificador, propiedad.GetValue(fuente).ToString());
                Dictionary<String, String> campos = new Dictionary<String, String>();
                foreach (PropertyInfo propiedadx in propiedades)
                {
                    if (propiedadx.Name != identificador)
                    {
                        campos.Add(propiedadx.Name, propiedadx.GetValue(fuente).ToString());
                    }
                }

                return Modificar(campos, condicion, tipo);
            }
            return false;
        }


        public static Boolean Modificar<T>(JsonElement fuente, String identificador) {
            Dictionary<String, String> campos = ValidarNulos<T>(fuente, identificador);
            if (campos.Count > 0) {
                KeyValuePair<String, String> condicion = new KeyValuePair<string, string>(identificador,fuente.TryGetProperty(Utilidades.firstLower(identificador),out JsonElement jsonId)?jsonId.ToString():"");
                return Modificar<T>(campos, condicion);
            }
            return false;
        }



        public static Dictionary<String,String> ValidarNulos<T>(JsonElement jsonObjeto,String identificador) {

            Dictionary<String, String> campos = new Dictionary<string, string>();
            PropertyInfo[] propiedades = typeof(T).GetProperties();
            try
            {
                JsonElement jsonId = jsonObjeto.GetProperty(Utilidades.firstLower(identificador));
                T objeto = ModeloFactory.Obtener<T>(new KeyValuePair<string, string>(identificador,jsonId.ToString()));

                foreach (PropertyInfo propiedad in propiedades)
                {
                    if (jsonObjeto.TryGetProperty(Utilidades.firstLower(propiedad.Name), out JsonElement jsonCampo))
                    {
                        MethodInfo metodo = jsonCampo.GetType().GetMethod("Get" + propiedad.PropertyType.Name);
                        Object valorCampo = metodo.Invoke(jsonCampo, null);
                        campos.Add(propiedad.Name, valorCampo.ToString());
                    }
                    else {
                        campos.Add(propiedad.Name, propiedad.GetValue(objeto).ToString());
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

            return campos;
        }


        // Update Usuario set nombre=Juana Perez,estado=Deshabilitado where id=2

        public static Boolean Modificar<T>(Dictionary<String, String> campos, KeyValuePair<String, String> condicion)
        {
            return Modificar(campos, condicion, typeof(T));
        }


        public static Boolean Modificar(Dictionary<String, String> campos, KeyValuePair<String, String> condicion, Type tipo)
        {
            return ConexionFactory.DarConexion(tipo).Modificar(campos, condicion);
        }

        

        public static List<IModeloBase> Listar(Type tipo)
        {
            IConexion _conexion= ConexionFactory.DarConexion(tipo);
            List<IModeloBase> _lista = new List<IModeloBase>();

            if (_conexion != null)
            {
                _lista = _conexion.LeerTabla();
            }
            return _lista;

        }

        public static List<T> Listar<T>()
        {
            IConexion _conexion = ConexionFactory.DarConexion(typeof(T));
            List<T> _lista = new List<T>();

            if (_conexion != null)
            {
                _lista = _conexion.LeerTabla<T>();
            }
            return _lista;

        }




        public static List<IModeloBase> Listar(String tipo)
        {
            return Listar(Type.GetType(tipo));

        }


        public static T Obtener<T>(KeyValuePair<String, String> condicion)
        {
            return (T)Obtener(condicion, typeof(T));
        }


        public static IModeloBase Obtener(KeyValuePair<String, String> condicion,String tipoModelo)
        {
            return Obtener(condicion, Type.GetType(tipoModelo));
        }


        public static IModeloBase Obtener(KeyValuePair<String, String> condicion,Type tipoModelo)
        {
            return ConexionFactory.DarConexion(tipoModelo).Obtener(condicion);
        }

        //delete from Usuario where id=2

        internal static Boolean Eliminar<T>(KeyValuePair<string, string> condicion)
        {
            return Eliminar(condicion, typeof(T));
        }

        public static Boolean Eliminar(KeyValuePair<String, String> condicion, Type tipo)
        {
            IConexion conexion = ConexionFactory.DarConexion(tipo);
            if (conexion.EliminarRegistro(condicion))
            {
                conexion.Guardar();
                return true;
            }
            return false;
        }

        // Crear Una Instancia automaticamente
        //ModeloBase.darInstancia("Modelo.Rol")----->new Rol()
        //ModeloBase.darInstancia("Modelo.Usuario")----->new Usuario()
        //Factory Method--->Patron de diseño
        public static IModeloBase darInstancia(Type tipo) {
            return (IModeloBase)Activator.CreateInstance(tipo);
        }

        public static IModeloBase darInstancia(String tipo)
        {
            return darInstancia(Type.GetType(tipo));
        }


        public static T darInstancia<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }


        
    }
}
