using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Estudiantes_repositorio.Models;

public partial class RegistroEstudiantesContext : DbContext
{
    public RegistroEstudiantesContext()
    {
    }

    public RegistroEstudiantesContext(DbContextOptions<RegistroEstudiantesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<MateriasProfesor> MateriasProfesors { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Profesor> Profesors { get; set; }

    public virtual DbSet<RegistroEstudiantesMateria> RegistroEstudiantesMaterias { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L8ESPM4;Database=RegistroEstudiantes;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Estudian__3214EC0702E7DC90");

            entity.ToTable("Estudiante");

            entity.HasIndex(e => e.Correo, "UQ__Estudian__60695A19D4B50C87").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Documento).HasMaxLength(100);
            entity.Property(e => e.EstudiantePassword).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<MateriasProfesor>(entity =>
        {
            entity.HasKey(e => e.MateriaProfesorId).HasName("PK__Materias__FFEE765C9548472A");

            entity.ToTable("MateriasProfesor");

            entity.Property(e => e.MateriaProfesorId).HasColumnName("MateriaProfesorID");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");
            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

            entity.HasOne(d => d.Materia).WithMany(p => p.MateriasProfesors)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MateriasP__Mater__403A8C7D");

            entity.HasOne(d => d.Profesor).WithMany(p => p.MateriasProfesors)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MateriasP__Profe__3F466844");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Materia__3214EC0739BA2CA1");

            entity.Property(e => e.Descripcion).HasMaxLength(300);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Profesor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profesor__3214EC07DF3FD845");

            entity.ToTable("Profesor");

            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<RegistroEstudiantesMateria>(entity =>
        {
            entity.HasKey(e => e.RegistroId).HasName("PK__Registro__B897313E9D533827");

            entity.Property(e => e.RegistroId).HasColumnName("RegistroID");
            entity.Property(e => e.EstudianteId).HasColumnName("EstudianteID");
            entity.Property(e => e.MateriaId).HasColumnName("MateriaID");
            entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");

            entity.HasOne(d => d.Estudiante).WithMany(p => p.RegistroEstudiantesMateria)
                .HasForeignKey(d => d.EstudianteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroE__Estud__4316F928");

            entity.HasOne(d => d.Materia).WithMany(p => p.RegistroEstudiantesMateria)
                .HasForeignKey(d => d.MateriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroE__Mater__440B1D61");

            entity.HasOne(d => d.Profesor).WithMany(p => p.RegistroEstudiantesMateria)
                .HasForeignKey(d => d.ProfesorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RegistroE__Profe__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
