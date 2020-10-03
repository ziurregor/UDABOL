using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public static class Utilidades
    {
        public static string encriptarContrasena(string llave,string contrasena)
        {
            String _cadenaAConvertir = MD5(llave) + MD5(contrasena);
            byte[] _cadenaConvertidaBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_cadenaAConvertir);
            return System.Convert.ToBase64String(_cadenaConvertidaBytes);
        }

        private static string MD5(this string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }
        }

        public static void salida(String texto) {
            System.Console.WriteLine(texto);
        }

<<<<<<< HEAD
        public static String entrada(String texto)
        {
            salida(texto);
            return System.Console.ReadLine();
        }



=======
        public static String entrada()
        {
            return System.Console.ReadLine();
        }
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
    }
}
