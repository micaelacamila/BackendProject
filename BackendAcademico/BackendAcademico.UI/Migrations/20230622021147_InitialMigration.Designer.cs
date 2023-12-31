﻿// <auto-generated />
using System;
using BackendAcademico.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendAcademico.UI.Migrations
{
    [DbContext(typeof(BackendAcademicoDBContext))]
    [Migration("20230622021147_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("BackendAcademico.Domain.Entities.EstudianteEntity", b =>
                {
                    b.Property<int>("Id_Estudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("CI")
                        .IsRequired()
                        .HasMaxLength(7)
                        .HasColumnType("varchar(7)");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Estudiante");

                    b.ToTable("Estudiante", (string)null);
                });

            modelBuilder.Entity("BackendAcademico.Domain.Entities.InscripcionEntity", b =>
                {
                    b.Property<int>("Id_Inscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Id_Estudiante")
                        .HasColumnType("int");

                    b.Property<int>("Id_Materia")
                        .HasColumnType("int");

                    b.HasKey("Id_Inscripcion");

                    b.HasIndex("Id_Estudiante");

                    b.HasIndex("Id_Materia");

                    b.ToTable("Inscripcion", (string)null);
                });

            modelBuilder.Entity("BackendAcademico.Domain.Entities.MateriaEntity", b =>
                {
                    b.Property<int>("Id_Materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_Materia");

                    b.ToTable("Materia", (string)null);
                });

            modelBuilder.Entity("BackendAcademico.Domain.Entities.InscripcionEntity", b =>
                {
                    b.HasOne("BackendAcademico.Domain.Entities.EstudianteEntity", "Estudiante")
                        .WithMany("Inscripciones")
                        .HasForeignKey("Id_Estudiante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackendAcademico.Domain.Entities.MateriaEntity", "Materia")
                        .WithMany("Inscripciones")
                        .HasForeignKey("Id_Materia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("BackendAcademico.Domain.Entities.EstudianteEntity", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("BackendAcademico.Domain.Entities.MateriaEntity", b =>
                {
                    b.Navigation("Inscripciones");
                });
#pragma warning restore 612, 618
        }
    }
}
