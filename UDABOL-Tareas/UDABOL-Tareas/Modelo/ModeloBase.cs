using System;
using System.Collections.Generic;
using System.Reflection;
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


        private ConexionTexto _conexion;



        public ModeloBase() {
            _conexion = new ConexionTexto();
            _conexion.Conectar(this.GetType().Name+".txt",this.GetType());
        }



        ~ModeloBase() {
            _conexion.Guardar();
        }


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
            List<ModeloBase> lista = this.Listar();
            Type tipo = this.GetType();
            PropertyInfo[] propiedades = tipo.GetProperties();
            foreach (ModeloBase objeto in lista) {
                PropertyInfo propiedad = tipo.GetProperty(condicion.Key);
                if (propiedad.GetValue(objeto).Equals(condicion.Value.ToString())) {
                    return objeto;
                }
            }
            return null;
        }


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

        public abstract string guardarTexto();

        public abstract IObjetoTexto leerTexto(string texto);
    }
}
