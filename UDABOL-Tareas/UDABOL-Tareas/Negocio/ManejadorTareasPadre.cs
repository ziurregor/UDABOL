using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text;
using Modelo;
using Negocios;

namespace Negocio
{
    public class ManejadorTareasPadre:IManejadorTareas
    {
        public List<ITarea> ListarTareas()
        {
            return (new Tarea()).ListarTareas();
        }
        //Nombre: Fulanito de tal
        //Usuario: 1
        //Estado: En Proceso
        //Reflection-----> Ingenieria Inversa de Objetos... se ve como estan construidos
        public ITarea Modificar(Dictionary<String, String> camposAModificar, KeyValuePair<String,String> condicion)
        {
            String identificador = condicion.Key;
            String valorIdentificador = condicion.Value;
            Tarea _tarea = new Tarea();
            Type _tipo = _tarea.GetType();
            PropertyInfo[] _propiedadesTarea = _tipo.GetProperties();
            List<ITarea> _listaTareas= (_tarea).ListarTareas();
            if (_listaTareas != null) {
                foreach (ITarea _tareaL in _listaTareas) {
                    PropertyInfo _propiedadIdentificador = _tareaL.GetType().GetProperty(identificador);

                    if ( _propiedadIdentificador.GetValue(_tareaL).Equals(valorIdentificador)) {
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
    }
}
