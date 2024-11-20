using ECommerce.Data.Cart;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ECommerce.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser> //IdentityUser'ı ApplicationUser extend ettiği için generic şekilde yazmalıyız.
{

    public DbSet<Actor> Actors { get; set; }
    public DbSet<Actor_Movie> Actors_Movies { get; set; }
    public DbSet<Producer> Producers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    //DbCont4ext classı bazı optionlarbekler.(DbContextOptions generic tipte bir class istiyor. DbContexten miras alan bir classı generic kısma yazmak istiyor. sonra bunu base classa option olarak ilet.
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