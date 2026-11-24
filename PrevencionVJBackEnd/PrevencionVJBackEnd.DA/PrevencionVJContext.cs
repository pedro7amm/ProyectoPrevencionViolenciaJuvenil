using Microsoft.EntityFrameworkCore;
using PrevencionVJBackEnd.Model;

namespace PrevencionVJBackEnd.DA
{
    public class PrevencionVJContext : DbContext
    {
        public PrevencionVJContext(DbContextOptions<PrevencionVJContext> options)
            : base(options)
        {
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Canton> Cantones { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        public DbSet<TipoCatalogo> TiposCatalogo { get; set; }
        public DbSet<Catalogo> Catalogos { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Comunidad> Comunidades { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Participacion> Participaciones { get; set; }
        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<CentroEducativo> CentrosEducativos { get; set; }
        public DbSet<UsuarioCentroEducativo> UsuariosCentrosEducativos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Canton>()
                .HasOne(c => c.Provincia)
                .WithMany(p => p.Cantones)
                .HasForeignKey(c => c.IdProvincia)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Distrito>()
                .HasOne(d => d.Canton)
                .WithMany(c => c.Distritos)
                .HasForeignKey(d => d.IdCanton)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Catalogo>()
                .HasOne(c => c.TipoCatalogo)
                .WithMany(t => t.Catalogos)
                .HasForeignKey(c => c.IdTipoCatalogo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.TipoDireccion)
                .WithMany(c => c.DireccionesTipo)
                .HasForeignKey(d => d.IdTipoDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Direccion>()
                .HasOne(d => d.Distrito)
                .WithMany(d => d.Direcciones)
                .HasForeignKey(d => d.IdDistrito)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comunidad>()
                .HasOne(c => c.Direccion)
                .WithMany(d => d.Comunidades)
                .HasForeignKey(c => c.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Genero)
                .WithMany(c => c.UsuariosGenero)
                .HasForeignKey(u => u.IdGenero)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Comunidad)
                .WithMany(c => c.Usuarios)
                .HasForeignKey(u => u.IdComunidad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.TipoUsuario)
                .WithMany(c => c.UsuariosTipo)
                .HasForeignKey(u => u.IdTipoUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Comunidad)
                .WithMany(c => c.Actividades)
                .HasForeignKey(a => a.IdComunidad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.EstadoActividad)
                .WithMany(c => c.ActividadesEstado)
                .HasForeignKey(a => a.IdEstadoActividad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Actividad>()
                .HasOne(a => a.Direccion)
                .WithMany(d => d.Actividades)
                .HasForeignKey(a => a.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.Usuario)
                .WithMany(u => u.Participaciones)
                .HasForeignKey(p => p.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participacion>()
                .HasOne(p => p.Actividad)
                .WithMany(a => a.Participaciones)
                .HasForeignKey(p => p.IdActividad)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Participacion>()
                .HasIndex(p => new { p.IdUsuario, p.IdActividad })
                .IsUnique();

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.Estudiante)
                .WithMany(u => u.AlertasComoEstudiante)
                .HasForeignKey(a => a.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.EncargadoCreacion)
                .WithMany(u => u.AlertasCreadas)
                .HasForeignKey(a => a.IdEncargadoCreacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.TipoAlerta)
                .WithMany(c => c.AlertasTipo)
                .HasForeignKey(a => a.IdTipoAlerta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Alerta>()
                .HasOne(a => a.EstadoAlerta)
                .WithMany(c => c.AlertasEstado)
                .HasForeignKey(a => a.IdEstadoAlerta)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Encargado)
                .WithMany(u => u.SeguimientosComoEncargado)
                .HasForeignKey(s => s.IdEncargado)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Estudiante)
                .WithMany(u => u.SeguimientosComoEstudiante)
                .HasForeignKey(s => s.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CentroEducativo>()
                .HasOne(c => c.Direccion)
                .WithMany(d => d.CentrosEducativos)
                .HasForeignKey(c => c.IdDireccion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioCentroEducativo>()
                .HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuariosCentrosEducativos)
                .HasForeignKey(uc => uc.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioCentroEducativo>()
                .HasOne(uc => uc.CentroEducativo)
                .WithMany(c => c.UsuariosCentrosEducativos)
                .HasForeignKey(uc => uc.IdCentroEducativo)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
