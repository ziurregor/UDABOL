using System;
using System.Collections.Generic;
using System.Text;
using Modelo;

namespace Negocio
{

    public interface IManejadorTareas
    {
        public List<ModeloBase> ListarTareas();
        // [Nombre:Fulanito de tal, Estado:Pendiente,Tarea:Limpiar Habitacion]------>SuperUsuario
        // [Estado:En Proceso]------>Usuario Comun        

        // Update Tabla set camposAModificar where identificador=valorIdentificador
<<<<<<< HEAD
        public Tarea Modificar(Dictionary<String,String> camposAModificar,KeyValuePair<String,String> condicion);
=======
        public Tarea ModificarTarea(Dictionary<String,String> camposAModificar,KeyValuePair<String,String> condicion);
>>>>>>> 28de24cf3f69704a0d9b5560ef35ea01244dc81e

    }
}
