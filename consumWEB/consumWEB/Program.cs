using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace consumWEB
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuario="";
            var contrasena = "";

            Console.WriteLine("Introducir Nombre de Usuario y password");
            usuario=Console.ReadLine();
            contrasena = Console.ReadLine();

            string url = "http://200.105.154.18:5000/Login/" + usuario+"/"+contrasena;            var json = new WebClient().DownloadString(url);
            //dynamic m = JsonConvert.DeserializeObject(json);
            ///.DeserializeObject<IList<Usuario>>(json);
            var jo = Newtonsoft.Json.Linq.JObject.Parse(json);

            var msgWel = jo["texto"];
            var llave = jo["llave"];
            //Console.WriteLine(m);
            Console.WriteLine(msgWel);

            url = "http://200.105.154.18:5000/tarea/" + llave.ToString();

            json = new WebClient().DownloadString(url);

            JArray jsonArray = JArray.Parse(json);
            //JObject jo1 = Newtonsoft.Json.Linq.JObject.Parse(json);
            var tarea = new Tarea();

            foreach (var i in jsonArray)
            {
                tarea = i.ToObject<Tarea>();
                Console.WriteLine("ROg" + tarea.Nombre);
            }
        }
    }
}
