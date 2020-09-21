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


         public static Boolean Crear(Dictionary<String,String> campos,List<IObjetoTexto> lista,Type tipo) {

            PropertyInfo[] _propiedadesClase = tipo.GetProperties();
            IObjetoTexto objeto = darInstancia(tipo);
            foreach (PropertyInfo propiedad in _propiedadesClase) {
                foreach (KeyValuePair<String,String> campo in campos) {
                    if (campo.Key.Equals(propiedad.Name)) {
                        propiedad.SetValue(objeto, campo.Value);
                    }
                }
            }

            lista.Add(objeto);
            ConexionFactory.DarConexion(tipo).EscribirTabla(lista);


            return true;
        }


        // Update Usuario set nombre=Juana Perez,estado=Deshabilitado where id=2


        public static Boolean Modificar(Dictionary<String,String> campos,KeyValuePair<String,String> condicion,List<ModeloFactory> listaAModificar,Type tipo) {
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();

            foreach (ModeloFactory objeto in listaAModificar) {
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
                    IConexion _conexion = ConexionFactory.DarConexion(tipo);
                    _conexion.EscribirTabla(listaAModificar);

                    return true;
                }
            }
            return false;
        }



        // select * from Usuario

        public List<ModeloFactory> Listar() {

            List<ModeloFactory> _lista = new List<ModeloFactory>();

            if (_conexion != null)
            {
                _lista = _conexion.LeerTabla();
            }
            return _lista;

        }

        public static List<ModeloFactory> Listar(Type tipo)
        {
            IConexion _conexion= ConexionFactory.DarConexion(tipo);
            List<ModeloFactory> _lista = new List<ModeloFactory>();

            if (_conexion != null)
            {
                _lista = _conexion.LeerTabla();
            }
            return _lista;

        }

        public static List<ModeloFactory> Listar(String tipo)
        {
            return Listar(Type.GetType(tipo));

        }



        public ModeloFactory Obtener(KeyValuePair<String,String> condicion) {
            return Obtener(condicion, this.GetType());
        }

        public static ModeloFactory Obtener(KeyValuePair<String, String> condicion,String tipoModelo)
        {
            return Obtener(condicion, Type.GetType(tipoModelo));
        }


        public static ModeloFactory Obtener(KeyValuePair<String, String> condicion,Type tipoModelo)
        {

            List<ModeloFactory> lista = ((ModeloFactory)Activator.CreateInstance(tipoModelo) ).Listar();
            if (lista != null)
            {
                Type tipo = tipoModelo;
                foreach (ModeloFactory objeto in lista)
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

        //Se obtiene un valor de un campo de un objeto enviandole solamente el nombre
        // Si el objeto es Rol... y le queremos obtener el valor del campo nombre
        //ModeloBase.ObtenerCampoValor(rol,"nombre");
        public static Object ObtenerCampoValor(ModeloFactory objeto,String campo) {
            //ToTitleCase ---> PascalCase
            TextInfo textInfo = (new CultureInfo("es-BO", false)).TextInfo;
            MethodInfo metodo = objeto.GetType().GetMethod("Obtener"+textInfo.ToTitleCase(campo));
            if (metodo != null) {
                return metodo.Invoke(objeto, null);
            }
            return null;
        }

        //Guarda el valor de un campo que pertenece a un modelo
        //ModeloBase.GuardarCampoValor(usuario,"nombre"."rosario")
        //usuario.GuardarNombre("rosario")
        public static Boolean GuardarCampoValor(ModeloFactory objeto, String campo,String valor)
        {
            //TODO---->>> modificar campos
            TextInfo textInfo = (new CultureInfo("es-BO", false)).TextInfo;
            MethodInfo metodo = objeto.GetType().GetMethod("Guardar" + textInfo.ToTitleCase(campo));
            if (metodo != null)
            {
                ParameterInfo[] parametros = metodo.GetParameters();
                if (parametros != null && parametros.Length>0) {
                    String parametroTipoNombre = parametros[0].ParameterType.Name;
                    Object parametroValor=null;
                    switch (parametroTipoNombre)
                    {
                        case "Int32":
                            parametroValor = Int32.Parse(valor);
                            break;
                        case "Modelo.Usuario":
                            //parametroValor = Int32.Parse(valor);
                            break;
                        default:
                            parametroValor = valor;
                            break;
                    }


                    metodo.Invoke(objeto,new object[] { parametroValor });
                }
                return true;
            }
            return false;
        }



        //delete from Usuario where id=2

        public Boolean Eliminar(KeyValuePair<String, String> condicion, List<IObjetoTexto> listaAEliminar)
        {
            Type tipo = this.GetType();
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

                    _conexion.EliminarRegistro(nroLinea);

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


        public abstract string guardarTexto();

        public abstract ModeloFactory leerTexto(string texto);
    }
}
