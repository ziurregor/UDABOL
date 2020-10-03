using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Globalization;
=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Dao;

namespace Modelo
{
    public abstract class ModeloBase:IObjetoTexto
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

<<<<<<< HEAD
        private static Dictionary<String, List<ModeloBase>> listaDeListas;


=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e

        private IConexion _conexion;



<<<<<<< HEAD
        public ModeloBase() {//Se pide el objeto correspondiente a cada Modelo que nos provee ConexionFactory
            _conexion = ConexionFactory.DarConexion(this.GetType());
=======
        public ModeloBase() {
            _conexion = new ConexionTexto();
            _conexion.Conectar(this.GetType().Name+".txt",this.GetType());
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        }



<<<<<<< HEAD
=======
        ~ModeloBase() {
            _conexion.Guardar();
        }


>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        public Boolean Crear(Dictionary<String,String> campos,List<ModeloBase> lista) {
            Type tipo = this.GetType();

            PropertyInfo[] _propiedadesClase = tipo.GetProperties();
            foreach (PropertyInfo propiedad in _propiedadesClase) {
                foreach (KeyValuePair<String,String> campo in campos) {
                    if (campo.Key.Equals(propiedad.Name)) {
                        propiedad.SetValue(this, campo.Value);
                    }
                }
            }

            lista.Add(this);

            _conexion.EscribirTabla(lista);

            return true;
        }


        // Update Usuario set nombre=Juana Perez,estado=Deshabilitado where id=2


        public Boolean Modificar(Dictionary<String,String> campos,KeyValuePair<String,String> condicion,List<ModeloBase> listaAModificar) {
            Type tipo = this.GetType();
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();

            foreach (ModeloBase objeto in listaAModificar) {
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

                    _conexion.EscribirTabla(listaAModificar);

                    return true;
                }
            }
            return false;
        }



        // select * from Usuario

        public List<ModeloBase> Listar() {

            List<ModeloBase> _lista = new List<ModeloBase>();

            if (_conexion != null)
            {
                _lista = _conexion.LeerTabla();
            }
            return _lista;

        }


        public ModeloBase Obtener(KeyValuePair<String,String> condicion) {
<<<<<<< HEAD
            return Obtener(condicion, this.GetType());
        }

        public static ModeloBase Obtener(KeyValuePair<String, String> condicion,String tipoModelo)
        {
            return Obtener(condicion, Type.GetType(tipoModelo));
        }


        public static ModeloBase Obtener(KeyValuePair<String, String> condicion,Type tipoModelo)
        {

            List<ModeloBase> lista = ((ModeloBase)Activator.CreateInstance(tipoModelo) ).Listar();
            if (lista != null)
            {
                Type tipo = tipoModelo;
                foreach (ModeloBase objeto in lista)
                {
                    if (objeto != null)
                    {
                        Object valor = ObtenerCampoValor(objeto, condicion.Key);

                        if (valor != null && valor.ToString().Equals(condicion.Value))
                        {
                            return objeto;
                        }
                    }
=======
            List<ModeloBase> lista = this.Listar();
            Type tipo = this.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (ModeloBase objeto in lista) {
                PropertyInfo propiedad = tipo.GetProperty(condicion.Key);
                if (propiedad.GetValue(objeto).Equals(condicion.Value.ToString())) {
                    return objeto;
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
                }
            }
            return null;
        }

<<<<<<< HEAD
        //Se obtiene un valor de un campo de un objeto enviandole solamente el nombre
        // Si el objeto es Rol... y le queremos obtener el valor del campo nombre
        //ModeloBase.ObtenerCampoValor(rol,"nombre");
        public static Object ObtenerCampoValor(ModeloBase objeto,String campo) {
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
        public static Boolean GuardarCampoValor(ModeloBase objeto, String campo,String valor)
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


=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e

        //delete from Usuario where id=2

        public Boolean Eliminar(KeyValuePair<String, String> condicion, List<ModeloBase> listaAEliminar)
        {
            Type tipo = this.GetType();
            PropertyInfo[] _propiedadesClase = tipo.GetProperties();

            foreach (ModeloBase objeto in listaAEliminar)
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

<<<<<<< HEAD
        // Crear Una Instancia automaticamente
        //ModeloBase.darInstancia("Modelo.Rol")----->new Rol()
        //ModeloBase.darInstancia("Modelo.Usuario")----->new Usuario()
        //Factory Method--->Patron de diseño
=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
        public static Object darInstancia(Type tipo) {
            return Activator.CreateInstance(tipo);
        }

<<<<<<< HEAD
        public static Object darInstancia(String tipo)
        {
            return Activator.CreateInstance(Type.GetType(tipo));
        }


        public abstract string guardarTexto();

        public abstract ModeloBase leerTexto(string texto);
=======

        public abstract string guardarTexto();

        public abstract IObjetoTexto leerTexto(string texto);
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
    }
}
