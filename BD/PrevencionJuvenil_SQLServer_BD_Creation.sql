-- Conversion del Forward Engineer de MySQL Workbench a Microsoft SQL Server
-- Proyecto Prevencion de Violencia Juvenil
-- Ejecutar sobre una instancia nueva; no elimina tablas ni datos existentes.
-- Revision: los nombres del modelo original se conservan (incluido Distito).
IF DB_ID(N'PrevencionJuvenil') IS NULL
    CREATE DATABASE [PrevencionJuvenil];
GO
USE [PrevencionJuvenil];
GO

CREATE TABLE [dbo].[Provincia] (
    [idProvincia] INT IDENTITY(1,1) NOT NULL,
    [descripcion_provincia] NVARCHAR(45) NOT NULL,
    [activo] BIT NOT NULL,
    CONSTRAINT [PK_Provincia] PRIMARY KEY ([idProvincia])
);
GO

CREATE TABLE [dbo].[Canton] (
    [idCanton] INT IDENTITY(1,1) NOT NULL,
    [descripcion_canton] NVARCHAR(45) NOT NULL,
    [activo] BIT NOT NULL,
    [Provincia_idProvincia] INT NOT NULL,
    CONSTRAINT [PK_Canton] PRIMARY KEY ([idCanton]),
    CONSTRAINT [fk_Canton_Provincia1] FOREIGN KEY ([Provincia_idProvincia]) REFERENCES [dbo].[Provincia] ([idProvincia])
);
GO

CREATE TABLE [dbo].[Distito] (
    [idDistito] INT IDENTITY(1,1) NOT NULL,
    [descripcion_distrito] NVARCHAR(45) NOT NULL,
    [activo] BIT NOT NULL,
    [codigo_postal] NVARCHAR(12) NOT NULL,
    [Canton_idCanton] INT NOT NULL,
    CONSTRAINT [PK_Distito] PRIMARY KEY ([idDistito]),
    CONSTRAINT [fk_Distito_Canton1] FOREIGN KEY ([Canton_idCanton]) REFERENCES [dbo].[Canton] ([idCanton])
);
GO

CREATE TABLE [dbo].[tipoCatalogo] (
    [idtipoCatalogo] INT IDENTITY(1,1) NOT NULL,
    [nombre_catalogo] NVARCHAR(45) NOT NULL,
    [activo] BIT NOT NULL,
    CONSTRAINT [PK_tipoCatalogo] PRIMARY KEY ([idtipoCatalogo])
);
GO

CREATE TABLE [dbo].[catalogo] (
    [idcatalogo] INT IDENTITY(1,1) NOT NULL,
    [descripcion_catalogo] NVARCHAR(45) NOT NULL,
    [activo] BIT NOT NULL,
    [tipoCatalogo_idtipoCatalogo] INT NOT NULL,
    CONSTRAINT [PK_catalogo] PRIMARY KEY ([idcatalogo]),
    CONSTRAINT [fk_catalogo_tipoCatalogo1] FOREIGN KEY ([tipoCatalogo_idtipoCatalogo]) REFERENCES [dbo].[tipoCatalogo] ([idtipoCatalogo])
);
GO

CREATE TABLE [dbo].[Direccion] (
    [idDireccion] INT IDENTITY(1,1) NOT NULL,
    [otras_sennas] NVARCHAR(100) NOT NULL,
    [activo] BIT NOT NULL,
    [tipoDireccion_idcatalogo] INT NOT NULL,
    [Distito_idDistito1] INT NOT NULL,
    CONSTRAINT [PK_Direccion] PRIMARY KEY ([idDireccion]),
    CONSTRAINT [fk_DireccionCliente_catalogo1] FOREIGN KEY ([tipoDireccion_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo]),
    CONSTRAINT [fk_Direccion_Distito1] FOREIGN KEY ([Distito_idDistito1]) REFERENCES [dbo].[Distito] ([idDistito])
);
GO

