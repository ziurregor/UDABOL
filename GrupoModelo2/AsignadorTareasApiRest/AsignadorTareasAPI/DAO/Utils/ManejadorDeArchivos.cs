using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAO
{
    public static class ManejadorDeArchivos
    {

        [STAThread]
        public static string LeerArchivo(string ruta)
        {
            string todasLasLineas;
            try
            {
                StreamReader sr = new StreamReader(ruta, Encoding.UTF8, true);
                todasLasLineas = sr.ReadToEnd();
                sr.Close();
                return todasLasLineas;
            }
            catch (Exception e)
            {
                //File.Create(ruta).Close();
                //TextWriter tw = new StreamWriter(ruta);
                //tw.Write("RolID\tNombreRol\n1\tAdmin\n2\tSimple");
                //tw.Close();
                Console.WriteLine("Exception: " + e.Message);
                return $"Exception: {e.Message}";
            }
        }

        [STAThread]
        public static bool EscribirArchivo(string ruta, string datos)
        {
            try
            {
                //Open the File
                StreamWriter sw = new StreamWriter(ruta, false, Encoding.UTF8);
                sw.Write(datos);
                sw.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return false;
            }
        }
    }
}
