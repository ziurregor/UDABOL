using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IManejadorTareas
    {
        public IEnumerable<MostrarTarea> ObtenerTareas();
        public MostrarTarea ObtenerTareaPorID(int id);
        public MostrarTarea CrearTarea(Tarea tarea);
        public MostrarTarea ActualizarTarea(int id, Tarea tarea);
        public bool EliminarTarea(int id);
    }
}
