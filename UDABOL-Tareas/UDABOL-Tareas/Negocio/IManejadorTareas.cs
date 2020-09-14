using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocios
{

    public interface IManejadorTareas
    {
        public List<ITarea> ListarTareas();
        // [Nombre:Fulanito de tal, Estado:Pendiente,Tarea:Limpiar Habitacion]------>SuperUsuario
        // [Estado:En Proceso]------>Usuario Comun        

        // Update Tabla set camposAModificar where identificador=valorIdentificador
        public ITarea ModificarTarea(Dictionary<String,String> camposAModificar,KeyValuePair<String,String> condicion);

    }
}
