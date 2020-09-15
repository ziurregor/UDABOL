using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public interface IObjetoTexto
    {
        public string guardarTexto();

        public IObjetoTexto leerTexto(String texto);
    }
}
