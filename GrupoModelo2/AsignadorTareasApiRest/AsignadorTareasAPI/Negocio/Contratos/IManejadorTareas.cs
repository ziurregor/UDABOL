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
        public Tarea CrearTarea(Tarea tarea);
        public Tarea ActualizarTarea(int id, Tarea tarea);
        public bool EliminarTarea(int id);
    }
}
