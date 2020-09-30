using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public class BaseDeDatosTxt : IBaseDeDatos
    {
        private string _ruta;

        public BaseDeDatosTxt(string ruta)
        {
            _ruta = ruta;
        }

        public IConjuntoDB<Rol> Rol()
        {
            return new ConjuntoDBText<Rol>(_ruta);
        }

        public IConjuntoDB<Estado> Estado()
        {
            return new ConjuntoDBText<Estado>(_ruta);
        }

        public IConjuntoDB<EstadoUsuario> EstadoUsuario()
        {
            //IConjuntoDB<EstadoUsuario> estadoUsuario = new ConjuntoDBText<EstadoUsuario>();
            //estadoUsuario.
            return new ConjuntoDBText<EstadoUsuario>(_ruta);
        }

        public IConjuntoDB<EstadoTarea> EstadoTarea()
        {
            return new ConjuntoDBText<EstadoTarea>(_ruta);
        }

        public IConjuntoDB<Usuario> Usuario()
        {
            return new ConjuntoDBText<Usuario>(_ruta);
        }

        public IConjuntoDB<Persona> Persona()
        {
            return new ConjuntoDBText<Persona>(_ruta);
        }

        public IConjuntoDB<Tarea> Tarea()
        {
            return new ConjuntoDBText<Tarea>(_ruta);
        }
    }
}
