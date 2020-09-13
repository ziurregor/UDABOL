using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Util;

namespace Negocios
{
    public class LoginConsola : ILogin
    {
        IUsuario _usuario;

        public void LoginUsuario() {
            System.Console.Out.WriteLine("Ingrese un usuario:");
            String _cadenaUsuario=System.Console.In.ReadLine();
            System.Console.Out.WriteLine("Ingrese un contraseña:");
            String _cadenaContrasena = System.Console.In.ReadLine();
            System.Console.Out.WriteLine("Se esta Autenticando espere por favor...");
            IUsuario _usuario = AutenticacionUsuario(_cadenaUsuario, _cadenaContrasena);
            IRol _rol = VerificarRolUsuario(_usuario);
            List<ITarea> _listaTareas = MostrarManejadorTareas(_rol);
            if (_listaTareas != null) {
                System.Console.WriteLine("Fecha\tNombre\tUsuario\tEstado");
                foreach (ITarea _tarea in _listaTareas)
                {
                    System.Console.WriteLine("%s\t%s\t%s\t%s",_tarea.ObtenerFecha(),_tarea.ObtenerNombre(),_tarea.ObtenerUsario().ObtenerNombre(),_tarea.ObtenerEstado());
                }
            }
            else {
                System.Console.WriteLine("Nada que listar");
            }
        }

        public IUsuario AutenticacionUsuario(string usuario, string contrasena)
        {
            String _cadenaEncriptada = Utilidades.encriptarContrasena(usuario,contrasena);
            return this._usuario.ObtenerUnUsuario(usuario, _cadenaEncriptada);
        }

        public List<ITarea> MostrarManejadorTareas(IRol rol)
        {
            if (rol != null)
            {
                if (rol.ObtenerNombre().Equals("SuperUsuario"))
                {
                    ManejadorTareasSuperUsuario usuario = new ManejadorTareasSuperUsuario();
                    return usuario.ListarTareas();
                }
                else if (rol.ObtenerNombre().Equals("UsuarioComun"))
                {
                    ManejadorTareasSuperUsuario usuario = new ManejadorTareasSuperUsuario();
                    return usuario.ListarTareas();
                }
            }
            return null;
        }

        public IRol VerificarRolUsuario(IUsuario usuario)
        {
            if (usuario != null) {
                return usuario.obtenerRol();
            }
            return null;

        }
    }

}
