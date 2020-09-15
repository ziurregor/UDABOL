using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    class ManejadorTareasUsuarioComun : IManejadorTareas
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


        public bool ModificarTareaUsuarioComun(ITarea tarea)
        {
            throw new NotImplementedException();
        }
    }
}
