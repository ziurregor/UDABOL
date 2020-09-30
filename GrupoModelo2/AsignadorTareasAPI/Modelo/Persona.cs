using System;
using System.Collections.Generic;

namespace Modelo
{
    public class Persona
    {
        public int PersonaID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int UsuarioID { get; set; }

        //public Usuario Usuario { get; set; }
        //public ICollection<Tarea> Tarea { get; set; }
    }
}
