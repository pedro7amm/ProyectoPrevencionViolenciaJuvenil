-- Datos de prueba para el Caso 1: Solucion de Prevencion de violencia juvenil
-- Requiere ejecutar primero PrevencionJuvenil_SQLServer_BD_Creation.sql
-- Todos los nombres, cedulas y situaciones de este archivo son ficticios.

IF DB_ID(N'PrevencionJuvenil') IS NULL
    THROW 50000, N'La base de datos PrevencionJuvenil no existe. Ejecute primero el script de creacion.', 1;
GO

USE [PrevencionJuvenil];
GO

SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- Evita duplicar el conjunto completo de datos si el script se ejecuta nuevamente.
    IF EXISTS (
        SELECT 1
        FROM [dbo].[Usuario]
        WHERE [cedula_usuario] = N'FICT-C1-0001'
    )
        THROW 50001, N'Los datos de prueba del Caso 1 ya fueron insertados.', 1;

    ---------------------------------------------------------------------------
    -- 1. Provincias
    ---------------------------------------------------------------------------
    DECLARE @ProvinciaSanJose INT;
    DECLARE @ProvinciaAlajuela INT;
    DECLARE @ProvinciaHeredia INT;

    INSERT INTO [dbo].[Provincia] ([descripcion_provincia], [activo])
    VALUES (N'San Jose', 1);
    SET @ProvinciaSanJose = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Provincia] ([descripcion_provincia], [activo])
    VALUES (N'Alajuela', 1);
    SET @ProvinciaAlajuela = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Provincia] ([descripcion_provincia], [activo])
    VALUES (N'Heredia', 1);
    SET @ProvinciaHeredia = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 2. Cantones
    ---------------------------------------------------------------------------
    DECLARE @CantonDesamparados INT;
    DECLARE @CantonAlajuelita INT;
    DECLARE @CantonSanJose INT;
    DECLARE @CantonAlajuela INT;
    DECLARE @CantonHeredia INT;

    INSERT INTO [dbo].[Canton]
        ([descripcion_canton], [activo], [Provincia_idProvincia])
    VALUES (N'Desamparados', 1, @ProvinciaSanJose);
    SET @CantonDesamparados = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Canton]
        ([descripcion_canton], [activo], [Provincia_idProvincia])
    VALUES (N'Alajuelita', 1, @ProvinciaSanJose);
    SET @CantonAlajuelita = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Canton]
        ([descripcion_canton], [activo], [Provincia_idProvincia])
    VALUES (N'San Jose', 1, @ProvinciaSanJose);
    SET @CantonSanJose = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Canton]
        ([descripcion_canton], [activo], [Provincia_idProvincia])
    VALUES (N'Alajuela', 1, @ProvinciaAlajuela);
    SET @CantonAlajuela = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Canton]
        ([descripcion_canton], [activo], [Provincia_idProvincia])
    VALUES (N'Heredia', 1, @ProvinciaHeredia);
    SET @CantonHeredia = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 3. Distritos
    ---------------------------------------------------------------------------
    DECLARE @DistritoSanMiguel INT;
    DECLARE @DistritoSanFelipe INT;
    DECLARE @DistritoHatillo INT;
    DECLARE @DistritoSanRafaelAlajuela INT;
    DECLARE @DistritoMercedes INT;

    INSERT INTO [dbo].[Distrito]
        ([descripcion_distrito], [activo], [codigo_postal], [Canton_idCanton])
    VALUES (N'San Miguel', 1, N'10302', @CantonDesamparados);
    SET @DistritoSanMiguel = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Distrito]
        ([descripcion_distrito], [activo], [codigo_postal], [Canton_idCanton])
    VALUES (N'San Felipe', 1, N'11005', @CantonAlajuelita);
    SET @DistritoSanFelipe = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Distrito]
        ([descripcion_distrito], [activo], [codigo_postal], [Canton_idCanton])
    VALUES (N'Hatillo', 1, N'10110', @CantonSanJose);
    SET @DistritoHatillo = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Distrito]
        ([descripcion_distrito], [activo], [codigo_postal], [Canton_idCanton])
    VALUES (N'San Rafael', 1, N'20108', @CantonAlajuela);
    SET @DistritoSanRafaelAlajuela = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Distrito]
        ([descripcion_distrito], [activo], [codigo_postal], [Canton_idCanton])
    VALUES (N'Mercedes', 1, N'40102', @CantonHeredia);
    SET @DistritoMercedes = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 4. Tipos de catalogo
    ---------------------------------------------------------------------------
    DECLARE @TipoGenero INT;
    DECLARE @TipoUsuario INT;
    DECLARE @TipoDireccion INT;
    DECLARE @TipoEstadoActividad INT;
    DECLARE @TipoAlerta INT;
    DECLARE @TipoEstadoAlerta INT;

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Genero', 1);
    SET @TipoGenero = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Tipo de usuario', 1);
    SET @TipoUsuario = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Tipo de direccion', 1);
    SET @TipoDireccion = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Estado de actividad', 1);
    SET @TipoEstadoActividad = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Tipo de alerta', 1);
    SET @TipoAlerta = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[tipoCatalogo] ([nombre_catalogo], [activo])
    VALUES (N'Estado de alerta', 1);
    SET @TipoEstadoAlerta = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 5. Valores de catalogo
    ---------------------------------------------------------------------------
    DECLARE @GeneroFemenino INT;
    DECLARE @GeneroMasculino INT;
    DECLARE @GeneroNoBinario INT;
    DECLARE @UsuarioEstudiante INT;
    DECLARE @UsuarioOrientador INT;
    DECLARE @UsuarioAdministrador INT;
    DECLARE @DireccionResidencial INT;
    DECLARE @DireccionCentroEducativo INT;
    DECLARE @DireccionComunitaria INT;
    DECLARE @ActividadPlanificada INT;
    DECLARE @ActividadEnCurso INT;
    DECLARE @ActividadFinalizada INT;
    DECLARE @ActividadNoApta INT;
    DECLARE @AlertaAusentismo INT;
    DECLARE @AlertaViolencia INT;
    DECLARE @AlertaConsumo INT;
    DECLARE @AlertaDesercion INT;
    DECLARE @AlertaNueva INT;
    DECLARE @AlertaEnSeguimiento INT;
    DECLARE @AlertaCerrada INT;

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Femenino', 1, @TipoGenero);
    SET @GeneroFemenino = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Masculino', 1, @TipoGenero);
    SET @GeneroMasculino = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'No binario', 1, @TipoGenero);
    SET @GeneroNoBinario = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Estudiante', 1, @TipoUsuario);
    SET @UsuarioEstudiante = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Orientador o facilitador', 1, @TipoUsuario);
    SET @UsuarioOrientador = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Administrador', 1, @TipoUsuario);
    SET @UsuarioAdministrador = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Residencial', 1, @TipoDireccion);
    SET @DireccionResidencial = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Centro educativo', 1, @TipoDireccion);
    SET @DireccionCentroEducativo = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Comunitaria', 1, @TipoDireccion);
    SET @DireccionComunitaria = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Planificada', 1, @TipoEstadoActividad);
    SET @ActividadPlanificada = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'En curso', 1, @TipoEstadoActividad);
    SET @ActividadEnCurso = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Finalizada', 1, @TipoEstadoActividad);
    SET @ActividadFinalizada = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'No apta', 1, @TipoEstadoActividad);
    SET @ActividadNoApta = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Ausentismo recurrente', 1, @TipoAlerta);
    SET @AlertaAusentismo = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Violencia o conflicto', 1, @TipoAlerta);
    SET @AlertaViolencia = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Riesgo de consumo de sustancias', 1, @TipoAlerta);
    SET @AlertaConsumo = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Riesgo de desercion escolar', 1, @TipoAlerta);
    SET @AlertaDesercion = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Nueva', 1, @TipoEstadoAlerta);
    SET @AlertaNueva = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'En seguimiento', 1, @TipoEstadoAlerta);
    SET @AlertaEnSeguimiento = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[catalogo]
        ([descripcion_catalogo], [activo], [tipoCatalogo_idtipoCatalogo])
    VALUES (N'Cerrada', 1, @TipoEstadoAlerta);
    SET @AlertaCerrada = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 6. Direcciones: cinco comunitarias y tres de centros educativos
    ---------------------------------------------------------------------------
    DECLARE @DirComunidad1 INT;
    DECLARE @DirComunidad2 INT;
    DECLARE @DirComunidad3 INT;
    DECLARE @DirComunidad4 INT;
    DECLARE @DirComunidad5 INT;
    DECLARE @DirCentro1 INT;
    DECLARE @DirCentro2 INT;
    DECLARE @DirCentro3 INT;

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Casa comunal, 100 metros al norte del parque', 1, @DireccionComunitaria, @DistritoSanMiguel);
    SET @DirComunidad1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Salon multiuso frente a la plaza de deportes', 1, @DireccionComunitaria, @DistritoSanFelipe);
    SET @DirComunidad2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Centro civico, costado oeste de la biblioteca', 1, @DireccionComunitaria, @DistritoHatillo);
    SET @DirComunidad3 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Asociacion de desarrollo, segunda planta', 1, @DireccionComunitaria, @DistritoSanRafaelAlajuela);
    SET @DirComunidad4 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Centro cultural, 50 metros al sur de la iglesia', 1, @DireccionComunitaria, @DistritoMercedes);
    SET @DirComunidad5 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Costado norte del parque de San Miguel', 1, @DireccionCentroEducativo, @DistritoSanMiguel);
    SET @DirCentro1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'200 metros al este de la clinica de Hatillo', 1, @DireccionCentroEducativo, @DistritoHatillo);
    SET @DirCentro2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Direccion]
        ([otras_sennas], [activo], [tipoDireccion_idcatalogo], [Distrito_idDistrito1])
    VALUES (N'Frente a la plaza principal de Mercedes', 1, @DireccionCentroEducativo, @DistritoMercedes);
    SET @DirCentro3 = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 7. Cinco comunidades solicitadas en el Caso 1
    ---------------------------------------------------------------------------
    DECLARE @Comunidad1 INT;
    DECLARE @Comunidad2 INT;
    DECLARE @Comunidad3 INT;
    DECLARE @Comunidad4 INT;
    DECLARE @Comunidad5 INT;

    INSERT INTO [dbo].[Comunidad]
        ([nombre_comunidad], [descripcion_comunidad], [Direccion_comunidad_idDireccion])
    VALUES (N'Red Joven San Miguel', N'Prevencion y convivencia juvenil', @DirComunidad1);
    SET @Comunidad1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Comunidad]
        ([nombre_comunidad], [descripcion_comunidad], [Direccion_comunidad_idDireccion])
    VALUES (N'Jovenes de San Felipe', N'Deporte y acompañamiento social', @DirComunidad2);
    SET @Comunidad2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Comunidad]
        ([nombre_comunidad], [descripcion_comunidad], [Direccion_comunidad_idDireccion])
    VALUES (N'Construyendo Futuro Hatillo', N'Apoyo escolar y familiar', @DirComunidad3);
    SET @Comunidad3 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Comunidad]
        ([nombre_comunidad], [descripcion_comunidad], [Direccion_comunidad_idDireccion])
    VALUES (N'Alajuela Convive', N'Arte comunitario y mediacion', @DirComunidad4);
    SET @Comunidad4 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Comunidad]
        ([nombre_comunidad], [descripcion_comunidad], [Direccion_comunidad_idDireccion])
    VALUES (N'Mercedes en Accion', N'Prevencion de riesgos juveniles', @DirComunidad5);
    SET @Comunidad5 = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 8. Usuarios ficticios: estudiantes, orientadores y administrador
    ---------------------------------------------------------------------------
    DECLARE @Ana INT;
    DECLARE @Luis INT;
    DECLARE @Camila INT;
    DECLARE @Diego INT;
    DECLARE @Sofia INT;
    DECLARE @Andres INT;
    DECLARE @Marta INT;
    DECLARE @Carlos INT;
    DECLARE @Elena INT;

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0001', N'Ana', N'Rivera', N'Soto', '2010-04-12', '2026-09-01T08:00:00',
         1, @GeneroFemenino, @Comunidad1, @UsuarioEstudiante);
    SET @Ana = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0002', N'Luis', N'Mora', N'Vega', '2009-08-21', '2026-09-02T09:00:00',
         1, @GeneroMasculino, @Comunidad2, @UsuarioEstudiante);
    SET @Luis = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0003', N'Camila', N'Rojas', N'Leon', '2011-01-30', '2026-09-03T10:00:00',
         1, @GeneroFemenino, @Comunidad3, @UsuarioEstudiante);
    SET @Camila = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0004', N'Diego', N'Campos', N'Ruiz', '2008-11-15', '2026-09-04T11:00:00',
         1, @GeneroMasculino, @Comunidad4, @UsuarioEstudiante);
    SET @Diego = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0005', N'Sofia', N'Jimenez', N'Castro', '2010-06-05', '2026-09-05T08:30:00',
         1, @GeneroNoBinario, @Comunidad5, @UsuarioEstudiante);
    SET @Sofia = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0006', N'Andres', N'Solano', N'Mendez', '2009-02-18', '2026-08-15T08:00:00',
         0, @GeneroMasculino, @Comunidad1, @UsuarioEstudiante);
    SET @Andres = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0101', N'Marta', N'Quesada', N'Lopez', '1987-03-14', '2026-08-20T07:30:00',
         1, @GeneroFemenino, @Comunidad1, @UsuarioOrientador);
    SET @Marta = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0102', N'Carlos', N'Velasquez', N'Mora', '1984-07-09', '2026-08-21T07:30:00',
         1, @GeneroMasculino, @Comunidad4, @UsuarioOrientador);
    SET @Carlos = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Usuario]
        ([cedula_usuario], [nombre_usuario], [apellido1_usuario], [apellido2_usuario],
         [fecha_nacimiento_usuario], [fecha_registro_usuario], [activo],
         [catalogoGeneroUsuario_idcatalogo], [Comunidad_idComunidad],
         [catalogoTipoUsuario_idcatalogo])
    VALUES
        (N'FICT-C1-0201', N'Elena', N'Chaves', N'Rojas', '1982-12-02', '2026-08-01T08:00:00',
         1, @GeneroFemenino, @Comunidad3, @UsuarioAdministrador);
    SET @Elena = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 9. Seis actividades en cinco comunidades
    ---------------------------------------------------------------------------
    DECLARE @Actividad1 INT;
    DECLARE @Actividad2 INT;
    DECLARE @Actividad3 INT;
    DECLARE @Actividad4 INT;
    DECLARE @Actividad5 INT;
    DECLARE @Actividad6 INT;

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Resolucion pacifica', N'Taller de mediacion y resolucion de conflictos juveniles',
         '2026-09-10T14:00:00', '2026-09-10T17:00:00', 25,
         @Comunidad1, @ActividadFinalizada, @DirComunidad1);
    SET @Actividad1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Liga deportiva', N'Entrenamientos deportivos y habilidades para la convivencia',
         '2026-11-01T09:00:00', '2026-12-15T11:00:00', 30,
         @Comunidad2, @ActividadEnCurso, @DirComunidad2);
    SET @Actividad2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Mentoria escolar', N'Acompañamiento para prevenir la desercion y reforzar estudios',
         '2026-12-01T15:00:00', '2026-12-20T17:00:00', 20,
         @Comunidad3, @ActividadPlanificada, @DirComunidad3);
    SET @Actividad3 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Arte urbano', N'Expresion artistica comunitaria con acompañamiento profesional',
         '2026-10-05T13:00:00', '2026-10-20T16:00:00', 18,
         @Comunidad4, @ActividadFinalizada, @DirComunidad4);
    SET @Actividad4 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Prevencion de consumo', N'Charlas y dinamicas sobre factores protectores y autocuidado',
         '2026-12-05T09:00:00', '2026-12-05T13:00:00', 40,
         @Comunidad5, @ActividadPlanificada, @DirComunidad5);
    SET @Actividad5 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Actividad]
        ([nombre_actividad], [descripcion_actividad], [fecha_inicio_actividad],
         [fecha_fin_actividad], [cupo_maximo_actividad], [Comunidad_idComunidad],
         [catalogoEstadoActividad_idcatalogo], [Direccion_idDireccion])
    VALUES
        (N'Encuentro no supervisado', N'Propuesta rechazada por horario nocturno y falta de supervision adulta',
         '2026-12-12T22:00:00', '2026-12-13T02:00:00', 15,
         @Comunidad4, @ActividadNoApta, @DirComunidad4);
    SET @Actividad6 = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 10. Participaciones: historial personal de actividades
    ---------------------------------------------------------------------------
    INSERT INTO [dbo].[Participacion]
        ([fecha_inscripcion], [asistio], [Usuario_idUsuario], [Actividad_idActividad])
    VALUES
        ('2026-09-01T10:00:00', 1, @Ana, @Actividad1),
        ('2026-10-25T10:00:00', 1, @Ana, @Actividad2),
        ('2026-09-02T11:00:00', 1, @Luis, @Actividad1),
        ('2026-11-10T09:00:00', 0, @Luis, @Actividad3),
        ('2026-10-20T14:00:00', 1, @Camila, @Actividad2),
        ('2026-09-25T12:00:00', 1, @Camila, @Actividad4),
        ('2026-09-26T12:00:00', 0, @Diego, @Actividad4),
        ('2026-11-15T08:00:00', 0, @Sofia, @Actividad3),
        ('2026-11-16T08:00:00', 0, @Sofia, @Actividad5),
        ('2026-08-20T08:00:00', 0, @Andres, @Actividad1);

    ---------------------------------------------------------------------------
    -- 11. Alertas tempranas para distintos patrones de riesgo
    ---------------------------------------------------------------------------
    DECLARE @Alerta1 INT;
    DECLARE @Alerta2 INT;
    DECLARE @Alerta3 INT;
    DECLARE @Alerta4 INT;

    INSERT INTO [dbo].[Alerta]
        ([asunto_alerta], [descripcion_alerta], [fecha_alerta],
         [estudiante_idUsuario], [encargadoCreacionAlerta_idUsuario1],
         [catalogoTipoAlerta_idcatalogo], [catalogoEstadoAlerta_idcatalogo])
    VALUES
        (N'Ausencias consecutivas', N'Tres ausencias escolares y una actividad comunitaria perdida',
         '2026-11-17T08:00:00', @Luis, @Marta, @AlertaAusentismo, @AlertaNueva);
    SET @Alerta1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Alerta]
        ([asunto_alerta], [descripcion_alerta], [fecha_alerta],
         [estudiante_idUsuario], [encargadoCreacionAlerta_idUsuario1],
         [catalogoTipoAlerta_idcatalogo], [catalogoEstadoAlerta_idcatalogo])
    VALUES
        (N'Conflictos reiterados', N'Dos incidentes de confrontacion durante actividades comunitarias',
         '2026-10-22T13:30:00', @Diego, @Carlos, @AlertaViolencia, @AlertaEnSeguimiento);
    SET @Alerta2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Alerta]
        ([asunto_alerta], [descripcion_alerta], [fecha_alerta],
         [estudiante_idUsuario], [encargadoCreacionAlerta_idUsuario1],
         [catalogoTipoAlerta_idcatalogo], [catalogoEstadoAlerta_idcatalogo])
    VALUES
        (N'Indicadores de consumo', N'Cambios conductuales y ausencias reportados por familia y centro educativo',
         '2026-11-12T10:15:00', @Ana, @Marta, @AlertaConsumo, @AlertaEnSeguimiento);
    SET @Alerta3 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[Alerta]
        ([asunto_alerta], [descripcion_alerta], [fecha_alerta],
         [estudiante_idUsuario], [encargadoCreacionAlerta_idUsuario1],
         [catalogoTipoAlerta_idcatalogo], [catalogoEstadoAlerta_idcatalogo])
    VALUES
        (N'Riesgo de desercion', N'Bajo rendimiento y dos actividades de apoyo sin asistencia',
         '2026-11-18T09:20:00', @Sofia, @Elena, @AlertaDesercion, @AlertaNueva);
    SET @Alerta4 = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 12. Seguimiento individual
    ---------------------------------------------------------------------------
    INSERT INTO [dbo].[Seguimiento]
        ([asunto_seguimiento], [descripcion_seguimiento], [fecha_seguimiento],
         [encargadoSeguimiento_idUsuario], [estudianteSeguimiento_idUsuario])
    VALUES
        (N'Plan de asistencia', N'Se acuerda calendario semanal y contacto con la familia.',
         '2026-11-18T14:00:00', @Marta, @Luis),
        (N'Mediacion inicial', N'Sesion individual para identificar detonantes de los conflictos.',
         '2026-10-23T15:00:00', @Carlos, @Diego),
        (N'Referencia preventiva', N'Se coordina valoracion con orientacion del centro educativo.',
         '2026-11-13T11:00:00', @Marta, @Ana),
        (N'Refuerzo academico', N'Se incorpora al programa de mentoria y se informa a la familia.',
         '2026-11-19T13:00:00', @Elena, @Sofia),
        (N'Revision mensual', N'Se revisan asistencia, participacion comunitaria y progreso escolar.',
         '2026-11-24T10:00:00', @Marta, @Luis);

    ---------------------------------------------------------------------------
    -- 13. Centros educativos
    ---------------------------------------------------------------------------
    DECLARE @Centro1 INT;
    DECLARE @Centro2 INT;
    DECLARE @Centro3 INT;

    INSERT INTO [dbo].[CentroEducativo]
        ([nombre_centroEducativo], [fecha_registro_centroEducativo], [activo],
         [Direccion_idDireccion])
    VALUES
        (N'Colegio Comunitario San Miguel', '2026-08-01T08:00:00', 1, @DirCentro1);
    SET @Centro1 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[CentroEducativo]
        ([nombre_centroEducativo], [fecha_registro_centroEducativo], [activo],
         [Direccion_idDireccion])
    VALUES
        (N'Liceo de Hatillo', '2026-08-02T08:00:00', 1, @DirCentro2);
    SET @Centro2 = CONVERT(INT, SCOPE_IDENTITY());

    INSERT INTO [dbo].[CentroEducativo]
        ([nombre_centroEducativo], [fecha_registro_centroEducativo], [activo],
         [Direccion_idDireccion])
    VALUES
        (N'Colegio Tecnico de Mercedes', '2026-08-03T08:00:00', 1, @DirCentro3);
    SET @Centro3 = CONVERT(INT, SCOPE_IDENTITY());

    ---------------------------------------------------------------------------
    -- 14. Integracion de estudiantes con centros educativos
    ---------------------------------------------------------------------------
    INSERT INTO [dbo].[UsuarioCentroEducativo]
        ([estudianteActivo], [Usuario_idUsuario], [CentroEducativo_idCentroEducativo])
    VALUES
        (1, @Ana, @Centro1),
        (1, @Luis, @Centro1),
        (1, @Camila, @Centro2),
        (1, @Diego, @Centro2),
        (1, @Sofia, @Centro3),
        (0, @Andres, @Centro1);

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
GO

