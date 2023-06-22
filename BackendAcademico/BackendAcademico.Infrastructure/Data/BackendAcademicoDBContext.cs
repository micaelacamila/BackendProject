using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendAcademico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BackendAcademico.Infrastructure.Data
{
    public class BackendAcademicoDBContext:DbContext
    {
        public DbSet<EstudianteEntity> Estudiantes { get; set; }
        public DbSet<MateriaEntity> Materias { get; set; }
        public DbSet<InscripcionEntity> InscripcionEntities { get; set; }
       
        public BackendAcademicoDBContext(DbContextOptions<BackendAcademicoDBContext> options) : base(options)
        {

        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<EstudianteEntity>().ToTable("Estudiante");
            builder.Entity<EstudianteEntity>().Property(i => i.Id_Estudiante).ValueGeneratedOnAdd();
            builder.Entity<EstudianteEntity>().HasMany(m => m.Inscripciones).WithOne(i => i.Estudiante);

            builder.Entity<MateriaEntity>().ToTable("Materia");
            builder.Entity<MateriaEntity>().Property(i => i.Id_Materia).ValueGeneratedOnAdd();
            builder.Entity<MateriaEntity>().HasMany(i=>i.Inscripciones).WithOne(i=>i.Materia);

            builder.Entity<InscripcionEntity>().ToTable("Inscripcion");
            builder.Entity<InscripcionEntity>().Property(i => i.Id_Inscripcion).ValueGeneratedOnAdd();
            builder.Entity<InscripcionEntity>().HasOne(i => i.Estudiante).WithMany(e => e.Inscripciones);
            builder.Entity<InscripcionEntity>().HasOne(i => i.Materia).WithMany(e => e.Inscripciones);


        }
    }
}

