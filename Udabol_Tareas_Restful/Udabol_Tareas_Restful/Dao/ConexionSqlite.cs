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
            // TODO --->>Sqlite doesnt need this but may be we could implement a commit and rollback
            return true;
        }

        public bool Guardar()
        {
            // TODO --->>Sqlite doesnt need this but may be we could implement a commit and rollback
            return true;
        }

        public List<IObjetoTexto> LeerTabla()
        {
            List<IObjetoTexto> lista = new List<IObjetoTexto>();
            String query = "Select * from "+ _tipo.Name;
            conexion.Open();
            SQLiteCommand cmd = new SQLiteCommand(query);
            SQLiteDataReader lector = cmd.ExecuteReader();
            PropertyInfo[] propiedades = _tipo.GetProperties();
            while (lector.Read())
            {
                if (lector.HasRows && lector.FieldCount > 0) {
                    IObjetoTexto objeto= ModeloFactory.darInstancia(_tipo);
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        propiedad.SetValue(objeto, lector[propiedad.Name]);

                    }
                    lista.Add(objeto);

                }
            }
            conexion.Close();
            return lista;
        }

        public List<T> LeerTabla<T>()
        {
            List<T> lista = new List<T>();
            String query = "Select * from " + typeof(T).Name;
            conexion.Open();
            SQLiteCommand cmd = new SQLiteCommand(query);
            SQLiteDataReader lector = cmd.ExecuteReader();
            PropertyInfo[] propiedades = _tipo.GetProperties();
            while (lector.Read())
            {

                if (lector.HasRows && lector.FieldCount > 0)
                {
                    T objeto = ModeloFactory.darInstancia<T>();
                    foreach (PropertyInfo propiedad in propiedades)
                    {
                        propiedad.SetValue(objeto, lector[propiedad.Name]);

                    }
                    lista.Add(objeto);

                }

            }
            conexion.Close();
            return lista;
        }
    }
}