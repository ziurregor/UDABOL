using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAO
{
    public class ManejadorDeArchivos
    {

        [STAThread]
        public string LeerArchivo(string ruta)
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
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

        [STAThread]
        public bool EscribirArchivo(string ruta, string datos)
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
