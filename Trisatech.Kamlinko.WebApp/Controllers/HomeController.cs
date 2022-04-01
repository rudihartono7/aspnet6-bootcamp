using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Trisatech.Kamlinko.WebApp.Interfaces;

namespace Trisatech.Kamlinko.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProdukService _produkService;

    public HomeController(ILogger<HomeController> logger, IProdukService produkService)
    {
        _logger = logger;
        _produkService = produkService;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if(HttpContext.User == null || HttpContext.User.Identity == null){
            ViewBag.IsLogged = false;
        } else {
            ViewBag.IsLogged = HttpContext.User.Identity.IsAuthenticated;
        }

        base.OnActionExecuted(context);
    }
    
    //page = number untuk halaman ke - n
    //page count = jumlah data yang ditampilkan per halaman
    public async Task<IActionResult> Index(int? page, int? pageCount)
    {
        var viewModels = new List<ProdukViewModel>();

        int limit = 2;
        if(pageCount != null)
        {
            limit = pageCount.Value;
        }

        int offset = 0;
        if(page == null) 
        {
            offset = 0;
        }else{
            offset = (page.Value - 1) * limit;
        }

        var dbResult = await _produkService.Get(limit, offset, string.Empty);
        
        if(dbResult == null || !dbResult.Any())
        {
            return RedirectToAction(nameof(Index), new {
                page = page > 1 ? page - 1 : 1,
                pageCount = pageCount
            });
        }

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new ProdukViewModel
            {
                Id = dbResult[i].Id,
                Nama = dbResult[i].Nama,
                Gambar = dbResult[i].Gambar,
                Harga = dbResult[i].Harga,
                Kategories = dbResult[i].ProdukKategoris.Select(x => new KategoriViewModel
                {
                    Id = x.IdKategori,
                    Nama = x.IdKategoriNavigation.Nama,
                    Icon = x.IdKategoriNavigation.Icon
                }).ToList()
            });
        }


        ViewBag.HalamanSekarang = page ?? 1;
        return View(viewModels);
    }

    public async Task<IActionResult> Produk(int? id) {
        if(id == null) 
        {
            return NotFound();
        }

        var produk = await _produkService.Get(id.Value);

        if (produk == null)
        {
            return NotFound();
        }

        return View(new ProdukDetailViewModel()
        {
            Id = produk.Id,
            Nama = produk.Nama,
            Deskripsi = produk.Deskripsi,
            Harga = produk.Harga,
            Gambar = produk.Gambar,
            Stok = 100,
            Terjual = 10
        });
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Denied()
    {
        return View();
    }

    [AllowAnonymous]    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
