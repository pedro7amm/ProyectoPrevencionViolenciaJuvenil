using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.BL;
using PrevencionVJBackEnd.DA;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// Servicios del contenedor
// ==========================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ==========================
// Entity Framework SQL Server
// ==========================
builder.Services.AddDbContext<PrevencionVJContext>(options =>
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("PrevencionJuvenilConnection")));

// ==========================
// Inyección de dependencias
// ==========================
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddScoped<IAdministradorProvincias, AdministradorProvincias>();

builder.Services.AddScoped<ICantonRepository, CantonRepository>();
builder.Services.AddScoped<IAdministradorCantones, AdministradorCantones>();

builder.Services.AddScoped<IDistritoRepository, DistritoRepository>();
builder.Services.AddScoped<IAdministradorDistritos, AdministradorDistritos>();

builder.Services.AddScoped<ITipoCatalogoRepository, TipoCatalogoRepository>();
builder.Services.AddScoped<IAdministradorTiposCatalogo, AdministradorTiposCatalogo>();

builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();
builder.Services.AddScoped<IAdministradorCatalogos, AdministradorCatalogos>();

builder.Services.AddScoped<IDireccionRepository, DireccionRepository>();
builder.Services.AddScoped<IAdministradorDirecciones, AdministradorDirecciones>();

builder.Services.AddScoped<IComunidadRepository, ComunidadRepository>();
builder.Services.AddScoped<IAdministradorComunidades, AdministradorComunidades>();

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAdministradorUsuarios, AdministradorUsuarios>();

builder.Services.AddScoped<IActividadRepository, ActividadRepository>();
builder.Services.AddScoped<IAdministradorActividades, AdministradorActividades>();

builder.Services.AddScoped<IParticipacionRepository, ParticipacionRepository>();
builder.Services.AddScoped<IAdministradorParticipaciones, AdministradorParticipaciones>();

builder.Services.AddScoped<IAlertaRepository, AlertaRepository>();
builder.Services.AddScoped<IAdministradorAlertas, AdministradorAlertas>();

builder.Services.AddScoped<ISeguimientoRepository, SeguimientoRepository>();
builder.Services.AddScoped<IAdministradorSeguimientos, AdministradorSeguimientos>();

builder.Services.AddScoped<ICentroEducativoRepository, CentroEducativoRepository>();
builder.Services.AddScoped<IAdministradorCentrosEducativos, AdministradorCentrosEducativos>();

builder.Services.AddScoped<IUsuarioCentroEducativoRepository, UsuarioCentroEducativoRepository>();
builder.Services.AddScoped<IAdministradorUsuariosCentrosEducativos,
    AdministradorUsuariosCentrosEducativos>();

// ==========================
// CORS
// ==========================
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// ==========================
// Middleware
// ==========================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