-------------------------------------------------------------------------------
-- Consultas de demostracion para los entregables del Caso 1
-------------------------------------------------------------------------------

-- A. Registro de actividades comunitarias: al menos cinco actividades
--    distribuidas en al menos cinco comunidades.
SELECT
    a.[idActividad],
    a.[nombre_actividad],
    c.[nombre_comunidad],
    ec.[descripcion_catalogo] AS [estado_actividad],
    a.[fecha_inicio_actividad],
    a.[fecha_fin_actividad],
    a.[cupo_maximo_actividad]
FROM [dbo].[Actividad] a
INNER JOIN [dbo].[Comunidad] c
    ON c.[idComunidad] = a.[Comunidad_idComunidad]
INNER JOIN [dbo].[catalogo] ec
    ON ec.[idcatalogo] = a.[catalogoEstadoActividad_idcatalogo]
ORDER BY c.[nombre_comunidad], a.[fecha_inicio_actividad];

-- B. Seguimiento individual e historial personal de actividades.
SELECT
    u.[cedula_usuario],
    CONCAT(u.[nombre_usuario], N' ', u.[apellido1_usuario]) AS [estudiante],
    a.[nombre_actividad],
    p.[fecha_inscripcion],
    p.[asistio],
    s.[asunto_seguimiento],
    s.[fecha_seguimiento]
