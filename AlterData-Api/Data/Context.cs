using AlterData_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace AlterData_Api.Data
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
           // this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Name=AlterDataDb");
            }
        }

        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Recurso> Recursos { get; set; }
        public virtual DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("funcionario");

                entity.Property(e => e.Funcionario_Id).HasColumnName("funcionario_id");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<Recurso>(entity =>
            {
                entity.ToTable("recurso");

                entity.Property(e => e.Recurso_Id).HasColumnName("recurso_id");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<Voto>(entity =>
            {
                entity.ToTable("voto");

                entity.HasKey(e => new { e.Recurso_Id, e.Funcionario_Id });


                entity.Property(e => e.Recurso_Id).HasColumnName("recurso_id");

                entity.Property(e => e.Funcionario_Id).HasColumnName("funcionario_id");

                entity.Property(e => e.Comentario)
                    .HasColumnName("comentario")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Data_Votacao)
                   .HasColumnName("data_votacao")
                   .IsUnicode(false);

                entity.HasOne(d => d.Funcionario)
                   .WithMany(p => p.Votos)
                   .HasForeignKey(d => d.Funcionario_Id)
                   .HasConstraintName("voto_funcionario_id_fkey");

                entity.HasOne(d => d.Recurso)
                  .WithMany(p => p.Votos)
                  .HasForeignKey(d => d.Recurso_Id)
                  .HasConstraintName("voto_recurso_id_fkey");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
