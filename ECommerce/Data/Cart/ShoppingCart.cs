using ECommerce.Data.Cart;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Cart;

public class ShoppingCart
{
    public AppDbContext _context { get; set; }

    public ShoppingCart(AppDbContext context)
    {
        _context = context;
    }

    public void AddItemToCart(Movie movie)   //varsa bir tane daha ekle 2 olsun, yoksa ekle 1 olsun
    {
        var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.Movie.Id == movie.Id
        && x.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem is null)
        {
            shoppingCartItem = new ShoppingCartItem()
            {
                ShoppingCartId = ShoppingCartId,
                Movie = movie,
                Amount = 1
            };

            _context.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        _context.SaveChanges();
    }

    public static ShoppingCart GetShoppingCart(IServiceProvider services) // ezberlemene gerek yok kromda bilgi saklamak
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDbContext>();

        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        session.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void RemoveItemFromCart(Movie movie)
    {
        var shoppingCartItem = GetShoppingCartItems()
            .FirstOrDefault(x => x.Movie.Id == movie.Id
        && x.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem is not null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _context.SaveChanges();
    }

    public string ShoppingCartId { get; set; }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Include(n => n.Movie).ToList());
    }

    public double GetShoppingCartTotal()   // sepet toplamı ne kadar odiyicegimiz kısım
    {
        return _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .Select(m => m.Movie.Price * m.Amount).Sum();
    }

    public async Task ClearShoppingCartAsync()
    {
        var items = await _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId)
            .ToListAsync();
        _context.ShoppingCartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }
}