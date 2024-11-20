using Ecommerce.Data.Cart;
using ECommerce.Data.Cart;

namespace ECommerce.ViewModels;

public class ShoppingCartVM
{
    public ShoppingCart ShoppingCart { get; set; }

    public double ShoppingCartTotal { get; set; }
}