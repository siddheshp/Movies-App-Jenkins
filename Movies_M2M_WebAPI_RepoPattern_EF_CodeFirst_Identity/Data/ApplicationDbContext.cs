using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Identity.Models;

namespace MVC_EF_Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieId, ma.ActorId });
            //builder.Entity<MovieActor>()
            //    .HasOne(m => m.Movie)
            //    .WithMany(ma => ma.MovieActors)
            //    .HasForeignKey(m => m.MovieId);
            //builder.Entity<MovieActor>()
            //    .HasOne(a => a.Actor)
            //    .WithMany(ma => ma.MovieActors)
            //    .HasForeignKey(a => a.ActorId);

            //seed
            //builder.Entity<Movie>().HasData(
            //    new Movie { Id = 1, Name = "Abc" }
            //    );
            base.OnModelCreating(builder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
    }
}
