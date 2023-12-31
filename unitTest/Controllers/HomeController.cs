﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using unitTest.Models;
using UnitTest.Data.Models;
using UnitTest.Data.Repositorys;

namespace unitTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRepository _repository;

    public HomeController(ILogger<HomeController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;

    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [Route("Add")]
    public IActionResult Add()
    {
        return View(new Person());
    }

    [HttpPost]
    [Route("Add")]
    public async Task<IActionResult> Add(Person p)
    {
        bool result = await _repository.Add(p);

        return RedirectToAction("Index");
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

