using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Trisatech.Kamlinko.WebApp.Interfaces;

namespace Trisatech.Kamlinko.WebApp.Controllers;

public class AccountCustomerController : Controller
{
    private readonly ILogger<AccountCustomerController> _logger;
    private readonly IAccountService _accountService;

    public AccountCustomerController(ILogger<AccountCustomerController> logger, IAccountService accountService)
    {
        _logger = logger;
        _accountService = accountService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(){

        return View(new AccountLoginViewModel());
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(AccountLoginViewModel request)
    {
        //Cocokan username dan password ke database
        var result = await _accountService.LoginCustomer(request.Username, request.Password);

        if (result == null)
        {
            return View(new AccountLoginViewModel { });
        }

        try
        {
            #region set session login
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()),
            new Claim(ClaimTypes.Email, result.Email ?? result.Nama),
            new Claim("FullName", result.Nama),
            new Claim(ClaimTypes.Role, AppConstant.CUSTOMER),
        };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                //AllowRefresh = <bool>,
                // Refreshing the authentication session should be allowed.

                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                // The time at which the authentication ticket expires. A 
                // value set here overrides the ExpireTimeSpan option of 
                // CookieAuthenticationOptions set with AddCookie.

                //IsPersistent = true,
                // Whether the authentication session is persisted across 
                // multiple requests. When used with cookies, controls
                // whether the cookie's lifetime is absolute (matching the
                // lifetime of the authentication ticket) or session-based.

                //IssuedUtc = <DateTimeOffset>,
                // The time at which the authentication ticket was issued.

                //RedirectUri = <string>
                // The full path or absolute URI to be used as an http 
                // redirect response value.
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
            #endregion

            return RedirectToActionPermanent("Index", "Home");
        }
        catch (System.Exception)
        {
            return View(request);
        }

    }

    public IActionResult Register() {

        return View(new RegisterViewModel());
    }

    public IActionResult Registered() {

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel request) {
        
        if(!ModelState.IsValid) {
            return View(request);
        }

        try
        {
            await _accountService.Register(request);

            return RedirectToAction("Registered", "AccountCustomer");
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch (System.Exception)
        {
            throw;
        }

        return View(request);
    }
}
