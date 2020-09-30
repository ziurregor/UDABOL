using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class ManejadorDeSqlServer<T> where T : new()
    {
        public static IEnumerable<T> RealizarConsultaSelect(string ruta)
        {
            try
            {
                Type tipo = typeof(T);
                string tabla = tipo.Name;
                List<T> objetos = new List<T>();
                Trace.TraceInformation($"entro con ruta1: {ruta}");
                using (SqlConnection connection = new SqlConnection(ruta))
                {
                    connection.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append("SELECT * ");
                    consulta.Append($"FROM [{tabla}]");
                    string sql = consulta.ToString();
                    Trace.TraceInformation($"entro con ruta2");
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        Trace.TraceInformation($"entro con ruta3");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Trace.TraceInformation($"entro con reader {reader.FieldCount}");
                            while (reader.Read())
                            {
                                T objeto = new T();
                                for(int i = 0; i < reader.FieldCount; i ++)
                                {
                                    string nombreColumna = reader.GetName(i);
                                    var columnaValor = reader.GetValue(i);
                                    PropertyInfo propInfo = tipo.GetProperty(nombreColumna);
                                    propInfo.SetValue(objeto, Convert.ChangeType(columnaValor, propInfo.PropertyType), null);
                                }
                                objetos.Add(objeto);
                            }
                        }
                    }
                }
                return objetos;
            }
            catch (SqlException e)
            {
                Trace.TraceError($"error en ruta: {e.ToString()}");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static T RealizarConsultaInsert(string ruta, T elemento)
        {
            try
            {
                Type tipo = elemento.GetType();
                string clase = tipo.Name;
                using (SqlConnection connection = new SqlConnection(ruta))
                {
                    connection.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append($"INSERT INTO [{clase}] ");
                    PropertyInfo[] propiedades = tipo.GetProperties().Where(p => p.Name != $"{clase}ID").ToArray();
                    consulta.Append($"([{propiedades[0].Name}] ");
                    for (int i = 1; i < propiedades.Length; i++)
                    {
                        consulta.Append($", [{propiedades[i].Name}]");
                    }
                    consulta.Append($") VALUES (@{propiedades[0].Name}");
                    for (int i = 1; i < propiedades.Length; i++)
                    {
                        consulta.Append($", @{propiedades[i].Name}");
                    }
                    consulta.Append($"); SELECT SCOPE_IDENTITY()");
                    string sql = consulta.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        for (int i = 0; i < propiedades.Length; i++)
                        {
                            var valor = tipo.GetProperty($"{propiedades[i].Name}").GetValue(elemento, null);
                            command.Parameters.AddWithValue($"@{propiedades[i].Name}", valor);
                        }
                        var elementoID = command.ExecuteScalar();
                        PropertyInfo propInfo = tipo.GetProperty($"{clase}ID");
                        propInfo.SetValue(elemento, Convert.ChangeType(elementoID, propInfo.PropertyType), null);
                    }
                }
                return elemento;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return default;
            }
        }

        public static T RealizarConsultaUpdate(string ruta, int id, T elemento)
        {
            try
            {
                Type tipo = elemento.GetType();
                string clase = tipo.Name;
                using (SqlConnection connection = new SqlConnection(ruta))
                {
                    connection.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append($"UPDATE [{clase}] ");
                    PropertyInfo[] propiedades = tipo.GetProperties().Where(p => p.Name != $"{clase}ID").ToArray();
                    consulta.Append($"SET [{propiedades[0].Name}]=@{propiedades[0].Name} ");
                    for (int i = 1; i < propiedades.Length; i++)
                    {
                        consulta.Append($", [{propiedades[i].Name}]=@{propiedades[i].Name}");
                    }
                    consulta.Append($" WHERE [{clase}ID]=@{clase}ID");
                    string sql = consulta.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue($"@{clase}ID", id);
                        for (int i = 0; i < propiedades.Length; i++)
                        {
                            var valor = tipo.GetProperty($"{propiedades[i].Name}").GetValue(elemento, null);
                            command.Parameters.AddWithValue($"@{propiedades[i].Name}", valor);
                        }
                        command.ExecuteNonQuery();
                    }
                }
                return elemento;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return default;
            }
        }

        public static bool RealizarConsultaDelete(string ruta, int id)
        {
            try
            {
                Type tipo = typeof(T);
                string tabla = tipo.Name;
                using (SqlConnection connection = new SqlConnection(ruta))
                {
                    connection.Open();
                    StringBuilder consulta = new StringBuilder();
                    consulta.Append($"DELETE FROM [{tabla}] ");

                    consulta.Append($"WHERE [{tabla}ID]=@{tabla}ID");
                    string sql = consulta.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue($"@{tabla}ID", id);
                        int columnaAfectada = command.ExecuteNonQuery();
                        if (columnaAfectada == 0) return false;
                    }
                }
                return true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }
    }
}
