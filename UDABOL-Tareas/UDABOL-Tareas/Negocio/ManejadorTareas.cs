using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Reflection;
=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
using Modelo;

namespace Negocio
{
<<<<<<< HEAD
    public class ManejadorTareas:IManejadorTareas
    {
        public KeyValuePair<Tarea, List<String>> VerificarModificabilidad(Usuario usuario, List<ModeloBase> lista, String idTarea)
        {
            KeyValuePair<Tarea, List<String>> tareaLista = new KeyValuePair<Tarea, List<String>>();
            if (usuario != null && lista != null) {
                //TODO--->>> verificar si es super usuario

                Tarea tarea = (Tarea)ModeloBase.Obtener(new KeyValuePair<String, String>("id", idTarea),"Modelo.Tarea");
                List<String> listaCampos = new List<String>();
                if (usuario.ObtenerRol().esSuperUsuario())
                {
                    listaCampos.Add("nombre");
                    listaCampos.Add("usuario");
                    listaCampos.Add("estado");
                }
                else {
                    listaCampos.Add("estado");
                }
                return new KeyValuePair<Tarea, List<String>>(tarea, listaCampos);
            }
            return tareaLista;
        }
        public List<ModeloBase> ListarTareas()
        {
            return (List<ModeloBase>)(new Tarea()).Listar();
        }
        //Nombre: Fulanito de tal
        //Usuario: 1
        //Estado: En Proceso
        //Reflection-----> Ingenieria Inversa de Objetos... se ve como estan construidos
        public Tarea Modificar(Dictionary<String, String> camposAModificar, KeyValuePair<String, String> condicion)
        {
            String identificador = condicion.Key;
            String valorIdentificador = condicion.Value;
            Tarea _tarea = new Tarea();
            Type _tipo = _tarea.GetType();
            PropertyInfo[] _propiedadesTarea = _tipo.GetProperties();
            List<ModeloBase> _listaTareas = (_tarea).Listar();
            if (_listaTareas != null)
            {
                foreach (Tarea _tareaL in _listaTareas)
                {
                    PropertyInfo _propiedadIdentificador = _tareaL.GetType().GetProperty(identificador);

                    if (_propiedadIdentificador.GetValue(_tareaL).Equals(valorIdentificador))
                    {
                        foreach (KeyValuePair<String, String> _campoPar in camposAModificar)
                        {
                            foreach (PropertyInfo _propiedad in _propiedadesTarea)
                            {
                                if (_propiedad.Name.Equals(_campoPar.Key))
                                {
                                    _propiedad.SetValue(_tareaL, _campoPar.Value);
                                }
                            }
                        }
                        return _tareaL;
                    }
                }
            }
            return null;
        }
=======
    internal class ManejadorTareas
    {
        internal  KeyValuePair<Tarea, List<String>> VerificarModificabilidad(Usuario usuario, List<ModeloBase> lista, String idTarea)
        {
            KeyValuePair<Tarea, List<String>> tareaLista = new KeyValuePair<Tarea, List<String>>();
            if (usuario != null && lista != null) {

                foreach (Tarea tarea in lista)
                {
                    
                }
            }
            return tareaLista;
        }

>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
    }
}