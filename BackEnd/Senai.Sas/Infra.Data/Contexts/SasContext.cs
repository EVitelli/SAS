using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Sas.Infra.Data.Domains
{
    public partial class SasContext : DbContext
    {
        public SasContext()
        {
        }

        public SasContext(DbContextOptions<SasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamentos> Agendamentos { get; set; }
        public virtual DbSet<AgendamentosParticipantes> AgendamentosParticipantes { get; set; }
        public virtual DbSet<Ambientes> Ambientes { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Participantes> Participantes { get; set; }
        public virtual DbSet<Permissoes> Permissoes { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SAS;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Agendamentos>(entity =>
            {
                entity.HasKey(e => e.AgendamentoId)
                    .HasName("PK__Agendame__AE013133A6E2A899");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InicioReserva).HasColumnType("datetime");

                entity.Property(e => e.Observacao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N/C')");

                entity.Property(e => e.StatusAgenda)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Agendado')");

                entity.Property(e => e.TerminoReserva).HasColumnType("datetime");

                entity.HasOne(d => d.Ambiente)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.AmbienteId)
                    .HasConstraintName("FK__Agendamen__Ambie__4F7CD00D");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.CategoriaId)
                    .HasConstraintName("FK__Agendamen__Categ__4D94879B");

                entity.HasOne(d => d.CriadorNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.Criador)
                    .HasConstraintName("FK__Agendamen__Criad__4E88ABD4");
            });

            modelBuilder.Entity<AgendamentosParticipantes>(entity =>
            {
                entity.HasKey(e => e.AgendaParticipanteId)
                    .HasName("PK__Agendame__979BD07782C8CBEF");

                entity.Property(e => e.StatusParticipante)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agendamento)
                    .WithMany(p => p.AgendamentosParticipantes)
                    .HasForeignKey(d => d.AgendamentoId)
                    .HasConstraintName("FK__Agendamen__Agend__52593CB8");

                entity.HasOne(d => d.Participante)
                    .WithMany(p => p.AgendamentosParticipantes)
                    .HasForeignKey(d => d.ParticipanteId)
                    .HasConstraintName("FK__Agendamen__Parti__534D60F1");
            });

            modelBuilder.Entity<Ambientes>(entity =>
            {
                entity.HasKey(e => e.AmbienteId)
                    .HasName("PK__Ambiente__49279DBED3E42A15");

                entity.Property(e => e.DescricaoEquipamentos)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DescricaoSoftwares)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('N/C')");

                entity.Property(e => e.StatusAmbiente)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Ativo')");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.CategoriaId)
                    .HasName("PK__Categori__F353C1E526EA3A30");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Categori__7D8FE3B289153E8E")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Participantes>(entity =>
            {
                entity.HasKey(e => e.ParticipanteId)
                    .HasName("PK__Particip__E6DEAC5FC70FAC19");

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Particip__C1F8973169AA8BAF")
                    .IsUnique();

                entity.HasIndex(e => e.Rg)
                    .HasName("UQ__Particip__321537C893877F93")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissoes>(entity =>
            {
                entity.HasKey(e => e.PermissaoId)
                    .HasName("PK__Permisso__9E2A6CEA26A8F6A4");

                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__Permisso__7D8FE3B2FAE6F262")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK__Usuarios__2B3DE7B8943800D8");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D10534D9CD946A")
                    .IsUnique();

                entity.HasIndex(e => e.Nif)
                    .HasName("UQ__Usuarios__C7DEC3309B8CE5E0")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nif)
                    .IsRequired()
                    .HasColumnName("NIF")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PermissaoId)
                    .HasConstraintName("FK__Usuarios__Permis__44FF419A");
            });
        }
    }
}
