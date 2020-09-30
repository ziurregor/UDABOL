using System;
using System.Collections.Generic;

namespace consumWEB
{
    public abstract class ModeloBase //: IModeloBase
    {
        public virtual String darLlave()
        {
            return "";
        }
        public virtual Boolean llaveEsAutoIncremental()
        {
            return false;
        }
        virtual public Dictionary<String, String> Excepciones()
        {
            Dictionary<String, String> lista = new Dictionary<string, string>();
            return lista;
        }
        public abstract List<string> OrdenCampos();
    }
}