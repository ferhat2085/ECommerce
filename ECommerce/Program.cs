using Ecommerce.Data;
using Ecommerce.Data.Cart;
using Ecommerce.Data.Services;
using ECommerce.Data;
using ECommerce.Data.Cart;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        //var connectionString = builder.Configuration.GetConnectionString("ConnectionStrings:DefaultConnectionString");
        // Add services to the container.

        builder.Services.AddScoped<IActorsService, ActorsService>();
        builder.Services.AddScoped<IProducersService, ProducersService>();
        builder.Services.AddScoped<ICinemasService, CinemasService>();
        builder.Services.AddScoped<IMoviesService, MoviesService>();
        builder.Services.AddScoped<IOrdersService, OrdersService>();

        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();


        //authentication and authorization
        //builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        builder.Services.AddMemoryCache();
        builder.Services.AddSession();
        builder.Services.AddAuthentication(option =>
        {
            option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        });


        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer("Data Source=UY04-7\\SQLEXPRESS;Initial Catalog=ECommerceDb;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        AppDbInitializer.Seed(app);
        AppDbInitializer.SeedUsersAndRolesAsync(app).GetAwaiter().GetResult(); 

        app.Run();
    }
}