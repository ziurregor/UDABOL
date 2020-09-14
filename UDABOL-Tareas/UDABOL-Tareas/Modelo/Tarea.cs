using System;
using System.Collections.Generic;
using System.Text;
using UDABOL_Tareas.Dao;

namespace Modelo
{
    class Tarea : ITarea
    {
        Int32 _id;
        String _fecha;
        String _nombre;
        IUsuario _usuario;
        String _estado;
        ConexionTexto _conexion;
        public Tarea() {
            _conexion = new ConexionTexto();
        }

        // 0 14/09/2020 T1 (0 Usuario1 Habilitado)
        // 0 14/09/2020 T2 (1 Usuario2 Habilitado)
        // 0 14/09/2020 T3 (0 Usuario1 Habilitado)
        // 0 14/09/2020 T4 (1 Usuario2 Habilitado)
        // 0 14/09/2020 T5 (0 Usuario1 Habilitado)

        public string guardarTexto()
        {
            return _id.ToString() + "\t" + _fecha + "\t" + _nombre + "\t" + _usuario.ObtenerId().ToString()+"\t"+_estado;
        }

        public IObjetoTexto leerTexto(string texto)
        {
            throw new NotImplementedException();
        }

        public List<ITarea> ListarTareas()
        {
            throw new NotImplementedException();
        }

        public string ObtenerEstado()
        {
            throw new NotImplementedException();
        }

        public int ObtenerFecha()
        {
            throw new NotImplementedException();
        }

        public int ObtenerNombre()
        {
            throw new NotImplementedException();
        }

        public IUsuario ObtenerUsario()
        {
            throw new NotImplementedException();
        }
    }
}
