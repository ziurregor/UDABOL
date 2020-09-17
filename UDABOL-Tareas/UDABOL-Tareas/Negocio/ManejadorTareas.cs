using System;
using System.Collections.Generic;
using Modelo;

namespace Negocio
{
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

    }
}