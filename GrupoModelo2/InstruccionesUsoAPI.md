
#Metodos Get
	------------------------------------------------------------------------
	//Estado
	------------------------------------------------------------------------

	Para obtener los tipos de estados de los usuarios:

	-> https://localhost:{{numeroPuerto}}/api/estados/usuarios

	Para obtener los tipos de estados de las tareas:

	-> https://localhost:{{numeroPuerto}}/api/estados/tareas

	------------------------------------------------------------------------
	//Rol
	------------------------------------------------------------------------

	Para obtener los tipos de roles de los usuarios:

	-> https://localhost:{{numeroPuerto}}/api/roles

	------------------------------------------------------------------------
	//Usuario
	------------------------------------------------------------------------

	Para obtener todos los usuarios:

	-> https://localhost:{{numeroPuerto}}/api/usuarios

	Para obtener un usuario por ID:

	-> https://localhost:{{numeroPuerto}}/api/usuarios/{{numeroDeId}}

	------------------------------------------------------------------------
	//Tareas
	------------------------------------------------------------------------

	Para obtener todas las tareas:

	-> https://localhost:{{numeroPuerto}}/api/tareas

	Para obtener una tarea por ID:

	-> https://localhost:{{numeroPuerto}}/api/tareas/{{numeroDeId}}

#Metodos Post

	------------------------------------------------------------------------
	//Usuario
	------------------------------------------------------------------------

	Para crear un usuario:

	-> https://localhost:{{numeroPuerto}}/api/usuarios

	Body: 
		{
			"nombres": "Jhon",
			"apellidos": "Doe",
			"username": "Jhonny",
			"password": "1234",
			"estadoUsuarioID": 2,
			"rolID": 1
		}
	------------------------------------------------------------------------
	//Tareas
	------------------------------------------------------------------------

	Para crear una tarea:

	-> https://localhost:{{numeroPuerto}}/api/tareas

	Body:
		{
			"nombreTarea": "Tarea4",
			"fecha": "2020-10-10T00:00:00",
			"estadoTareaID": 1,
			"personaID": 2
		}

#Metodos Put

	------------------------------------------------------------------------
	//Usuario
	------------------------------------------------------------------------

	Para actualizar un usuario:

	-> https://localhost:{{numeroPuerto}}/api/usuarios/{{numeroDeID}}

	Body: 
		{
			"usuarioID": {{numeroDeID}},
			"nombres": "Jhon",
			"apellidos": "Doe",
			"username": "Jhonny",
			"password": "1234",
			"estadoUsuarioID": 2,
			"rolID": 1
		}
	------------------------------------------------------------------------
	//Tareas
	------------------------------------------------------------------------

	Para actualizar una tarea:

	-> https://localhost:{{numeroPuerto}}/api/tareas/{{numeroDeID}}

	Body:
		{
			"tareaID": {{numeroDeID}},
			"nombreTarea": "Tarea4",
			"fecha": "2020-10-10T00:00:00",
			"estadoTareaID": 1,
			"personaID": 2
		}

#Metodos Delete
	------------------------------------------------------------------------
	//Usuario
	------------------------------------------------------------------------

	Para eliminar un usuario:

	-> https://localhost:{{numeroPuerto}}/api/usuarios/{{numeroDeID}}

	------------------------------------------------------------------------
	//Tareas
	------------------------------------------------------------------------

	Para eliminar una tarea:

	-> https://localhost:{{numeroPuerto}}/api/tareas/{{numeroDeID}}
