using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSC.Modelos;

namespace SSC.DbConfiguration
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Capitulo> Capitulos { get; set; }
        public DbSet<EvaluacionPractica> EvaluacionesPracticas { get; set; }
        public DbSet<EvaluacionTeorica> EvaluacionesTeoricas { get; set; }

        public ApplicationDbContext(DbContextOptions options): base(options)
        {
            //Database.EnsureCreated();
        }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Curso>()
                .HasKey(x => new { x.Id });
            
            modelBuilder.Entity<Curso>()
                .HasMany(x => x.EvaluacionesPracticas)
                .WithOne(x => x.Curso)
                .HasForeignKey(x => x.CursoId);

            modelBuilder.Entity<Curso>()
                .HasMany(x => x.EvaluacionesTeoricas)
                .WithOne(x => x.Curso)
                .HasForeignKey(x => x.CursoId);
           
            modelBuilder.Entity<Curso>()
                .HasMany(x => x.Capitulos)
                .WithOne(x => x.Curso)
                .HasForeignKey(x => x.CursoId);


            modelBuilder.Entity<EvaluacionPractica>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<EvaluacionTeorica>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<Capitulo>()
                .HasKey(x => new { x.Id });
            modelBuilder.Entity<Capitulo>()
                .HasOne(x => x.Curso)
                .WithMany(x=> x.Capitulos);


            //inserto data de prueba
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var cursoNetCore = new Curso { Id=1, Costo = 2000, Instructor = "Emanuel Goette", Nombre = "NetCore" };
            var cursoPhp = new Curso {Id=2, Costo = 1500, Instructor = "Emanuel Goette", Nombre = "Php" };

            var capitulo1NetCore = new Capitulo {Id=1, CursoId = cursoNetCore.Id, Descripcion = "capitulo 1 del curso de net core", Tema = "POO" };
            var capitulo2NetCore = new Capitulo {Id=2, CursoId =cursoNetCore.Id, Descripcion = "capitulo 2 del curso de net core", Tema = "AutoMapper" };
            var capitulo1Php = new Capitulo {Id=3, CursoId = cursoPhp.Id, Descripcion = "cap 1 curso PHP", Tema = "Variables" };

            var evaluacionTeoricaNetCore = new EvaluacionTeorica { Id=1,NumeroEvaluacion=1,Calificacion = 68, CursoId = 1 };
            var evaluacionPracticaNetCore = new EvaluacionPractica { Id=1,NumeroEvaluacion=2,Aprobado = true, CursoId = 1 };

            modelBuilder.Entity<Curso>()
                .HasData( new List<Curso>()
                {
                    cursoNetCore, cursoPhp
                });

            modelBuilder.Entity<Capitulo>()
                .HasData( new List<Capitulo>()
                {
                    capitulo1NetCore,capitulo2NetCore,capitulo1Php
                });

            modelBuilder.Entity<EvaluacionTeorica>()
               .HasData(new List<EvaluacionTeorica>()
               {
                    evaluacionTeoricaNetCore
               });

            modelBuilder.Entity<EvaluacionPractica>()
              .HasData(new List<EvaluacionPractica>()
              {
                    evaluacionPracticaNetCore
              });
        }

    }
}
