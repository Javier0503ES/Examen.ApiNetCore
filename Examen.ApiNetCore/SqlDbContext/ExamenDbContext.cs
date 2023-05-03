﻿using Examen.ApiNetCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Examen.ApiNetCore.SqlDbContext
{
    public class ExamenDbContext : DbContext
    {
        public DbSet<Usuario> TblUsuarios { get; set; }
        //public DbSet<Bitacora> TblBitacora { get; set; }
        //public DbSet<Entities.DbEntities.Examen> TblExamenes { get; set; }
        //public DbSet<Pregunta> TblPreguntas { get; set; }
        //public DbSet<Respuesta> TblRespuestas { get; set; }

        public ExamenDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=examenandradescompany.database.windows.net,1433;Database=ExamenDb ;User Id=UserDbExamen; Password=Ex@men1234;");

        }
    }
}