FROM [dbo].[Usuario] u
LEFT JOIN [dbo].[Participacion] p
    ON p.[Usuario_idUsuario] = u.[idUsuario]
LEFT JOIN [dbo].[Actividad] a
    ON a.[idActividad] = p.[Actividad_idActividad]
LEFT JOIN [dbo].[Seguimiento] s
    ON s.[estudianteSeguimiento_idUsuario] = u.[idUsuario]
WHERE u.[cedula_usuario] LIKE N'FICT-C1-%'
ORDER BY u.[cedula_usuario], p.[fecha_inscripcion], s.[fecha_seguimiento];

-- C. Alertas tempranas basadas en distintos patrones de riesgo.
SELECT
    al.[idAlerta],
    CONCAT(u.[nombre_usuario], N' ', u.[apellido1_usuario]) AS [estudiante],
    ta.[descripcion_catalogo] AS [tipo_alerta],
    ea.[descripcion_catalogo] AS [estado_alerta],
    al.[asunto_alerta],
    al.[descripcion_alerta],
    al.[fecha_alerta]
FROM [dbo].[Alerta] al
INNER JOIN [dbo].[Usuario] u
    ON u.[idUsuario] = al.[estudiante_idUsuario]
INNER JOIN [dbo].[catalogo] ta
    ON ta.[idcatalogo] = al.[catalogoTipoAlerta_idcatalogo]
