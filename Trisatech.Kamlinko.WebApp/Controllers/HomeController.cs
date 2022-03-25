using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace Trisatech.Kamlinko.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly Kamlinko.WebApp.Datas.KamlinkoDbContext _dbContext;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, Kamlinko.WebApp.Datas.KamlinkoDbContext dbContext)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var dbResult = await _dbContext.Kategoris.Select(x => new KategoriViewModel {
            Nama = x.Nama,
            Deskripsi = x.Deskripsi
        }).ToListAsync();
        
        return View(dbResult);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
