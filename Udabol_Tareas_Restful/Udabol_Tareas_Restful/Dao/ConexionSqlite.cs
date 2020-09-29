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
                String directorioSeparador = "/";

                OperatingSystem os = Environment.OSVersion;
                PlatformID pid = os.Platform;
                switch (pid)
                {
                    case PlatformID.Win32NT:
                    case PlatformID.Win32S:
                    case PlatformID.Win32Windows:
                    case PlatformID.WinCE:
                        directorioSeparador="\\";
                        break;
                    case PlatformID.Unix:
                    case PlatformID.MacOSX:
                        directorioSeparador = "/";
                        break;
                    default:
                        directorioSeparador = "/";
                        break;
                }

            String archivo = "DataSource="+directorioActual + directorioSeparador + Configuracion.baseDatosNombre + ".db";
                conexion = new SQLiteConnection(archivo);
                conexion.Open();
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
                    if (ExecuteNonQuery("create table if not exists " + tipo.Name + "(" + String.Join(",",campos) + ");"))
                    {
                        return true;
                    }
                }

            }catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            
            return false;
        }

        private Boolean ExecuteNonQuery(String query) {
            try
            {
                SQLiteCommand cmd = conexion.CreateCommand();

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }


        public Boolean EliminarRegistro(KeyValuePair<String,String> condicion)
        {
            if (condicion.Key != null && condicion.Value != null)
            {
                if (ExecuteNonQuery("delete from " + _tipo.Name + " where " + condicion.Key + "=\"" + condicion.Value + "\""))
                {
                    return true;
                }
            }
            
            return false;
        }

        public bool EscribirTabla( List<IModeloBase> lista)
        {
            // TODO --->>Sqlite doesnt need this but may be we could implement a commit and rollback
            return true;
        }

        public bool Guardar()
        {
            // TODO --->>Sqlite doesnt need this but may be we could implement a commit and rollback
            return true;
        }

        public List<IModeloBase> LeerTabla()
        {
            return EjecutarQuery("Select * from " + _tipo.Name);
        }

        private List<IModeloBase> EjecutarQuery(string query)
        {
            List<IModeloBase> lista = new List<IModeloBase>();
            SQLiteCommand cmd = conexion.CreateCommand();
            cmd.CommandText = query;
            SQLiteDataReader lector = cmd.ExecuteReader();

            while (lector.Read())
            {
                if (lector.HasRows && lector.FieldCount > 0)
                {
                    IModeloBase objeto = ModeloFactory.darInstancia(_tipo);
                    List<String> listaCampos = objeto.OrdenCampos();

                    Dictionary<String, String> excepciones = objeto.Excepciones();

                    foreach (String campo in listaCampos)
                    {
                        if (!campo.Trim().Equals(""))
                        {
                            PropertyInfo propiedad = _tipo.GetProperty(campo);
                            Utilidades.PasarValorCampo(excepciones, propiedad, objeto, lector[propiedad.Name].ToString());
                        }
                    }

                    lista.Add(objeto);
                }
            }
            return lista;
        }

        public List<T> LeerTabla<T>()
        {
            List<T> lista = new List<T>();
            String query = "Select * from " + typeof(T).Name;
            SQLiteCommand cmd = conexion.CreateCommand();
            cmd.CommandText = query;
            SQLiteDataReader lector = cmd.ExecuteReader();
            while (lector.Read())
            {

                if (lector.HasRows && lector.FieldCount > 0)
                {
                    IModeloBase objeto = ModeloFactory.darInstancia(typeof(T));
                    List<String> listaCampos = objeto.OrdenCampos();

                    Dictionary<String, String> excepciones = objeto.Excepciones();

                    foreach (String campo in listaCampos)
                    {
                        if (!campo.Trim().Equals(""))
                        {
                            PropertyInfo propiedad = _tipo.GetProperty(campo);
                            Utilidades.PasarValorCampo(excepciones, propiedad, objeto, lector[propiedad.Name].ToString());
                        }
                    }
                    lista.Add((T)objeto);

                }

            }
            return lista;
        }

        public bool Modificar(Dictionary<string, string> campos, KeyValuePair<string, string> condicion)
        {
            if (campos != null && condicion.Key != null && condicion.Value != null)
            {
                String query = "update "+_tipo.Name+" set "+String.Join(",",campos.Select(p=>p.Key+"=\""+p.Value+"\"")) + " where " + condicion.Key+"=\""+condicion.Value+"\";";
                if (ExecuteNonQuery(query)) {
                    return true;
                }
            }

            return false;
        }

        public bool Crear(IModeloBase fuente)
        {
            if (fuente != null)
            {
                PropertyInfo[] propiedades = _tipo.GetProperties();
                Dictionary<String, String> campos = new Dictionary<string, string>();
                foreach (PropertyInfo propiedad in propiedades)
                {
                    campos.Add(propiedad.Name,propiedad.GetValue(fuente).ToString());
                }
                String query = "insert into " + _tipo.Name + " (" + String.Join(",",campos.Keys)+ ") values (" + String.Join(",",campos.Values.Select(p => "\"" + p + "\"")) + ");";
                if (ExecuteNonQuery(query))
                {
                    return true;
                }
            }
            return false;
        }

        public IModeloBase Obtener(KeyValuePair<string, string> condicion)
        {
            if (condicion.Key!=null && condicion.Value!=null) {
                String query = "select * from "+_tipo.Name+" where "+condicion.Key+"=\""+condicion.Value+"\" limit 1;";
                List<IModeloBase> lista = EjecutarQuery(query);
                if (lista.Count > 0) {
                    return lista.First();
                }
            }
            return null;
        }
    }
}