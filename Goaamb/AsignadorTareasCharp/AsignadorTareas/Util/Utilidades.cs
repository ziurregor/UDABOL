using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsignadorTareas.Util
{
    class Utilidades
    {
        public static JObject ConsumirREST(String destino,String metodo,JObject objeto) {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(Util.Configuracion.BaseURL + destino);
                request.Method = metodo.ToUpper();

                byte[] data = Encoding.ASCII.GetBytes(objeto.ToString());

                request.ContentType = "application/json";
                request.ContentLength = data.Length;

                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                string content = string.Empty;
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();

                    }
                }
                return  JObject.Parse(content);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}
