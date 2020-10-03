using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Dao;
using Modelo;

namespace Dao
{
    public class ConexionTexto : IConexion
    {
        private String _archivo;
        private String _contenido;
        private Type _tipo;

        public bool Conectar(string cadenaDeConexion,Type tipo)
        {
            try
            {
                _tipo = tipo;
                _archivo = cadenaDeConexion;
                if (File.Exists(_archivo))
                {
                    _contenido = File.ReadAllText(_archivo);
                }
                else _contenido = "";
                return true;
            }
            catch (Exception ex) {
                System.Console.WriteLine("Ha ocurrido un Error: "+ex.Message);
            }
            return false;
        }

        /* ROL
         * 1    Usuario Comun
         * 2    Super Usuario
         * 
         * Usuario
         * 
         * 1    Fulanito de tal 1
         * 2    SuperUsuario    2
         * 
         * 
         */

        public Boolean EliminarRegistro(Int32 numeroLinea )
        {


            String[] lineas = _contenido.Split("\n");
            _contenido = "";
            for (int i=0;i<lineas.Length;i++) {
                if (i != numeroLinea) {
                    _contenido += lineas[i] + "\n";
                }
            }

            /*List<String> listaLineas = new List<string>(lineas);
            listaLineas.RemoveAt(numeroLinea);
            _contenido = "";
            foreach (String linea in listaLineas) {
                _contenido += linea + "\n";
            }*/
            return true;
        }

        public bool EscribirTabla( List<ModeloBase> lista)
        {
            try
            {
                if (lista != null )
                {
                    String contenido = "";
                    foreach (ModeloBase _objeto in lista) {
<<<<<<< HEAD
                         contenido+= _objeto.guardarTexto()+"\n";
=======
                        IObjetoTexto _objetoTexto = (IObjetoTexto)_objeto;
                         contenido+= _objetoTexto.guardarTexto()+"\n";
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
                    }
                    File.WriteAllText(_archivo, contenido);
                    _contenido = contenido;
                    return true;
                }
            }
            catch (Exception ex) {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            return false;
        }

        public bool Guardar()
        {
            try
            {
                File.WriteAllText(_archivo, _contenido, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            return false;
        }

        public List<ModeloBase> LeerTabla()
        {
            List<ModeloBase> lista = new List<ModeloBase>();
            try
            {
                String[] lineas = _contenido.Split("\n");
<<<<<<< HEAD
=======
                List<ModeloBase> lista = new List<ModeloBase>();
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e
                for (int i=0;i<lineas.Length;i++) {
                    lineas[i] = lineas[i].Trim();
                    ModeloBase _objeto = (ModeloBase)ModeloBase.darInstancia(_tipo);
                    lista.Add(_objeto.leerTexto(lineas[i]));
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Ha ocurrido un Error: " + ex.Message);
            }
            return lista;
        }
    }
}