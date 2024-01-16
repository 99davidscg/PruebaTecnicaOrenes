using Microsoft.EntityFrameworkCore;
using PaqueteriaApi.Entidades;


namespace PaqueteriaApi.Datos
{
    public class PaqueteriaDbContext : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<UbicacionHistorial> UbicacionesHistoriales { get; set; }

        public PaqueteriaDbContext(DbContextOptions<PaqueteriaDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehiculo>()
            .HasMany(v => v.lst_historial_ubicaciones)
            .WithOne()
            .HasForeignKey(uh => uh.id_vehiculo);
        }
    }
}
