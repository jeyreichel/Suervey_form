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
        var events = EventRepository.GetAll();
        return View(events);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    // POST: Home/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Home/Create")]
    public IActionResult Create(IFormCollection formData)
    {
        var title = formData["title"];
        var description = formData["description"];
        var startDate = formData["start"];
        var endDate = formData["end"];
        var assignedTo = formData["assignedTo"];
        try
        {
            if (!string.IsNullOrEmpty(title))
            {
                var eventModel = new EventModel
                {
                    Title = title,
                    Description = description,
                    StartDate = DateTime.Parse(startDate),
                    EndDate = DateTime.Parse(endDate),
                    AssignedTo = assignedTo
                };
                
                int newId = EventRepository.Create(eventModel);
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

    [HttpPost]
    [Route("Home/Edit/{id}")]
    public IActionResult Edit(IFormCollection formData, int id)
    {
        if (id != int.Parse(formData["id"]))
            return BadRequest();
            
        if (ModelState.IsValid)
        {
            if (EventRepository.Update(new EventModel
            {
                Id = id,
                Title = formData["title"],
                Description = formData["description"],
                StartDate = DateTime.Parse(formData["start"]),
                EndDate = DateTime.Parse(formData["end"]),
                AssignedTo = formData["assignedTo"]
            }))
                return RedirectToAction("Index");
            else
                return NotFound();
        }
        
        return View();
    }

    [HttpPost]
    [Route("Home/Delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (EventRepository.Delete(id))
            return RedirectToAction("Index");
        else
            return NotFound();
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
