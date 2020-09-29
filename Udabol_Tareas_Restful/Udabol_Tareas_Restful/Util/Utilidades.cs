using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Modelo;

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
            try
            {
                return System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(texto));
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return "";
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

        public static string firstLower(string text) {
            return text.Substring(0, 1).ToLower() + text.Substring(1);
        }

        public static void PasarValorCampo(Dictionary<String, String> excepciones, PropertyInfo propiedad, IModeloBase objeto, String valor)
        {
            if (propiedad != null && objeto!=null)
            {
                Type _tipo = objeto.GetType();
                if (excepciones.ContainsKey(propiedad.Name))
                {
                    MethodInfo metodo = _tipo.GetMethod(excepciones[propiedad.Name]);
                    if (metodo != null)
                    {

                        switch (propiedad.PropertyType.Name)
                        {
                            case "Int32":
                                metodo.Invoke(objeto, new object[] { Int32.Parse(valor) });
                                break;
                            case "Boolean":
                                metodo.Invoke(objeto, new object[] { Boolean.Parse(valor) });
                                break;
                            default:
                                metodo.Invoke(objeto, new object[] { valor });
                                break;
                        }
                    }
                }
                else
                {
                    switch (propiedad.PropertyType.Name)
                    {
                        case "Int32":
                            propiedad.SetValue(objeto, Int32.Parse(valor));
                            break;
                        case "Boolean":
                            propiedad.SetValue(objeto, Boolean.Parse(valor));
                            break;
                        default:
                            propiedad.SetValue(objeto, valor);
                            break;
                    }
                }
            }
        }

        //Se obtiene un valor de un campo de un objeto enviandole solamente el nombre
        // Si el objeto es Rol... y le queremos obtener el valor del campo nombre
        //ModeloBase.ObtenerCampoValor(rol,"nombre");
        public static Object ObtenerCampoValor(IModeloBase objeto, String campo)
        {
            //ToTitleCase ---> PascalCase
            TextInfo textInfo = (new CultureInfo("es-BO", false)).TextInfo;
            PropertyInfo propiedad = objeto.GetType().GetProperty(textInfo.ToTitleCase(campo));
            if (propiedad != null)
            {
                return propiedad.GetValue(objeto);
            }
            return null;
        }
    }
}