INNER JOIN [dbo].[catalogo] ea
    ON ea.[idcatalogo] = al.[catalogoEstadoAlerta_idcatalogo]
ORDER BY al.[fecha_alerta] DESC;

-- D. Identificacion de actividades calificadas como no aptas.
SELECT
    a.[idActividad],
    a.[nombre_actividad],
    a.[descripcion_actividad],
    c.[nombre_comunidad],
    e.[descripcion_catalogo] AS [estado]
FROM [dbo].[Actividad] a
INNER JOIN [dbo].[Comunidad] c
    ON c.[idComunidad] = a.[Comunidad_idComunidad]
INNER JOIN [dbo].[catalogo] e
    ON e.[idcatalogo] = a.[catalogoEstadoActividad_idcatalogo]
WHERE e.[descripcion_catalogo] = N'No apta';

-- E. Integracion con centros educativos.
SELECT
    ce.[nombre_centroEducativo],
    CONCAT(u.[nombre_usuario], N' ', u.[apellido1_usuario], N' ', u.[apellido2_usuario])
        AS [estudiante],
    uce.[estudianteActivo],
    co.[nombre_comunidad]
FROM [dbo].[UsuarioCentroEducativo] uce
INNER JOIN [dbo].[Usuario] u
    ON u.[idUsuario] = uce.[Usuario_idUsuario]
