using System;
using System.Collections.Generic;

namespace Modelo
{
    public interface ITarea :IObjetoTexto
    {
        int ObtenerFecha();
        int ObtenerNombre();
        IUsuario ObtenerUsario();
        String ObtenerEstado();
        List<ITarea> ListarTareas();
        string ObtenerId();
    }
}