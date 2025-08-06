using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sleepSystemAPI.Models;

public partial class SleepSystemContext : DbContext
{
    public SleepSystemContext()
    {
    }

    public SleepSystemContext(DbContextOptions<SleepSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Pregunta> Preguntas { get; set; }

    public virtual DbSet<Respuesta> Respuestas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
       

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.IdEvaluaciones).HasName("PK__Evaluaci__C7F31F8C1C8E228D");

            entity.Property(e => e.IdEvaluaciones).HasColumnName("idEvaluaciones");
            entity.Property(e => e.Componente1).HasColumnName("componente1");
            entity.Property(e => e.Componente2).HasColumnName("componente2");
            entity.Property(e => e.Componente3).HasColumnName("componente3");
            entity.Property(e => e.Componente4).HasColumnName("componente4");
            entity.Property(e => e.Componente5).HasColumnName("componente5");
            entity.Property(e => e.Componente6).HasColumnName("componente6");
            entity.Property(e => e.Componente7).HasColumnName("componente7");
            entity.Property(e => e.PuntajeTotal).HasColumnName("puntajeTotal");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Evaluacio__usuar__3F466844");
        });

        modelBuilder.Entity<Pregunta>(entity =>
        {
            entity.HasKey(e => e.IdPregunta).HasName("PK__Pregunta__623EEC4278E13F7A");

            entity.Property(e => e.IdPregunta).HasColumnName("idPregunta");
            entity.Property(e => e.ItemPsqi).HasColumnName("itemPsqi");
            entity.Property(e => e.Texto).HasColumnType("text");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Respuesta>(entity =>
        {
            entity.HasKey(e => e.IdRespuesta).HasName("PK__Respuest__8AB5BFC809B5818A");

            entity.Property(e => e.IdRespuesta).HasColumnName("idRespuesta");
            entity.Property(e => e.PreguntaId).HasColumnName("preguntaId");
            entity.Property(e => e.Respuesta1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Respuesta");
            entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");

            entity.HasOne(d => d.Pregunta).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.PreguntaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__pregu__3C69FB99");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Respuesta__usuar__3B75D760");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Usuarios__3717C982E75F4738");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.Genero)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Oficio)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