INNER JOIN [dbo].[CentroEducativo] ce
    ON ce.[idCentroEducativo] = uce.[CentroEducativo_idCentroEducativo]
INNER JOIN [dbo].[Comunidad] co
    ON co.[idComunidad] = u.[Comunidad_idComunidad]
ORDER BY ce.[nombre_centroEducativo], [estudiante];

-- F. Verificacion de cantidad de datos por tabla.
SELECT N'Provincia' AS [tabla], COUNT(*) AS [cantidad] FROM [dbo].[Provincia]
UNION ALL SELECT N'Canton', COUNT(*) FROM [dbo].[Canton]
UNION ALL SELECT N'Distrito', COUNT(*) FROM [dbo].[Distrito]
UNION ALL SELECT N'tipoCatalogo', COUNT(*) FROM [dbo].[tipoCatalogo]
UNION ALL SELECT N'catalogo', COUNT(*) FROM [dbo].[catalogo]
UNION ALL SELECT N'Direccion', COUNT(*) FROM [dbo].[Direccion]
UNION ALL SELECT N'Comunidad', COUNT(*) FROM [dbo].[Comunidad]
UNION ALL SELECT N'Usuario', COUNT(*) FROM [dbo].[Usuario]
UNION ALL SELECT N'Actividad', COUNT(*) FROM [dbo].[Actividad]
UNION ALL SELECT N'Participacion', COUNT(*) FROM [dbo].[Participacion]
UNION ALL SELECT N'Alerta', COUNT(*) FROM [dbo].[Alerta]
UNION ALL SELECT N'Seguimiento', COUNT(*) FROM [dbo].[Seguimiento]
UNION ALL SELECT N'CentroEducativo', COUNT(*) FROM [dbo].[CentroEducativo]
UNION ALL SELECT N'UsuarioCentroEducativo', COUNT(*) FROM [dbo].[UsuarioCentroEducativo]
ORDER BY [tabla];
GO
