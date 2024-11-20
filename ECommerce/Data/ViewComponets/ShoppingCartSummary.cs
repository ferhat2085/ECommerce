﻿using Ecommerce.Data.Cart;
namespace Ecommerce.Data.ViewComponents;

using ECommerce.Data.Cart;
using Microsoft.AspNetCore.Mvc;
public class ShoppingCartSummary : ViewComponent
{
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = _shoppingCart.GetShoppingCartItems();

        return View(items.Count);
    }
}