using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Dao;
using Modelo;

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


        public static Boolean Crear(IObjetoTexto fuente)
        {
            Type tipo = fuente.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();

            Dictionary<String, String> campos = new Dictionary<String, String>();
            foreach (PropertyInfo propiedadx in propiedades)
            {
                campos.Add(propiedadx.Name, propiedadx.GetValue(fuente).ToString());
            }

            return Crear(campos,tipo);
        }

        public static Boolean Crear(Dictionary<String,String> campos,Type tipo) {
            List<IObjetoTexto> lista = Listar(tipo);
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();
            IObjetoTexto objeto = darInstancia(tipo);
            foreach (PropertyInfo propiedad in _propiedadesClase) {
                foreach (KeyValuePair<String,String> campo in campos) {
                    if (campo.Key.Equals(propiedad.Name)) {
                        switch (propiedad.PropertyType.Name)
                        {
                            case "Int32":
                                propiedad.SetValue(objeto, Int32.Parse(campo.Value));
                                break;
                            case "Boolean":
                                propiedad.SetValue(objeto, Boolean.Parse(campo.Value));
                                break;
                            default:
                                propiedad.SetValue(objeto, campo.Value);
                                break;
                        }
                    }
                }
            }

            lista.Add(objeto);
            ConexionFactory.DarConexion(tipo).EscribirTabla(lista);


            return true;
        }

        //Rol (Id Nombre  SuperUsuario)(1 UsuarioComun false)
        // Modficar (id,SuperUsuario)(1 true)
        // Usuario (Id Nombre Contrasena Rol Estado) (1 fulanito xxxxxx 1 Habilitado)
        // Modificar (id,Estado)(1 Deshabilitado)----->(id,Nombre Contrasena Rol,Estado)(1  fulanito xxxxxx 1 Deshabilitado)

        public static Boolean Modificar<T>(T fuente, String identificador) {
            fuente = ValidarNulos<T>(fuente, identificador);
            if (fuente != null)
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



        public static T ValidarNulos<T>(T destino,string identificador)
        {
            if (destino != null)
            {
                PropertyInfo propiedadId = typeof(T).GetProperty(identificador);
                if (propiedadId != null)
                {
                    T origen = Obtener<T>(new KeyValuePair<string, string>(identificador, propiedadId.GetValue(destino).ToString()));
                    if (origen != null)
                    {
                        PropertyInfo[] propiedades = origen.GetType().GetProperties();
                        foreach (PropertyInfo propiedad in propiedades)
                        {
                            if (propiedad.GetValue(destino)==null || (propiedad.PropertyType.Name.Equals("Int32")&& propiedad.GetValue(destino).Equals(0)))
                            {
                                propiedad.SetValue(destino, propiedad.GetValue(origen));
                            }
                        }
                        return destino;
                    }
                }
            }
            return default;
        }



        // Update Usuario set nombre=Juana Perez,estado=Deshabilitado where id=2

        public static Boolean Modificar<T>(Dictionary<String, String> campos, KeyValuePair<String, String> condicion)
        {
            return Modificar(campos, condicion, typeof(T));
        }


        public static Boolean Modificar(Dictionary<String, String> campos, KeyValuePair<String, String> condicion, Type tipo)
        {
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();
            List<IObjetoTexto> listaAModificar = Listar(tipo);

            foreach (IObjetoTexto objeto in listaAModificar)
            {
                Type tipoObjeto = objeto.GetType();
                PropertyInfo _identificadorCondicion = tipoObjeto.GetProperty(condicion.Key);
                String _valor = _identificadorCondicion.GetValue(objeto).ToString();
                //id=2
                //if(objeto.id==2)
                if (_valor.Equals(condicion.Value))
                {
                    //Nombre=Juana......Estado=Deshabilitado
                    foreach (PropertyInfo propiedad in _propiedadesClase)
                    {
                        foreach (KeyValuePair<String, String> campo in campos)
                        {
                            if (propiedad.Name.Equals(campo.Key))
                            {
                                switch (propiedad.PropertyType.Name)
                                {
                                    case "Int32":
                                        propiedad.SetValue(objeto, Int32.Parse(campo.Value));
                                        break;
                                    default:
                                        propiedad.SetValue(objeto, campo.Value);
                                        break;
                                }
                                
                            }
                        }
                    }
                    ConexionFactory.DarConexion(tipo).EscribirTabla(listaAModificar);

                    return true;
                }
            }
            return false;
        }

        

        public static List<IObjetoTexto> Listar(Type tipo)
        {
            IConexion _conexion= ConexionFactory.DarConexion(tipo);
            List<IObjetoTexto> _lista = new List<IObjetoTexto>();

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




        public static List<IObjetoTexto> Listar(String tipo)
        {
            return Listar(Type.GetType(tipo));

        }


        public static T Obtener<T>(KeyValuePair<String, String> condicion)
        {
            return (T)Obtener(condicion, typeof(T));
        }


        public static IObjetoTexto Obtener(KeyValuePair<String, String> condicion,String tipoModelo)
        {
            return Obtener(condicion, Type.GetType(tipoModelo));
        }


        public static IObjetoTexto Obtener(KeyValuePair<String, String> condicion,Type tipoModelo)
        {

            List<IObjetoTexto> lista = Listar(tipoModelo);
            if (lista != null)
            {
                foreach (IObjetoTexto objeto in lista)
                {
                    if (objeto != null)
                    {
                        Object valor = ObtenerCampoValor(objeto, condicion.Key);

                        if (valor != null && valor.ToString().Equals(condicion.Value))
                        {
                            return objeto;
                        }
                    }
                }
            }
            return null;
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
        public static IObjetoTexto darInstancia(Type tipo) {
            return (IObjetoTexto)Activator.CreateInstance(tipo);
        }

        public static IObjetoTexto darInstancia(String tipo)
        {
            return darInstancia(Type.GetType(tipo));
        }


        public static T darInstancia<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }


        //Se obtiene un valor de un campo de un objeto enviandole solamente el nombre
        // Si el objeto es Rol... y le queremos obtener el valor del campo nombre
        //ModeloBase.ObtenerCampoValor(rol,"nombre");
        public static Object ObtenerCampoValor(IObjetoTexto objeto, String campo)
        {
            //ToTitleCase ---> PascalCase
            TextInfo textInfo = (new CultureInfo("es-BO", false)).TextInfo;
            PropertyInfo propiedad = objeto.GetType().GetProperty(textInfo.ToTitleCase(campo));
            if (propiedad != null)
            {
                return propiedad.GetValue(objeto);
            }
            return null;
        }
    }
}
