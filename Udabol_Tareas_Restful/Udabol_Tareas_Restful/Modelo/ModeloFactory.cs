using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Dao;

namespace Modelo
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

        public static Boolean Modificar(IObjetoTexto fuente,String identificador) {
            Type tipo = fuente.GetType();
            PropertyInfo propiedad = tipo.GetProperty(identificador);
            PropertyInfo[] propiedades = tipo.GetProperties();

            KeyValuePair<String, String> condicion = new KeyValuePair<String, String>(identificador, propiedad.GetValue(fuente).ToString());
            Dictionary<String, String> campos = new Dictionary<String, String>();
            foreach (PropertyInfo propiedadx in propiedades)
            {
                if (propiedadx.Name != identificador) {
                    campos.Add(propiedadx.Name,propiedadx.GetValue(fuente).ToString());
                }
            }

            return Modificar(campos,condicion,tipo);
        }


        



        // Update Usuario set nombre=Juana Perez,estado=Deshabilitado where id=2


        public static Boolean Modificar(Dictionary<String,String> campos,KeyValuePair<String,String> condicion,Type tipo) {
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();
            List<IObjetoTexto> listaAModificar = Listar(tipo);

            foreach (IObjetoTexto objeto in listaAModificar) {
                Type tipoObjeto = objeto.GetType();
                PropertyInfo _identificadorCondicion= tipoObjeto.GetProperty(condicion.Key);
                String _valor = _identificadorCondicion.GetValue(objeto).ToString();
                //id=2
                //if(objeto.id==2)
                if (_valor.Equals(condicion.Value))
                {
                    //Nombre=Juana......Estado=Deshabilitado
                    foreach (PropertyInfo propiedad in _propiedadesClase)
                    {
                        foreach (KeyValuePair<String,String> campo in campos)
                        {
                            if (propiedad.Name.Equals(campo.Key))
                            {
                                propiedad.SetValue(objeto, campo.Value);
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

        public static List<IObjetoTexto> Listar(String tipo)
        {
            return Listar(Type.GetType(tipo));

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

        public static Boolean Eliminar(KeyValuePair<String, String> condicion, Type tipo)
        {
            List<IObjetoTexto> listaAEliminar = Listar(tipo);
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();

            foreach (IObjetoTexto objeto in listaAEliminar)
            {
                Type tipoObjeto = objeto.GetType();
                PropertyInfo _identificadorCondicion = tipoObjeto.GetProperty(condicion.Key);
                String _valor = _identificadorCondicion.GetValue(objeto).ToString();
                //id=2
                //if(objeto.id==2)
                if (_valor.Equals(condicion.Value))
                {
                    int nroLinea = listaAEliminar.IndexOf(objeto);

                    ConexionFactory.DarConexion(tipoObjeto).EliminarRegistro(nroLinea);

                    return true;
                }
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
            return (IObjetoTexto)Activator.CreateInstance(Type.GetType(tipo));
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
