using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SurveyJSDemo.Models;
using System;
using System.Text.Json;

namespace SurveyJSDemo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // POST: Home/Create
    [HttpPost]
    // [ValidateAntiForgeryToken]
    [Route("Home/Create")]
    public IActionResult Create(IFormCollection formData)
    {
        var surveyResult = formData["surveyResult"];
        try
        {
            if (!string.IsNullOrEmpty(surveyResult))
            {
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                
                var eventModel = JsonSerializer.Deserialize<EventModel>(surveyResult, jsonOptions);
                System.Diagnostics.Debug.WriteLine("EventModel: " + eventModel);
                
                return View("Success", eventModel);
            }
            
            ModelState.AddModelError("", "No data was submitted.");
            return View();
        }
        catch (Exception ex)
        {          
            ModelState.AddModelError("", $"Error processing form: {ex.Message}");
            ViewBag.ErrorDetails = ex.ToString();
            return View();
        }
    }

    public IActionResult Success(EventModel model)
    {
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