CREATE TABLE [dbo].[Comunidad] (
    [idComunidad] INT IDENTITY(1,1) NOT NULL,
    [nombre_comunidad] NVARCHAR(45) NOT NULL,
    [descripcion_comunidad] NVARCHAR(45) NOT NULL,
    [Direccion_comunidad_idDireccion] INT NOT NULL,
    CONSTRAINT [PK_Comunidad] PRIMARY KEY ([idComunidad]),
    CONSTRAINT [fk_Comunidad_Direccion1] FOREIGN KEY ([Direccion_comunidad_idDireccion]) REFERENCES [dbo].[Direccion] ([idDireccion])
);
GO

CREATE TABLE [dbo].[Usuario] (
    [idUsuario] INT IDENTITY(1,1) NOT NULL,
    [cedula_usuario] NVARCHAR(20) NOT NULL,
    [nombre_usuario] NVARCHAR(20) NOT NULL,
    [apellido1_usuario] NVARCHAR(20) NOT NULL,
    [apellido2_usuario] NVARCHAR(20) NOT NULL,
    [fecha_nacimiento_usuario] DATE NOT NULL,
    [fecha_registro_usuario] DATETIME2(0) NOT NULL,
    [activo] BIT NOT NULL,
    [catalogoGeneroUsuario_idcatalogo] INT NOT NULL,
    [Comunidad_idComunidad] INT NOT NULL,
    [catalogoTipoUsuario_idcatalogo] INT NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([idUsuario]),
    CONSTRAINT [fk_Usuario_catalogo1] FOREIGN KEY ([catalogoGeneroUsuario_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo]),
    CONSTRAINT [fk_Usuario_Comunidad1] FOREIGN KEY ([Comunidad_idComunidad]) REFERENCES [dbo].[Comunidad] ([idComunidad]),
    CONSTRAINT [fk_Usuario_catalogo2] FOREIGN KEY ([catalogoTipoUsuario_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo])
);
GO

CREATE TABLE [dbo].[Actividad] (
    [idActividad] INT IDENTITY(1,1) NOT NULL,
    [nombre_actividad] NVARCHAR(45) NOT NULL,
    [descripcion_actividad] NVARCHAR(120) NOT NULL,
    [fecha_inicio_actividad] DATETIME2(0) NOT NULL,
    [fecha_fin_actividad] DATETIME2(0) NOT NULL,
    [cupo_maximo_actividad] INT NOT NULL,
    [Comunidad_idComunidad] INT NOT NULL,
    [catalogoEstadoActividad_idcatalogo] INT NOT NULL,
    [Direccion_idDireccion] INT NOT NULL,
    CONSTRAINT [PK_Actividad] PRIMARY KEY ([idActividad]),
    CONSTRAINT [CK_Actividad_fechas] CHECK ([fecha_fin_actividad] > [fecha_inicio_actividad]),
    CONSTRAINT [CK_Actividad_cupo] CHECK ([cupo_maximo_actividad] > 0),
    CONSTRAINT [fk_Actividad_Comunidad1] FOREIGN KEY ([Comunidad_idComunidad]) REFERENCES [dbo].[Comunidad] ([idComunidad]),
    CONSTRAINT [fk_Actividad_catalogo1] FOREIGN KEY ([catalogoEstadoActividad_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo]),
    CONSTRAINT [fk_Actividad_Direccion1] FOREIGN KEY ([Direccion_idDireccion]) REFERENCES [dbo].[Direccion] ([idDireccion])
);
GO

CREATE TABLE [dbo].[Participacion] (
    [idParticipacion] INT IDENTITY(1,1) NOT NULL,
    [fecha_inscripcion] DATETIME2(0) NOT NULL,
    [asistio] BIT NOT NULL,
    [Usuario_idUsuario] INT NOT NULL,
    [Actividad_idActividad] INT NOT NULL,
    CONSTRAINT [PK_Participacion] PRIMARY KEY ([idParticipacion]),
    CONSTRAINT [UQ_Participacion_Usuario_Actividad] UNIQUE ([Usuario_idUsuario], [Actividad_idActividad]),
    CONSTRAINT [fk_Participacion_Usuario1] FOREIGN KEY ([Usuario_idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario]),
    CONSTRAINT [fk_Participacion_Actividad1] FOREIGN KEY ([Actividad_idActividad]) REFERENCES [dbo].[Actividad] ([idActividad])
);
GO

