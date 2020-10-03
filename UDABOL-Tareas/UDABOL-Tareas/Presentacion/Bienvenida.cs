using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
using Dao;
=======
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e

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
<<<<<<< HEAD
                    default:
                        ConexionFactory.GuardarConexiones();
=======
                    case "2":
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
                        return;
                }
            }
        }
    }
}
