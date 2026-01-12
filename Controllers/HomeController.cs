using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GH300App.Models;
using System.Text.Json;

namespace GH300App.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _environment;

    public HomeController(IWebHostEnvironment environment)
    {
        _environment = environment;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        var jsonPath = Path.Combine(_environment.ContentRootPath, "sampledata.json");
        var jsonData = System.IO.File.ReadAllText(jsonPath);
        var employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);
        return View(employees);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
