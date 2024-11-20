using ECommerce.Data.Cart;
using ECommerce.Models;

namespace Ecommerce.Data.Services;

public interface IOrdersService
{
    Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, string email);

    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}