CREATE TABLE [dbo].[Alerta] (
    [idAlerta] INT IDENTITY(1,1) NOT NULL,
    [asunto_alerta] NVARCHAR(45) NOT NULL,
    [descripcion_alerta] NVARCHAR(120) NOT NULL,
    [fecha_alerta] DATETIME2(0) NOT NULL,
    [estudiante_idUsuario] INT NOT NULL,
    [encargadoCreacionAlerta_idUsuario1] INT NOT NULL,
    [catalogoTipoAlerta_idcatalogo] INT NOT NULL,
    [catalogoEstadoAlerta_idcatalogo] INT NOT NULL,
    CONSTRAINT [PK_Alerta] PRIMARY KEY ([idAlerta]),
    CONSTRAINT [fk_Alerta_Usuario1] FOREIGN KEY ([estudiante_idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario]),
    CONSTRAINT [fk_Alerta_catalogo1] FOREIGN KEY ([catalogoTipoAlerta_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo]),
    CONSTRAINT [fk_Alerta_catalogo2] FOREIGN KEY ([catalogoEstadoAlerta_idcatalogo]) REFERENCES [dbo].[catalogo] ([idcatalogo]),
    CONSTRAINT [fk_Alerta_Usuario2] FOREIGN KEY ([encargadoCreacionAlerta_idUsuario1]) REFERENCES [dbo].[Usuario] ([idUsuario])
);
GO

CREATE TABLE [dbo].[Seguimiento] (
    [idSeguimiento] INT IDENTITY(1,1) NOT NULL,
    [asunto_seguimiento] NVARCHAR(45) NOT NULL,
    [descripcion_seguimiento] NVARCHAR(255) NOT NULL,
    [fecha_seguimiento] DATETIME2(0) NOT NULL,
    [encargadoSeguimiento_idUsuario] INT NOT NULL,
    [estudianteSeguimiento_idUsuario] INT NOT NULL,
    CONSTRAINT [PK_Seguimiento] PRIMARY KEY ([idSeguimiento]),
    CONSTRAINT [fk_Seguimiento_Usuario1] FOREIGN KEY ([encargadoSeguimiento_idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario]),
    CONSTRAINT [fk_Seguimiento_Usuario2] FOREIGN KEY ([estudianteSeguimiento_idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario])
);
GO

CREATE TABLE [dbo].[CentroEducativo] (
    [idCentroEducativo] INT IDENTITY(1,1) NOT NULL,
    [nombre_centroEducativo] NVARCHAR(90) NOT NULL,
    [fecha_registro_centroEducativo] DATETIME2(0) NOT NULL,
    [activo] BIT NOT NULL,
    [Direccion_idDireccion] INT NOT NULL,
    CONSTRAINT [PK_CentroEducativo] PRIMARY KEY ([idCentroEducativo]),
    CONSTRAINT [fk_CentroEducativo_Direccion1] FOREIGN KEY ([Direccion_idDireccion]) REFERENCES [dbo].[Direccion] ([idDireccion])
);
GO

CREATE TABLE [dbo].[UsuarioCentroEducativo] (
    [idUsuarioCentroEducativo] INT IDENTITY(1,1) NOT NULL,
    [estudianteActivo] BIT NOT NULL,
    [Usuario_idUsuario] INT NOT NULL,
    [CentroEducativo_idCentroEducativo] INT NOT NULL,
    CONSTRAINT [PK_UsuarioCentroEducativo] PRIMARY KEY ([idUsuarioCentroEducativo]),
    CONSTRAINT [fk_UsuarioCentroEducativo_Usuario1] FOREIGN KEY ([Usuario_idUsuario]) REFERENCES [dbo].[Usuario] ([idUsuario]),
    CONSTRAINT [fk_UsuarioCentroEducativo_CentroEducativo1] FOREIGN KEY ([CentroEducativo_idCentroEducativo]) REFERENCES [dbo].[CentroEducativo] ([idCentroEducativo])
);
GO

