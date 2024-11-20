using ECommerce.Data.Cart;
using ECommerce.Data;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Data.Services;

public class OrdersService : IOrdersService
{
    readonly AppDbContext _context;

    public OrdersService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
    {
        var orders = await _context.Orders.Include(o => o.OrdersItems).ThenInclude(n => n.Movie)
            .Where(o => o.UserId == userId)
            .ToListAsync();

        return orders;
    }

    public async Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string email)
    {
        var order = new Order()
        {
            Email = email,
            UserId = userId
        };

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        foreach (var item in items)
        {
            var orderItem = new OrderItem()
            {
                Amount = item.Amount,
                MovieId = item.Movie.Id,
                OrderId = order.Id,
                Price = item.Movie.Price
            };
            await _context.OrderItems.AddAsync(orderItem);
        }
        await _context.SaveChangesAsync();
    }
}