using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public interface IConjuntoDB<T>
    {
        public IEnumerable<T> ObtenerTodo();
        public T ObtenerUno(int id);
        public T Crear(T elemento);
        public T Editar(int id, T elemento);
        public bool Eliminar(int id);
        public bool GuardarCambios();
    }
}