CREATE INDEX [fk_Canton_Provincia1_idx] ON [dbo].[Canton] ([Provincia_idProvincia]);
GO
CREATE INDEX [fk_Distito_Canton1_idx] ON [dbo].[Distito] ([Canton_idCanton]);
GO
CREATE INDEX [fk_catalogo_tipoCatalogo1_idx] ON [dbo].[catalogo] ([tipoCatalogo_idtipoCatalogo]);
GO
CREATE INDEX [fk_DireccionCliente_catalogo1_idx] ON [dbo].[Direccion] ([tipoDireccion_idcatalogo]);
GO
CREATE INDEX [fk_Direccion_Distito1_idx] ON [dbo].[Direccion] ([Distito_idDistito1]);
GO
CREATE INDEX [fk_Comunidad_Direccion1_idx] ON [dbo].[Comunidad] ([Direccion_comunidad_idDireccion]);
GO
CREATE INDEX [fk_Usuario_catalogo1_idx] ON [dbo].[Usuario] ([catalogoGeneroUsuario_idcatalogo]);
GO
CREATE INDEX [fk_Usuario_Comunidad1_idx] ON [dbo].[Usuario] ([Comunidad_idComunidad]);
GO
CREATE INDEX [fk_Usuario_catalogo2_idx] ON [dbo].[Usuario] ([catalogoTipoUsuario_idcatalogo]);
GO
CREATE INDEX [fk_Actividad_Comunidad1_idx] ON [dbo].[Actividad] ([Comunidad_idComunidad]);
GO
CREATE INDEX [fk_Actividad_catalogo1_idx] ON [dbo].[Actividad] ([catalogoEstadoActividad_idcatalogo]);
GO
CREATE INDEX [fk_Actividad_Direccion1_idx] ON [dbo].[Actividad] ([Direccion_idDireccion]);
GO
CREATE INDEX [fk_Participacion_Usuario1_idx] ON [dbo].[Participacion] ([Usuario_idUsuario]);
GO
CREATE INDEX [fk_Participacion_Actividad1_idx] ON [dbo].[Participacion] ([Actividad_idActividad]);
GO
CREATE INDEX [fk_Alerta_Usuario1_idx] ON [dbo].[Alerta] ([estudiante_idUsuario]);
GO
CREATE INDEX [fk_Alerta_catalogo1_idx] ON [dbo].[Alerta] ([catalogoTipoAlerta_idcatalogo]);
GO
CREATE INDEX [fk_Alerta_catalogo2_idx] ON [dbo].[Alerta] ([catalogoEstadoAlerta_idcatalogo]);
GO
CREATE INDEX [fk_Alerta_Usuario2_idx] ON [dbo].[Alerta] ([encargadoCreacionAlerta_idUsuario1]);
GO
CREATE INDEX [fk_Seguimiento_Usuario1_idx] ON [dbo].[Seguimiento] ([encargadoSeguimiento_idUsuario]);
GO
CREATE INDEX [fk_Seguimiento_Usuario2_idx] ON [dbo].[Seguimiento] ([estudianteSeguimiento_idUsuario]);
GO
CREATE INDEX [fk_CentroEducativo_Direccion1_idx] ON [dbo].[CentroEducativo] ([Direccion_idDireccion]);
GO
CREATE INDEX [fk_UsuarioCentroEducativo_Usuario1_idx] ON [dbo].[UsuarioCentroEducativo] ([Usuario_idUsuario]);
GO
CREATE INDEX [fk_UsuarioCentroEducativo_CentroEducativo1_idx] ON [dbo].[UsuarioCentroEducativo] ([CentroEducativo_idCentroEducativo]);
GO

-- Verificacion
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = N'dbo' AND TABLE_TYPE = N'BASE TABLE' ORDER BY TABLE_NAME;
GO
