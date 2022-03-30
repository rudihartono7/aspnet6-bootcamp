using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trisatech.Kamlinko.WebApp.Helpers;

namespace Trisatech.Kamlinko.WebApp.Controllers;

public class ProdukController : Controller
{
    private readonly IProdukService _produkService;
    private readonly IKategoriService _kategoriService;
    private readonly IProdukKategoriService _produkKategoriService;
    private readonly IWebHostEnvironment _iWebHost;
    private readonly ILogger<ProdukController> _logger;

    public ProdukController(ILogger<ProdukController> logger, 
    IProdukService productService, 
    IKategoriService kategoriService,
    IProdukKategoriService produkKategoriService,
    IWebHostEnvironment iwebHost)
    {
        _logger = logger;
        _iWebHost = iwebHost;
        _produkService = productService;
        _kategoriService = kategoriService;
        _produkKategoriService = produkKategoriService;
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
                Stok = dbResult[i].Stok,
                Kategories = dbResult[i].ProdukKategoris.Select(x => new KategoriViewModel {
                    Id = x.IdKategori,
                    Nama = x.IdKategoriNavigation.Nama,
                    Icon = x.IdKategoriNavigation.Icon
                }).ToList()
            });
        }

        return View(viewModels);
    }
    //Transfer data list of kategori ke view dimasukan dalam selectlistitem
    private async Task SetKategoriDataSource()
    {
        var kategoriViewModels = await _kategoriService.GetAll();

        ViewBag.KategoriDataSource = kategoriViewModels
        .Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Nama,
            Selected = false
        }).ToList();
    }

    private async Task SetKategoriDataSource(int[] kategoris)
    {
        if(kategoris == null)
        {
            await SetKategoriDataSource();
            return;
        }

        var kategoriViewModels = await _kategoriService.GetAll();

        ViewBag.KategoriDataSource = kategoriViewModels
        .Select(x => new SelectListItem
        {
            Value = x.Id.ToString(),
            Text = x.Nama,
            Selected = kategoris.FirstOrDefault(y => y == x.Id) == 0 ? false : true
        }).ToList();
    }

    public async Task<IActionResult> Create() {

        await SetKategoriDataSource();
        return View(new ProdukViewModel());
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int? id) {

        if(id == null)
        {
            return BadRequest();
        }

        var produk = await _produkService.Get(id.Value);

        if(produk == null) 
        {
            return NotFound();
        }

        var kategoriIds = await _produkKategoriService.GetKategoriIds(produk.Id);
        
        await SetKategoriDataSource(kategoriIds);

        return View(new ProdukViewModel(){
            Id = produk.Id,
            Nama = produk.Nama,
            Deskripsi = produk.Deskripsi,
            Harga = produk.Harga,
            Gambar = produk.Gambar,
            KategoriId = kategoriIds
        });
    } 

    [HttpPost]
    public async Task<IActionResult> Edit(int? id, ProdukViewModel request) {
        if(!ModelState.IsValid){
            await SetKategoriDataSource();
            return View(request);
        }

        if(request == null) {
            await SetKategoriDataSource();
            return View(request);
        }

        try{
        
            string fileName = string.Empty;
            
            if(request.GambarFile != null) 
            {
                fileName = $"{Guid.NewGuid()}-{request.GambarFile?.FileName}";

                string filePathName = _iWebHost.WebRootPath + fileName;
                
                using(var streamWriter = System.IO.File.Create(filePathName)){
                    //await streamWriter.WriteAsync(Common.StreamToBytes(request.GambarFile.OpenReadStream()));
                    //using extension to convert stream to bytes
                    await streamWriter.WriteAsync(request.GambarFile.OpenReadStream().ToBytes());
                }
            }

            var product = request.ConvertToDbModel();
            product.Gambar = $"images/{fileName}";

            //Insert to ProdukKategori table
            for (int i = 0; i < request.KategoriId.Length; i++)
            { 
                product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
                {
                    IdKategori = request.KategoriId[i],
                    IdProduk = product.Id
                });   
            }

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

    [HttpPost]
    public async Task<IActionResult> Create(ProdukViewModel request) {
        if(!ModelState.IsValid){
            await SetKategoriDataSource();
            return View(request);
        }

        if(request == null) {
            await SetKategoriDataSource();
            return View(request);
        }

        try{
        
            string fileName = string.Empty;
            
            if(request.GambarFile != null) 
            {
                fileName = $"{Guid.NewGuid()}-{request.GambarFile?.FileName}";

                string filePathName = _iWebHost.WebRootPath + "/" + fileName;
                
                using(var streamWriter = System.IO.File.Create(filePathName)){
                    //await streamWriter.WriteAsync(Common.StreamToBytes(request.GambarFile.OpenReadStream()));
                    //using extension to convert stream to bytes
                    await streamWriter.WriteAsync(request.GambarFile.OpenReadStream().ToBytes());
                }
            }

            var product = request.ConvertToDbModel();
            product.Gambar = $"images/{fileName}";

            //Insert to ProdukKategori table
            for (int i = 0; i < request.KategoriId.Length; i++)
            { 
                product.ProdukKategoris.Add(new Datas.Entities.ProdukKategori 
                {
                    IdKategori = request.KategoriId[i],
                    IdProduk = product.Id
                });   
            }

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
