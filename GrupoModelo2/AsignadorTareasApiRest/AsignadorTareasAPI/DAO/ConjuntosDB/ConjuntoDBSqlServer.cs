using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ConjuntoDBSqlServer<T> : IConjuntoDB<T> where T : new()
    {
        private string _ruta;
        private IEnumerable<T> _datos;
        public ConjuntoDBSqlServer(string ruta)
        {
            _ruta = ruta;
            CargarDatos();
        }
        public void CargarDatos()
        {
            _datos = ManejadorDeSqlServer<T>.RealizarConsultaSelect(_ruta);
        }

        public T Crear(T elemento)
        {
            return ManejadorDeSqlServer<T>.RealizarConsultaInsert(_ruta, elemento);
        }

        public T Editar(int id, T elemento)
        {
            return ManejadorDeSqlServer<T>.RealizarConsultaUpdate(_ruta, id, elemento);
        }

        public bool Eliminar(int id)
        {
            return ManejadorDeSqlServer<T>.RealizarConsultaDelete(_ruta, id);
        }

        public bool GuardarCambios()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ObtenerTodo()
        {
            return _datos;
        }

        public T ObtenerUno(int id)
        {
            Type tipo = typeof(T);
            string clase = tipo.Name;
            return _datos.FirstOrDefault(o => (int)o.GetType().GetProperty($"{clase}ID").GetValue(o) == id);
        }
    }
}
