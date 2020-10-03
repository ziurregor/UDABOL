using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{
    class ManejadorTareasSuperUsuario : ManejadorTareasPadre
    {
        public ITarea CrearTarea(IUsuario usuario, string nombreTarea, string Estado)
        {
            throw new NotImplementedException();
        }

    }
}
