using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CreditoCarteraAdmin_AbInBev.Models
{
    public partial class CartedaDBContext : DbContext
    {
        public CartedaDBContext()
        {
        }

        public CartedaDBContext(DbContextOptions<CartedaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarteraAnalytics> CarteraAnalytics { get; set; }
        public virtual DbSet<CreditoCliente> CreditoCliente { get; set; }
        public virtual DbSet<LlamadaNotificacion> LlamadaNotificacion { get; set; }
        public virtual DbSet<MensajeNotificacion> MensajeNotificacion { get; set; }
        public virtual DbSet<FrecuenciaNotificaciones> FrecuenciaNotificaciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:abinbev.database.windows.net,1433;Initial Catalog=CartedaDB;Persist Security Info=False;User ID=adminuser;Password=Pass123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraAnalytics>(entity =>
            {
                entity.Property(e => e.SmsEnviados).HasColumnName("SmsEnviados");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
