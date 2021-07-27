using Microsoft.EntityFrameworkCore;
using Modelo.ControlPrestamo;
using System;

namespace Persistencia
{
    public class PrestamoContex : DbContext
    {
        public DbSet<Configuracion> configuracions { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<TipoCredito> tipoCreditos { get; set; }
        public DbSet<TablaAmortizacion> tablaAmortizacions { get; set; }
        public DbSet<TipoPago> tipoPagos { get; set; }
        public DbSet<Credito> creditos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Morosidad> morosidads { get; set; }
        // Constructor vacio
        public PrestamoContex() : base()
        {

        }

        // Constructor para pasar la conexión al padre
        public PrestamoContex(DbContextOptions<PrestamoContex> opciones)
            : base(opciones)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                switch (PrestamoConfig.PersistenciaDestino)
                {
                    case "SQLServerPrestamo":
                        optionsBuilder.UseSqlServer(PrestamoConfig.connectionString);
                        break;
                    case "PostgresPrestamo":
                        optionsBuilder.UseNpgsql(PrestamoConfig.connectionString);
                        break;
                    case "memoriaPrestamo":
                        optionsBuilder.UseInMemoryDatabase(PrestamoConfig.connectionString);
                        break;
                }
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion tipo de credito y credito
            modelBuilder.Entity<Credito>()
                .HasOne(mat => mat.TipoCredito)
                .WithMany(est => est.Creditos)
                .HasForeignKey(mat => mat.TipoCreditoId);
            //Relacion Tbla de amortizacion ycredito
            modelBuilder.Entity<Credito>()
                .HasOne(mat => mat.TablaAmortizacion)
                .WithMany(est => est.Creditos)
                .HasForeignKey(mat => mat.TablaAmortizacionID);
            //relacion TipoPago y Pago
            modelBuilder.Entity<Pago>()
               .HasOne(mat => mat.TipoPago)
               .WithMany(est => est.Pagos)
               .HasForeignKey(mat => mat.TipoPagoId);

            //relacion de Pago y credito
            modelBuilder.Entity<Pago>()
               .HasOne(mat => mat.Credito)
               .WithMany(est => est.Pagos)
               .HasForeignKey(mat => mat.CreditoId);

        }
    }
}
