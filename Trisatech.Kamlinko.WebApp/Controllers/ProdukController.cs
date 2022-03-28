using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trisatech.Kamlinko.WebApp.Controllers;

public class ProdukController : Controller
{
    private readonly IProdukService _produkService;
    private readonly IKategoriService _kategoriService;
    private readonly ILogger<ProdukController> _logger;

    public ProdukController(ILogger<ProdukController> logger, 
    IProdukService productService, 
    IKategoriService kategoriService)
    {
        _logger = logger;
        _produkService = productService;
        _kategoriService = kategoriService;
    }

    public async Task<IActionResult> Index()
    {
        var dbResult = await _produkService.GetAll();

        var viewModels = new List<ProdukViewModel>();

        for (int i = 0; i < dbResult.Count; i++)
        {
            viewModels.Add(new ProdukViewModel{
                Id = dbResult[i].Id,
                Nama = dbResult[i].Nama,
                Deskripsi = dbResult[i].Deskripsi,
                Gambar = dbResult[i].Gambar,
                Harga = dbResult[i].Harga,
                Stok = dbResult[i].Stok
            });
        }

        return View(viewModels);
    }
    //Transfer data list of kategori ke view dimasukan dalam selectlistitem
    private async Task SetKategoriDataSource()
    {
        var kategoriViewModels = await _kategoriService.GetAll();

        ViewBag.KategoriDataSource = kategoriViewModels.Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Nama,
            Selected = false
        }).ToList();
    }
    public async Task<IActionResult> Create() {

        await SetKategoriDataSource();
        return View(new ProdukViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProdukViewModel request) {
        if(!ModelState.IsValid){
            await SetKategoriDataSource();
            return View(request);
        }
        try{

            var product = request.ConvertToDbModel();

            //Insert to ProdukKategori table
            product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
            {
                IdKategori = request.KategoriId,
                IdProduk = product.Id
            });

            await _produkService.Add(product);

            return Redirect(nameof(Index));
        }catch(InvalidOperationException ex){
            ViewBag.ErrorMessage = ex.Message;
        }
        catch(Exception) {
            throw;
        }


        await SetKategoriDataSource();
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
