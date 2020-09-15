using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{
    public interface IManejadorTareas
    {
        public List<ITarea> ListarTareas();

        public ITarea CrearTarea(IUsuario usuario, String nombreTarea, String Estado);

        public ITarea CrearTarea(IUsuario usuario, String nombreTarea);
    }
}
