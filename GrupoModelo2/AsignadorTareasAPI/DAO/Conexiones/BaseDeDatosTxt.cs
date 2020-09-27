using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class BaseDeDatosTxt : IBaseDeDatos
    {

        public IConjuntoDB<Rol> Rol()
        {
            return new ConjuntoDBText<Rol>();
        }

        public IConjuntoDB<Estado> Estado()
        {
            return new ConjuntoDBText<Estado>();
        }

        public IConjuntoDB<EstadoUsuario> EstadoUsuario()
        {
            //IConjuntoDB<EstadoUsuario> estadoUsuario = new ConjuntoDBText<EstadoUsuario>();
            //estadoUsuario.
            return new ConjuntoDBText<EstadoUsuario>();
        }

        public IConjuntoDB<EstadoTarea> EstadoTarea()
        {
            return new ConjuntoDBText<EstadoTarea>();
        }

        public IConjuntoDB<Usuario> Usuario()
        {
            return new ConjuntoDBText<Usuario>();
        }

        public IConjuntoDB<Persona> Persona()
        {
            return new ConjuntoDBText<Persona>();
        }

        public IConjuntoDB<Tarea> Tarea()
        {
            return new ConjuntoDBText<Tarea>();
        }
    }
}
