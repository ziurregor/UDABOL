using Modelo;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public interface IBaseDeDatos
    {
        public IConjuntoDB<Rol> Rol();
        public IConjuntoDB<Estado> Estado();
        public IConjuntoDB<EstadoUsuario> EstadoUsuario();
        public IConjuntoDB<EstadoTarea> EstadoTarea();
        public IConjuntoDB<Usuario> Usuario();
        public IConjuntoDB<Persona> Persona();
        public IConjuntoDB<Tarea> Tarea();
    }
}
