 

---------- CREATEDATABASE.SQL
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'AsignadorTareas')
begin
	ALTER DATABASE [AsignadorTareas] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
	DROP DATABASE [AsignadorTareas] 
end
GO

CREATE DATABASE AsignadorTareas

GO
WAITFOR DELAY '00:00:02'
GO

Use [AsignadorTareas]

GO 

---------- TIMECONTROLLER_CREATE.SQL

-- create Rol table
CREATE TABLE [AsignadorTareas].[dbo].[Rol](
	[RolID] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](20) NOT NULL,
	CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ([RolID] ASC)
)
;

-- create Estado table
CREATE TABLE [dbo].[Estado](
	[EstadoID] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstado] [varchar](20) NOT NULL,
	CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED ([EstadoID] ASC)
)
;

-- create EstadoTarea table
CREATE TABLE [dbo].[EstadoTarea](
	[EstadoTareaID] [int] IDENTITY(1,1) NOT NULL,
	[EstadoID] [int] NOT NULL,
	CONSTRAINT [PK_EstadoTarea] PRIMARY KEY CLUSTERED ([EstadoTareaID] ASC)
)
;

-- create EstadoUsuario table
CREATE TABLE [dbo].[EstadoUsuario](
	[EstadoUsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[EstadoID] [int] NOT NULL,
	CONSTRAINT [PK_EstadoUsuario] PRIMARY KEY CLUSTERED ([EstadoUsuarioID] ASC)
)
;

-- create Persona table
CREATE TABLE [dbo].[Persona](
	[PersonaID] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](100) NOT NULL,
	[Apellidos] [varchar](100) NOT NULL,
	[UsuarioID] [int] NOT NULL,
	CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED ([PersonaID] ASC)
)
;

-- create Tarea table
CREATE TABLE [dbo].[Tarea](
	[TareaID] [int] IDENTITY(1,1) NOT NULL,
	[NombreTarea] [varchar](100) NULL,
	[Fecha] [datetime] NULL,
	[EstadoTareaID] [int] NOT NULL,
	[PersonaID] [int] NOT NULL,
	CONSTRAINT [PK_Tarea] PRIMARY KEY CLUSTERED ([TareaID] ASC)
)
;
-- create Usuario Today
CREATE TABLE [dbo].[Usuario](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[EstadoUsuarioID] [int] NOT NULL,
	[RolID] [int] NOT NULL,
	CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([UsuarioID] ASC)
)
;

-- 
/*
ALTER TABLE [dbo].[Product]     
ADD CONSTRAINT FK_Product_ProductCategoryID FOREIGN KEY (ProductCategoryID)     
    REFERENCES [dbo].[ProductCategory] (ProductCategoryID)   */
	
--ALTER TABLE [dbo].[ClockInOut]     
--ADD CONSTRAINT FK_ClockInOut_WorkerID FOREIGN KEY (Worker_WorkerID)     
--    REFERENCES [dbo].[Worker] (WorkerID)
--;
--ALTER TABLE [dbo].[ClockInOut]
--ADD CONSTRAINT FK_ClockInOut_ProjectID FOREIGN KEY (Project_ProjectID)
--	REFERENCES [dbo].[Project] (ProjectID)   
--;

--ALTER TABLE [dbo].[ClockInOutToday]
--ADD CONSTRAINT FK_ClockInOut_ClockInOutID FOREIGN KEY (ClockInOut_ClockInOutID)
--	REFERENCES [dbo].[ClockInOut] (ClockInOutID)   
--;
 
INSERT INTO [Estado] ([NombreEstado]) VALUES ('Activo'), ('Inactivo'), ('En Espera'), ('En Progreso'), ('Finalizado');

INSERT INTO [EstadoTarea] ([EstadoID]) VALUES (3), (4), (5);

INSERT INTO [EstadoUsuario] ([EstadoID]) VALUES (1), (2);

INSERT INTO [Rol] ([NombreRol]) VALUES ('Admin'), ('Usuario');

INSERT INTO [Usuario] ([Username], [Password], [EstadoUsuarioID], [RolID]) 
VALUES ('admin', 'admin', 1, 1), ('linette', '123456', 1, 2), ('jhonny', '123', 2, 1);

INSERT INTO [Persona] ([Nombres], [Apellidos], [UsuarioID]) 
VALUES ('admin', 'admin', 1), ('Linette', 'Vidal Rodriguez', 2), ('Jhon', 'Doe', 3);

INSERT INTO [Tarea] ([NombreTarea], [Fecha], [EstadoTareaID], [PersonaID]) 
VALUES ('Tarea1', '2020-10-10', 1, 2), ('Tarea2', '2020-10-10', 2, 3);
GO 

SELECT * FROM [AsignadorTareas].[dbo].[Rol];