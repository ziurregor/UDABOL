using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            Console.WriteLine("                       __ ");
            Console.WriteLine("                     .'  '.");
            Console.WriteLine("                 _.- /  |  l ");
            Console.WriteLine("    ,        _.-    |  /  0 `-. ");
            Console.WriteLine("    |l    .-'      ---- -.__.'=====================- ");
            Console.WriteLine("    l '-'`        .___.--._)=========================| ");
            Console.WriteLine("     l            .'      |                          | ");
            Console.WriteLine("      |     /,_.-'        |      - ASIGNADOR -       | ");
            Console.WriteLine("    _ /   _.'(            |         - DE -           | ");
            Console.WriteLine("   /  ,-' l  l            |       - TAREAS -         | ");
            Console.WriteLine("   l  l    `-'            |                          | ");
            Console.WriteLine("    `-'                   '--------------------------' ");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("Bienvenido Usuario, introdusca sus datos:");
            Console.WriteLine("Nombre de Usuario o Correo:");
            usuario = Console.ReadLine();
            Console.WriteLine("Contraseña:");
            contrasena = Console.ReadLine();            

            string url = "http://200.105.154.18:5000/Login/"+usuario+"/"+contrasena;           
            var json = new WebClient().DownloadString(url);
            //dynamic m = JsonConvert.DeserializeObject(json);
            ///.DeserializeObject<IList<Usuario>>(json);
            var jo = Newtonsoft.Json.Linq.JObject.Parse(json);
            var msgWel = jo["texto"];
            var llave = jo["llave"];
            //Console.WriteLine(m);
            Console.WriteLine(msgWel);
            Boolean sw = true;
            int opc = 0;

                do
                {
                    Console.WriteLine("****************MENU**************");
                    Console.WriteLine("*    Que deseas hacer?           *");
                    Console.WriteLine("*    1. Buscar tarea             *");
                    Console.WriteLine("*    2. Ver listado de tareas    *");
                    Console.WriteLine("*    3. Realizar tarea Asignada  *");
                    Console.WriteLine("*    0. Salir...                 *");
                    Console.WriteLine("**********************************");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Ingrese la tarea a buscar: ");
                            String a = Console.ReadLine();
                            url = "http://200.105.154.18:5000/Tarea/" + a + "/" + llave.ToString();
                            var json2 = new WebClient().DownloadString(url);                   
                            Console.WriteLine(json2.ToString());                            
                            var tarea1 = new Tarea();
                            Console.ReadKey();
                            break;
                        case 2:
                            url = "http://200.105.154.18:5000/Tarea/" + llave.ToString();
                            json = new WebClient().DownloadString(url);
                            JArray jsonArray = JArray.Parse(json);                            
                            var tarea = new Tarea();
                            foreach (var i in jsonArray)
                            {
                                tarea = i.ToObject<Tarea>();
                                Console.WriteLine("ROg" + tarea.Nombre);
                            }
                            break;
                       case 3:
                            /*Console.WriteLine("Ingrese la tarea a buscar: ");
                            /String b = Console.ReadLine();
                            /url = "http://200.105.154.18:5000/Tarea/" + b + "/" + llave.ToString();
                            /var json3 = new WebClient().DownloadString(url);                            
                            Console.WriteLine(json3.ToString());                            
                            var lista = new List<JObject>(5);
                            
                            Console.ReadKey();
                            break;*/

                    default:
                            Console.WriteLine("Adios ");
                            sw = false;
                            break;
                    }

                } while (sw);
        }

    }
}
