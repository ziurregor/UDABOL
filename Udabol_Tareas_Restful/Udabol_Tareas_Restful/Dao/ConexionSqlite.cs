using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Modelo;
using Negocio;
using Util;

namespace Dao
{
    public class ConexionSqlite: IConexion
    {
        private static SQLiteConnection conexion=null ;

        private Type _tipo;

        public ConexionSqlite() {
            if (conexion == null) {

                String directorioActual = Directory.GetCurrentDirectory();
                String archivo = "DataSource="+directorioActual + "\\" + Configuracion.baseDatosNombre + ".db";
                conexion = new SQLiteConnection(archivo);
            }
        }

        public bool Conectar(Type tipo)
        {
            _tipo = tipo;
            try
            {
                PropertyInfo[] propiedades = tipo.GetProperties();
                if (propiedades.Length > 0)
                {
                    List<String> campos = new List<String>();
                    Boolean primary = false;
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        String linea = propiedad.Name;
                        switch (propiedad.PropertyType.Name)
                        {
                            case "Int32":
                                linea += " Integer not null";
                                break;
                            default:
                                linea += " Text not null";
                                break;
                        }
                        if (!primary)
                        {
                            linea += " primary key";

                            //TODO auto_increment

                            primary = true;
                        }
                        campos.Add(linea);
                    }
                    ExecuteNonQuery("create table if not exists " + tipo.Name + "(" + campos.Join(",") + ");");
                }

            }catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            
            return false;
        }

        private void ExecuteNonQuery(String query) {
            conexion.Open();
            SQLiteCommand cmd = conexion.CreateCommand();

            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conexion.Close();
        }


        public Boolean EliminarRegistro(KeyValuePair<String,String> condicion)
        {
            if (condicion.Key != null && condicion.Value != null)
            {
                ExecuteNonQuery("delete from " + _tipo.Name + " where " + condicion.Key+ "=\""+condicion.Value+"\"");
            }
            
            return true;
        }

        public bool EscribirTabla( List<IObjetoTexto> lista)
        {
            /*try
            {
                if (lista != null )
                {
                    String contenido = "";
                    foreach (IObjetoTexto _objeto in lista) {
                        if (_objeto != null)
                        {
                            contenido += _objeto.guardarTexto() + "\n";
                        }
                    }
                    File.WriteAllText(_archivo, contenido);
                    _contenido = contenido;
                    return true;
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }*/
            return false;
        }

        public bool Guardar()
        {
            /*try
            {
                File.WriteAllText(_archivo, _contenido, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }*/
            return false;
        }

        public List<IObjetoTexto> LeerTabla()
        {
            List<IObjetoTexto> lista = new List<IObjetoTexto>();
           /*try
            {
                String[] lineas = _contenido.Split("\n");
                for (int i=0;i<lineas.Length;i++) {
                    lineas[i] = lineas[i].Trim();
                    if (!lineas[i].Equals(""))
                    {
                        IObjetoTexto _objeto = ModeloFactory.darInstancia(_tipo);
                        lista.Add(_objeto.leerTexto(lineas[i]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }*/


            return lista;
        }

        public List<T> LeerTabla<T>()
        {
            List<T> lista = new List<T>();
            /*try
            {
                String[] lineas = _contenido.Split("\n");
                for (int i = 0; i < lineas.Length; i++)
                {
                    lineas[i] = lineas[i].Trim();
                    if (!lineas[i].Equals(""))
                    {
                        IObjetoTexto _objeto = ModeloFactory.darInstancia(typeof(T));
                        lista.Add((T)_objeto.leerTexto(lineas[i]));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }*/
            return lista;
        }
    }
}