using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sessions.Models;

namespace Sessions.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        const string sessionKeyName = "_Name";
        const string sessionKeyAge = "_Age";
        
        if (string.IsNullOrEmpty(HttpContext.Session.GetString(sessionKeyName)))
        {
            HttpContext.Session.SetString(sessionKeyName, "The Doctor");
            HttpContext.Session.SetInt32(sessionKeyAge, 73);
        }
        var name = HttpContext.Session.GetString(sessionKeyName);
        var age = HttpContext.Session.GetInt32(sessionKeyAge).ToString();

        _logger.LogInformation("Session Name: {Name}", name);
        _logger.LogInformation("Session Age: {Age}", age);
        
        return View();
    }

    public IActionResult Privacy()
    {
        HttpContext.Session.Clear();
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}