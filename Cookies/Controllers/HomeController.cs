using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Cookies.Models;

namespace Cookies.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var cookieOptions = new CookieOptions();
        
        cookieOptions.Expires = DateTimeOffset.Now.AddHours(1);
        cookieOptions.Path = "/florianp";
        
        Response.Cookies.Append("LeCookieDeFlo", "Miam !", cookieOptions);
        return View();
    }

    public IActionResult Privacy()
    {
        Response.Cookies.Append(
            "LeCookieDeFlo", 
            "Crunch crunch",
            new CookieOptions
            {
                Path = "/florianp",
                Expires = DateTimeOffset.Now.AddMinutes(5)
            });

        return View();
    }

    public IActionResult Settings()
    {
        Response.Cookies.Delete("LeCookieDeFlo");
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}