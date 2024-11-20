using ECommerce.Data.Base;
using ECommerce.Models;

namespace ECommerce.Data.Cart;

public class ShoppingCartItem : IEntityBase
{
    public int Id { get; set; }
    public string ShoppingCartId { get; set; }
    public Movie Movie { get; set; }
    public int Amount { get; set; }
}