using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Negocio;
using Util;

namespace Presentacion
{
    class Login
    {
        

        public static void MostrarLogin() {

            System.Console.WriteLine("Porfavor Ingrese su nombre de usuario:");
            String usuario = System.Console.ReadLine();
            System.Console.WriteLine("Porfavor Ingrese su nombre de contraseña:");
            String contrasena = System.Console.ReadLine();

            LoginConsola login = new LoginConsola();
            KeyValuePair<Usuario, List<ModeloBase>> usuarioLista = login.LoginUsuario(usuario, contrasena);


            if (usuarioLista.Key!=null && usuarioLista.Value!=null)
            {
                System.Console.WriteLine("\t\tBIENVENIDO Usuario: " + usuarioLista.Key.ObtenerNombre() + ", " + usuarioLista.Key.ObtenerRol().ObtenerNombre());
                ManejadorTareas.MostrarListadoTareas(usuarioLista);
            }
            else
            {
                System.Console.WriteLine("La información de autenticación es incorrecta Por favor Vuelva a ingresar");
            }
        }
    }
}
