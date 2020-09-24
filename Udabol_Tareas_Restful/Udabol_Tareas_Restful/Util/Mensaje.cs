using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Util
{
    public class Mensaje
    {

        public static readonly Mensaje SESION_INCORRECTA = new Mensaje() { Texto = "Cadena de Sesion Incorrecta o su Sesion ha Expirado o no tiene acceso a esta seccion, vuelva a hacer Login y obtenga una nueva cadena de Sesion" };
        public static readonly Mensaje NO_MODIFICAR = new Mensaje() { Texto = "No se puede Modificar Error Interno Intente en otro momento o la informacion Ingresada no concuerda." };
        public static readonly Mensaje DATOS_ID=new Mensaje() { Texto = "Los Datos y el Id deben concordar" };
        public static readonly Mensaje MODIFICO_EXITO= new Mensaje() { Texto = "Se Modifico con Exito" };
        public static readonly Mensaje INGRESA_LOGIN=new Mensaje() { Texto = "Para usar esta Seccion debe ingresar, con usuario y contraseña y enviar una cadena de Sesion" };
        public static readonly Mensaje USUARIO_CONTRASENA= new Mensaje() { Texto = "Debes Ingresar un usuario y contraseña." };
        public static readonly Mensaje AUTENTICACION_INCORRECTA= new Mensaje() { Texto = "Datos de Autenticación incorrectos." };

        public String Texto { get; set; }
        public String Llave { get; set; }
    }
}

