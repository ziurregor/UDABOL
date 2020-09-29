using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DAO
{
    public class ConjuntoDBText<T> : IConjuntoDB<T> where T : new ()
    {
        public ManejadorDeArchivos _manejadorDeArchivos { get; private set; }
        private List<T> _datos;
        private string columnas;
        public ConjuntoDBText()
        {
            _manejadorDeArchivos = new ManejadorDeArchivos();
            _datos = new List<T>();
            CargarDatos();
        }

        private void CargarDatos()
        {
            Type tipo = typeof(T);
            string archivo = tipo.Name;
            string lineas = _manejadorDeArchivos.LeerArchivo($"..\\{archivo}.txt").Replace("\r", "");
            if (lineas.Any())
            {
                string[] arregloDelineas = lineas.Split("\n".ToCharArray());
                columnas = arregloDelineas[0];
                string[] nombresColumnas = columnas.Split("\t".ToCharArray());
                for (int i = 1; i < arregloDelineas.Length; i++)
                {
                    string[] columnas = arregloDelineas[i].Split("\t".ToCharArray());
                    T objeto = ColumnasAObjeto(tipo, nombresColumnas, columnas);
                    _datos.Add(objeto);
                }
            }

        }

        private T ColumnasAObjeto(Type tipo, string[] nombresColumnas, string[] columnasValor )
        {
            T objeto = new T();
            for (int i = 0; i < nombresColumnas.Length; i++)
            {
                PropertyInfo propInfo = tipo.GetProperty(nombresColumnas[i]);
                propInfo.SetValue(objeto, Convert.ChangeType(columnasValor[i], propInfo.PropertyType), null);
            }
            return objeto;
        }

        public IEnumerable<T> ObtenerTodo()
        {
            return _datos;
        }

        private string ObjetoATexto(string[] nombresColumnas, T objeto)
        {
            PropertyInfo propInfoID = objeto.GetType().GetProperty(nombresColumnas[0]);
            string texto = $"{propInfoID.GetValue(objeto, null)}";
            for (int i = 1; i < nombresColumnas.Length; i++)
            {
                PropertyInfo propInfo = objeto.GetType().GetProperty(nombresColumnas[i]);
                texto += $"\t{propInfo.GetValue(objeto, null)}";
            }
            return texto;
        }

        private string ListaATexto()
        {
            string texto = $"{columnas}";
            string[] nombresColumnas = columnas.Split("\t".ToCharArray());
            for (int i = 0; i < _datos.Count; i++)
            {
                string objetoTexto = ObjetoATexto(nombresColumnas, _datos[i]);
                texto += $"\n{objetoTexto}";
            }
            return texto;
        }

        public bool GuardarCambios()
        {
            Type tipo = typeof(T);
            string archivo = tipo.Name;
            string datos = ListaATexto();
            return _manejadorDeArchivos.EscribirArchivo($"..\\{archivo}.txt", datos);
        }

        public T Crear(T elemento)
        {
            Type tipo = elemento.GetType();
            string clase = tipo.Name;
            PropertyInfo propiedadID = tipo.GetProperty($"{clase}ID");
            int maximo = (int) _datos.Max(o => o.GetType().GetProperty($"{clase}ID").GetValue(o));
            tipo.GetProperty($"{clase}ID").SetValue(elemento, maximo + 1, null);
            _datos.Add(elemento);
            bool resultado = GuardarCambios();
            if (resultado)
            {
                return elemento;
            }
            return default;
        }

        public T Editar(int id, T elemento)
        {
            T encontrado = ObtenerUno(id);
            Type tipo = typeof(T);
            PropertyInfo[] propiedades = tipo.GetProperties();
            if (encontrado != null)
            {
                foreach (PropertyInfo propiedad in propiedades)
                {
                    propiedad.SetValue(encontrado, elemento.GetType().GetProperty(propiedad.Name).GetValue(elemento), null);
                }
            }
            bool resultado = GuardarCambios();
            if (resultado)
            {
                return encontrado;
            }
            return default;
        }

        public bool Eliminar(int id)
        {
            T encontrado = ObtenerUno(id);
            if (encontrado != null)
            {
                bool eliminado = _datos.Remove(encontrado);
                if (eliminado)
                {
                    return GuardarCambios();
                }
            }
            return false;
        }

        public T ObtenerUno(int id)
        {
            Type tipo = typeof(T);
            string clase = tipo.Name;
            return _datos.FirstOrDefault(o => (int)o.GetType().GetProperty($"{clase}ID").GetValue(o) == id);
        }
    }
}
