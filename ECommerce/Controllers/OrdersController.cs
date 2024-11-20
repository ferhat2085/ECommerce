using Ecommerce.Data.Cart;
using Ecommerce.Data.Services;
using ECommerce.Data.Services;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers;

public class OrdersController : Controller
{
    private readonly IMoviesService _moviesService;
    private readonly IOrdersService _ordersService;
    private readonly ShoppingCart _shoppingCart;

    public OrdersController(IMoviesService moviesService, ShoppingCart shoppingCart, IOrdersService ordersService)
    {
        _moviesService = moviesService;
        _shoppingCart = shoppingCart;
        _ordersService = ordersService;
    }
    public async    Task<IActionResult> Index()
    {
        int userId = 1;
        var orders= await _ordersService.GetOrdersByUserIdAsync(userId);   
        return View(orders);    
    }

    public IActionResult ShoppingCart()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var response = new ShoppingCartVM()
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(response);
    }

    public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
    {
        var item = await _moviesService.GetMovieByIdAsync(id);

        if (item is not null)
        {
            _shoppingCart.AddItemToCart(item);
        }

        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<RedirectToActionResult> RemoveItemFromShoppingCart(int id) //RedirectToActionResult solid in l si ...
    {
        var item = await _moviesService.GetMovieByIdAsync(id);

        if (item is not null)
        {
            _shoppingCart.RemoveItemFromCart(item);
        }

        return RedirectToAction(nameof(ShoppingCart));
    }

    public async Task<IActionResult> CompleteOrder()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        int userId = 1;
        string email = "";

        await _ordersService.StoreOrderAsync(items, userId, email);

        await _shoppingCart.ClearShoppingCartAsync();
        return View(items);
    }
}