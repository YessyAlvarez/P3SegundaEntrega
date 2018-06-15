/**Creación de Base de Datos gestionTramites**/

--creación de la Base de datos--
CREATE DATABASE gestionTramites;
GO

--Uso de la Base de Datos--
USE gestionTramites;
GO

/**Creación de Tablas**/

--Creación de tabla Grupo--
CREATE TABLE Grupo(
	idGrupo INTEGER IDENTITY(1,1) NOT NULL,
	nombreGrupo VARCHAR(50) NOT NULL,
	PRIMARY KEY(idGrupo)
);
GO

--Creación de tabla Rol--
CREATE TABLE Rol(
	idRol INTEGER IDENTITY(1,1) NOT NULL,
	nombreRol VARCHAR(50) NOT NULL,
	PRIMARY KEY(idRol),
	CONSTRAINT Uk_NombreRol UNIQUE (nombreRol)
);
GO

--Creación de tabla Usuario--
CREATE TABLE Usuario(
	idUsuario INTEGER IDENTITY(1,1) NOT NULL,
	email VARCHAR(50) UNIQUE NOT NULL,
	password VARCHAR(50) NOT NULL,
	nombreCompleto VARCHAR(50) NOT NULL,
	idRol INTEGER NOT NULL,
	FOREIGN KEY(idRol) REFERENCES Rol(idRol),
	PRIMARY KEY(idUsuario)
);
GO

--Creación de tabla UsuarioGrupo--
CREATE TABLE UsuarioGrupo(
	idUsuario INTEGER NOT NULL,
	idGrupo INTEGER NOT NULL,
	FOREIGN KEY(idUsuario) REFERENCES Usuario(idUsuario),
	FOREIGN KEY(idGrupo) REFERENCES Grupo(idGrupo),
	PRIMARY KEY(idUsuario,idGrupo)
);
GO

--Creación de tabla Tramite--
CREATE TABLE Tramite(
	idTramite INTEGER IDENTITY(1,1) not null,
	tituloTramite VARCHAR(30) NOT NULL,
	descTramite VARCHAR(60) NOT NULL,
	costoTramite INTEGER NOT NULL,
	tiempoTramite INTEGER NOT NULL,
	CONSTRAINT Pk_IdTramite PRIMARY KEY (idTramite),
	CONSTRAINT Uk_Titulo UNIQUE (tituloTramite)
);
GO


--Creación de tabla Etapa--
CREATE TABLE Etapa(
	codigo VARCHAR(30) NOT NULL,
	descripcion VARCHAR(60) NOT NULL,
	lapsoMaxEtapas INTEGER NOT NULL,
	activa CHAR(1) NOT NULL,
	idTramite INTEGER not null,
	CONSTRAINT Pk_Codigo PRIMARY KEY (codigo),
	--CONSTRAINT Fk_idTramite FOREIGN KEY (idTramite) REFERENCES Tramite (idTramite)
);
GO

--Creación de tabla GrupoTramite--
CREATE TABLE GrupoTramite(
	idGrupoTramite INTEGER IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(50) NOT NULL,
	cantMaxFuncionarios INTEGER NOT NULL,
	idGrupo INTEGER NOT NULL,
	idTramite INTEGER NOT NULL,
	PRIMARY KEY(idGrupoTramite),
	CONSTRAINT Fk_idGrupo FOREIGN KEY(idGrupo) REFERENCES Grupo(idGrupo),
	--CONSTRAINT Fk_idTramiteG FOREIGN KEY (idTramite) REFERENCES Tramite (idTramite)
);
GO

/**Inserción de datos en las tablas**/

--Insertar datos en tabla Grupo--
INSERT INTO Grupo VALUES('Grupo 1');
INSERT INTO Grupo VALUES('Grupo 2');
INSERT INTO Grupo VALUES('Grupo 3');
INSERT INTO Grupo VALUES('Grupo 4');
INSERT INTO Grupo VALUES('Grupo 5');
INSERT INTO Grupo VALUES('Grupo 6');
GO

--Insertar datos en tabla Rol--
INSERT INTO Rol VALUES('Admin');
INSERT INTO Rol VALUES('FuncionarioMantenimiento');
INSERT INTO Rol VALUES('FuncionarioEscribano');
GO

--Insertar datos en tabla Usuario--
INSERT INTO Usuario VALUES('admin', '202cb962ac59075b964b07152d234b70', 'Admin ADMIN', 1);
INSERT INTO Usuario VALUES('func', '202cb962ac59075b964b07152d234b70', 'Funcionario MANTENIMIENTO', 2);
GO

--Insertar datos en tabla UsuarioGrupo--
INSERT INTO UsuarioGrupo VALUES(1,1);
INSERT INTO UsuarioGrupo VALUES(2,3);
GO

--Insertar datos en tabla Tramite--
INSERT INTO Tramite Values('tramite1', 'es el tramite 1', 23, 3);
INSERT INTO Tramite VALUES('Informe','La entidad empleadora deberá solicitar informe de adecuación', 22, 4);
INSERT INTO Tramite VALUES('Tramitacion','Se establece el procedimiento electrónico',15,  5);
INSERT INTO Tramite VALUES('Renovacion','Se establece el procedimiento electrónico', 18, 6);
INSERT INTO Tramite VALUES('DeclaracionJurada','declaración jurada bajo juramento ante autoridades', 23, 8);
GO

--Insertar datos en tabla Etapa--
INSERT INTO Etapa VALUES ('123asdfg', 'En esta etapa se completa la solicitud del informe', 2, 1, 1);
INSERT INTO Etapa VALUES ('124asdfg', 'Se completan datos necesarios para un servicio', 4, 1, 2);
INSERT INTO Etapa VALUES ('125asdfg', 'Validacion de los datos ingresados.', 5, 1, 4);
INSERT INTO Etapa VALUES ('126asdfg', 'Identificación de la entidad empleadora', 3, 1, 3);
GO

--Insertar datos en tabla GrupoTramite--
INSERT INTO GrupoTramite VALUES ('Encargados de mantención del servicios',5, 2,2);
INSERT INTO GrupoTramite VALUES ('Derivación de documentos', 7, 1,1);
INSERT INTO GrupoTramite VALUES ('Presentación de archivos legales para registros', 5, 3, 3);
GO
