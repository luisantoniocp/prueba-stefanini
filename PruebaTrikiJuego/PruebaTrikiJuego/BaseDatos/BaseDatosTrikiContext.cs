using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTrikiJuego.BaseDatos
{
    public partial class BaseDatosTrikiContext : DbContext
    {
        public BaseDatosTrikiContext()
        {
        }

        public BaseDatosTrikiContext(DbContextOptions<BaseDatosTrikiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Ganadores> Ganadores { get; set; }
        public virtual DbSet<Jugadores> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TKCRCIL\\DEVELOP; Trusted_Connection=False; MultipleActiveResultSets=true; database=BaseDatosTriki;user id=develop;password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora);

                entity.Property(e => e.CasillaSeleccionada)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroJugador)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroPartida).HasMaxLength(500);
            });

            modelBuilder.Entity<Ganadores>(entity =>
            {
                entity.HasKey(e => e.IdGanador);

                entity.Property(e => e.NumeroJugador)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Jugadores>(entity =>
            {
                entity.HasKey(e => e.IdJugador);

                entity.Property(e => e.IdJugador).HasColumnName("idJugador");

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });
        }
    }
}
