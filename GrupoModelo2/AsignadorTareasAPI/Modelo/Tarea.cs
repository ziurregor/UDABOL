using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class Tarea
    {
        public int TareaID { get; set; }
        public string NombreTarea { get; set; }
        public DateTime Fecha { get; set; }
        public int EstadoTareaID { get; set; }
        public int PersonaID { get; set; }

        public EstadoTarea EstadoTarea { get; set; }
    }
}
