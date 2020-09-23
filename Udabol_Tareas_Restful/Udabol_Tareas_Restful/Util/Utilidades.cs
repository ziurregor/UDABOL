using System;
using System.Collections.Generic;
using System.Text;

namespace Util
{
    public static class Utilidades
    {
        public static string encriptarContrasena(string llave,string contrasena)
        {
            return ABase64(MD5(llave) + MD5(contrasena));
        }

        public static string ABase64(String texto) {
            return System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(texto));
        }

        public static string DeBase64(String texto)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(texto));
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

        public static String entrada(String texto)
        {
            salida(texto);
            return System.Console.ReadLine();
        }



    }
}
