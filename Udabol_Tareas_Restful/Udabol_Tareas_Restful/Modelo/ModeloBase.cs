using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modelo
{
    public abstract class ModeloBase : IModeloBase
    {

        virtual public Dictionary<String, String> Excepciones() {
            Dictionary<String, String> lista=new Dictionary<string, string>();
            return lista;
        }
        public abstract List<string> OrdenCampos();
    }
}
