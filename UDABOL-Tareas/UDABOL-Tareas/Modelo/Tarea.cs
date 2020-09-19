using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Dao;

namespace Modelo
{
    class Tarea :ModeloBase
    {
        private Int32 _id;
        private String _fecha;
        private String _nombre;
        private Usuario _usuario;
        private String _estado;

        private ConexionTexto _conexion;
        public Tarea() {
            _conexion = new ConexionTexto();
        }
        public string ObtenerEstado()
        {
            return _estado;
        }
        public void GuardarEstado(String estado)
        {
            _estado = estado;
        }

        public String ObtenerFecha()
        {
            return _fecha;
        }
        public void GuardarFecha(String fecha)
        {
            _fecha=fecha;
        }

        public String ObtenerNombre()
        {
            throw new NotImplementedException();
        }

        public void GuardarNombre( String nombre)
        {
            _nombre = nombre;
        }

        public Usuario ObtenerUsario()
        {
            return _usuario;
        }

        public void GuardarUsuario(Usuario usuario)
        {
            _usuario=usuario;
        }

        public Usuario ObtenerId()
        {
            return _id;
        }

        public void GuardarId(Int32 id)
        {
            _id = id;
        }


        // 0 14/09/2020 T1 (0 Usuario1 Habilitado)
        // 0 14/09/2020 T2 (1 Usuario2 Habilitado)
        // 0 14/09/2020 T3 (0 Usuario1 Habilitado)
        // 0 14/09/2020 T4 (1 Usuario2 Habilitado)
        // 0 14/09/2020 T5 (0 Usuario1 Habilitado)

        override
        public string guardarTexto()
        {
            return _id.ToString() + "\t" + _fecha + "\t" + _nombre + "\t" + _usuario.ObtenerId().ToString() + "\t" + _estado;
        }
        override
        public IObjetoTexto leerTexto(string texto)
        {
            String[] columnas = texto.Split("\t");

            Tarea tarea = new Tarea();
            tarea._id = Int32.Parse(columnas[0]);
            tarea._fecha = columnas[1];
            tarea._nombre = columnas[2];
            tarea._usuario = (Usuario)(new Usuario()).Obtener(new KeyValuePair<string, string>("_id", columnas[3]));
            tarea._estado = columnas[4];
            return tarea;
        }

        internal String ObtenerValorCampo(string nombreCampo)
        {
            /*switch (nombreCampo)
            {
                case "id":
                    return _id.ToString();

                case "nombre":
                    return _nombre;

                case "fecha":
                    return _fecha;

                case "usuario":
                    return _usuario.ObtenerNombre();
                case "estado":
                    return _estado;
                default:
                    return "";
            }*/
            // Reflection ---->>> Realiza una ingenieria Inversa... con la finalidad de estructurar una clase/objeto o un algo para minimizar procesos repetitivos.
            Type tipo = this.GetType();
            PropertyInfo propiedad = tipo.GetProperty(nombreCampo);
            if (propiedad != null) {
                return propiedad.GetValue(this).ToString();
            }
            return "";
        }

        internal void GuardarValorCampo(string nombreCampo, string valorCampo)
        {
            throw new NotImplementedException();
        }
    }
}
