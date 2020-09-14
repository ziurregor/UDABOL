using System;

namespace Modelo
{
    public interface IUsuario : IModelo
    {
        public IUsuario ObtenerUnUsuario(string usuario, string contrasena);
        IRol obtenerRol();
        String ObtenerNombre();
        string ObtenerId();
    }
}