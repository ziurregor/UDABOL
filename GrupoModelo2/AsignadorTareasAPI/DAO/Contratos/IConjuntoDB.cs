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
        public void Editar(int id, T elemento);
        public void Eliminar(int id);
        public void GuardarCambios();
    }
}
