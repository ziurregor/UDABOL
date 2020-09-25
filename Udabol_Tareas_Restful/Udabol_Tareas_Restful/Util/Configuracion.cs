using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util
{
    public class Configuracion
    {

        public enum Database {
            SQLite,
            Texto
        }


        public static Int32 tiempoSesion = 360;
        public static Database baseDatos = Database.Texto;
        public static String baseDatosNombre = "Tareas";
    }
}
