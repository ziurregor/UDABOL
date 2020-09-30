using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO
{
    public class BaseDeDatosSqlServer : IBaseDeDatos
    {
        private string _ruta;

        public BaseDeDatosSqlServer()
        {
            _ruta = "Server=localhost;Database=AsignadorTareas;Trusted_Connection=True;";
        }

        public IConjuntoDB<Estado> Estado()
        {
            return new ConjuntoDBSqlServer<Estado>(_ruta);
        }

        public IConjuntoDB<EstadoTarea> EstadoTarea()
        {
            return new ConjuntoDBSqlServer<EstadoTarea>(_ruta);
        }

        public IConjuntoDB<EstadoUsuario> EstadoUsuario()
        {
            return new ConjuntoDBSqlServer<EstadoUsuario>(_ruta);
        }

        public IConjuntoDB<Persona> Persona()
        {
            return new ConjuntoDBSqlServer<Persona>(_ruta);
        }

        public IConjuntoDB<Rol> Rol()
        {
            return new ConjuntoDBSqlServer<Rol>(_ruta);
        }

        public IConjuntoDB<Tarea> Tarea()
        {
            return new ConjuntoDBSqlServer<Tarea>(_ruta);
        }

        public IConjuntoDB<Usuario> Usuario()
        {
            return new ConjuntoDBSqlServer<Usuario>(_ruta);
        }
    }
}
