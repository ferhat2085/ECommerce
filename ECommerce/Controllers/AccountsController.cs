using ECommerce.Data;
using ECommerce.Models;
using ECommerce.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers;

public class AccountsController : Controller
{
    readonly UserManager<ApplicationUser> _userManager;
    readonly SignInManager<ApplicationUser> _signInManager;
    readonly AppDbContext _context;

    public AccountsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public IActionResult Login() => View(new LoginVM());
    [HttpPost]  
    public  async Task<IActionResult>  Login(LoginVM login)
    {
        if (!ModelState.IsValid) return View(login);

        var user = await _userManager.FindByEmailAsync(login.EmailAddress);

        if (user is not  null)
        {
            var  passwordCheck = await _userManager.CheckPasswordAsync(user, login.Password);
            
            if(passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);
                if (result.Succeeded) 
                {
                   return RedirectToAction("Index", "Movies");
                }
            }
            TempData["Error"] = "Hatalı şifre";
            return View(login); 
        }

        TempData["Error"] = "Hatalı giriş";
        return View(login);

    }

}
