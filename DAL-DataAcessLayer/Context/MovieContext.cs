using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL_DataAcessLayer.Context
{
    public class MovieContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FilmType> Types { get; set; }

        public MovieContext()
        {
            this.Database.EnsureCreated();
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .EnableSensitiveDataLogging()
        //.UseSqlite(@"Data source = " + Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"..\\..\\..\\..\\DataBase\\movie.db")));
        .UseSqlite(@"Data source = C:\Users\Hector\Source\Repos\BedeschiL\MoviesMVC-WPF\DataBase\movie.db");

    }
}
