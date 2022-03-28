using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.Interfaces;

namespace Trisatech.Kamlinko.WebApp.Controllers;

public class KategoriController : Controller
{
    private readonly IKategoriService _kategoriService;
    private readonly ILogger<KategoriController> _logger;

    public KategoriController(ILogger<KategoriController> logger, IKategoriService kategoriService)
    {
        _logger = logger;
        _kategoriService = kategoriService;
    }

    public async Task<IActionResult> Index()
    {
        var dbResult = await _kategoriService.GetAll();

        var viewModels = new List<KategoriViewModel>();

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new KategoriViewModel{
                Id = dbResult[i].Id,
                Nama = dbResult[i].Nama,
                Deskripsi = dbResult[i].Deskripsi,
            });
        }

        return View(viewModels);
    }

    public IActionResult Create() {
        return View(new KategoriViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(KategoriViewModel request) {
        if(!ModelState.IsValid){
            return View(request);
        }
        try{
            await _kategoriService.Add(request.ConvertToDbModel());

            return Redirect(nameof(Index));   
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }

        return View(request);
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
