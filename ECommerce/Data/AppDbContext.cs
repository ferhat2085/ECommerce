using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data;

public class AppDbContext : DbContext // dbContext sistemede gomülü olarak bulunan bır yapı zatan database te nasıl calışacagını soyler 
{
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor_Movie>().HasKey(ma => new
        {
            ma.ActorId,
            ma.MovieId
        });
        modelBuilder.Entity<Actor_Movie>()
            .HasOne(m => m.Movie)
            .WithMany(ma => ma.Actors_Movies)
             .HasForeignKey(ma => ma.MovieId);

        modelBuilder.Entity<Actor_Movie>()
          .HasOne(m => m.Actor)
          .WithMany(ma => ma.Actors_Movies)
          .HasForeignKey(ma => ma.ActorId);


        base.OnModelCreating(modelBuilder);
    }
}




