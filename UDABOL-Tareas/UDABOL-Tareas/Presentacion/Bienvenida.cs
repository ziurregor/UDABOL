using System;
using System.Collections.Generic;
using System.Text;
using Dao;

namespace Presentacion
{
    class Bienvenida
    {
        public static void MostrarBienvenida()
        {
            String opcion = "";
            while (true)
            {
                System.Console.WriteLine("\t\tBIENVENIDO AL ASIGNADOR DE TAREAS");
                System.Console.WriteLine("");
                System.Console.WriteLine("\t1.Pantalla Login");
                System.Console.WriteLine("\t2.Salir");
                System.Console.WriteLine("");
                System.Console.WriteLine("Ingrese una Opcion:");
                opcion = System.Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Login.MostrarLogin();
                        break;
                    default:
                        ConexionFactory.GuardarConexiones();
                        return;
                }
            }
        }
    }
}
