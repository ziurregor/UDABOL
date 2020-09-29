using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public class MostrarTarea
    {
        public int TareaID { get; set; }
        public string NombreTarea { get; set; }
        public DateTime Fecha { get; set; }

        public MostrarUsuario Usuario { get; set; }

        public MostrarEstadoTarea EstadoTarea { get; set; }

    }
}
