using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IManejadorEstados
    {
        public IEnumerable<MostrarEstadoUsuario> ObtenerEstadosUsuario();
        public IEnumerable<MostrarEstadoTarea> ObtenerEstadosTareas();
    }
}
