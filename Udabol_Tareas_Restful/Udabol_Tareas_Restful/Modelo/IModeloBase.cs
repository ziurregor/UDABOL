using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public interface IModeloBase
    {
        public List<String> OrdenCampos();
        public Dictionary<String, String> Excepciones();

        public String darLlave();

        public Boolean llaveEsAutoIncremental();
    }
}
