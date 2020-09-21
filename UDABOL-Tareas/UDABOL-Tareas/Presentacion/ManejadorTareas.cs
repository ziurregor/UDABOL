using System;
using System.Collections.Generic;
using System.Text;
using Modelo;
using Util;

namespace Presentacion
{
    class ManejadorTareas
    {
        public static void MostrarListadoTareas(KeyValuePair<Usuario, List<ModeloBase>> usuarioLista)
        {
            while (true)
            {
                Utilidades.salida("Este es el Listado de Tareas");

                Utilidades.salida("Id\tFecha\tNombre\tUsuario\tEstado");

                if (usuarioLista.Value.Count == 0) {
                    Utilidades.salida("No existen aun Tareas Asignadas a Usuarios");
                }

                Utilidades.salida("");
                Utilidades.salida("");

                foreach (Tarea tarea in usuarioLista.Value)
                {
                    System.Console.WriteLine("%s\t%s\t%s\t%s\t%s", tarea.ObtenerId(), tarea.ObtenerFecha(), tarea.ObtenerNombre(), tarea.ObtenerUsario().ObtenerNombre(), tarea.ObtenerEstado());
                }
                Utilidades.salida("1. Modficiar una Tarea");
                if (usuarioLista.Key.ObtenerRol().esSuperUsuario())
                {
                    Utilidades.salida("2. Crear una Tarea");
                }
                Utilidades.salida("3. Salir");
                String opcionTarea = Utilidades.entrada("Seleccione una de las opciones: ");
                switch (opcionTarea)
                {
                    case "1":
                        ModificarTarea(usuarioLista.Key,usuarioLista.Value);
                        break;
                    case "2":
                        if (usuarioLista.Key.ObtenerRol().esSuperUsuario())
                        {
                            CrearTarea(usuarioLista.Key);
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private static void CrearTarea(Usuario key)
        {
            Utilidades.salida("Creando una Tarea");
            String tareaNombre=Utilidades.entrada("Ingresa un nombre para tu Tarea");

            List<ModeloBase> listaUsuarios = ((Usuario)ModeloBase.darInstancia("Modelo.Usuario")).Listar();
            int indice = 1;
            foreach (ModeloBase objeto in listaUsuarios)
            {
                Utilidades.salida(indice+". "+((Usuario)objeto).ObtenerNombre());
            }

            String usuarioId = Utilidades.entrada("Seleccione un Usuario");


        }

        private static void ModificarTarea(Usuario usuario, List<ModeloBase> lista)
        {
            if (lista.Count > 0)
            {
                String idTarea = Utilidades.entrada("Ingrese el Id de la Tarea a Modificar:");
                Negocio.ManejadorTareas manejador = new Negocio.ManejadorTareas();

                KeyValuePair<Tarea, List<String>> tareaCamposModificables = manejador.VerificarModificabilidad(usuario, lista, idTarea);
                //0  Usuario Comun -----> Estado
                //1  Super Usuario -----> Nombre, Usuario, Estado
                Utilidades.salida("Ingrese que campo quiere Modificar:");
                foreach (String campo in tareaCamposModificables.Value)
                {
                    System.Console.WriteLine("\t" + (tareaCamposModificables.Value.IndexOf(campo) + 1).ToString() + ". " + campo);
                }
                Int32 indiceCampoModificar = Int32.Parse(System.Console.ReadLine());
                if (indiceCampoModificar > 0 && indiceCampoModificar <= tareaCamposModificables.Value.Count)
                {
                    String nombreCampo = tareaCamposModificables.Value[indiceCampoModificar - 1];
                    String valorCampo = Utilidades.entrada("El Valor Actual del Campo: " + nombreCampo + ", es:" + tareaCamposModificables.Key.ObtenerValorCampo(nombreCampo) + ", Cuál quieres que sea su nuevo valor?:"); 
                    tareaCamposModificables.Key.GuardarValorCampo(nombreCampo, valorCampo);
                    Utilidades.salida("Se guardo con existo");
                }
                else
                {
                    Utilidades.salida("Rango incorrecto");
                }
            }
            else {
                Utilidades.salida("No existen Tareas Nada que Modificar.");
            }
        }
    }
}
