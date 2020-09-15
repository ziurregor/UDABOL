using System;

namespace Modelo
{
    public interface ITarea : IModelo
    {
        int ObtenerFecha();
        int ObtenerNombre();
        IUsuario ObtenerUsario();
        String ObtenerEstado();
    }
}