using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    class ManejadorTareasSuperUsuario : IManejadorTareas
    {
        public ITarea CrearTarea(IUsuario usuario, string nombreTarea, string Estado)
        {
            throw new NotImplementedException();
        }

        public ITarea CrearTarea(IUsuario usuario, string nombreTarea)
        {
            throw new NotImplementedException();
        }

        public List<ITarea> ListarTareas()
        {
            throw new NotImplementedException();
        }

        public bool ModificarTareaSuperUsuario(ITarea tarea)
        {
            throw new NotImplementedException();
        }
    }
}
