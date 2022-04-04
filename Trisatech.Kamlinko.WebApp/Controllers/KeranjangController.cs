using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trisatech.Kamlinko.WebApp.Models;
using Trisatech.Kamlinko.WebApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Authorization;
using Trisatech.Kamlinko.WebApp.Interfaces;
using System.Security.Claims;
using Trisatech.Kamlinko.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trisatech.Kamlinko.WebApp.Controllers;

[Authorize(Roles = AppConstant.CUSTOMER)]
public class KeranjangController : Controller
{
    private readonly ILogger<KeranjangController> _logger;
    private readonly IKeranjangService _keranjangService;

    private readonly IAccountService _accountService;

    public KeranjangController(ILogger<KeranjangController> logger, 
    IKeranjangService keranjangService,
    IAccountService accountService)
    {
        _logger = logger;
        _keranjangService = keranjangService;
        _accountService = accountService;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (HttpContext.User == null || HttpContext.User.Identity == null)
        {
            ViewBag.IsLogged = false;
        }
        else
        {
            ViewBag.IsLogged = HttpContext.User.Identity.IsAuthenticated;
        }

        base.OnActionExecuted(context);
    }

    public async Task<IActionResult> Index()
    {
        int idCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt();
        var result = await _keranjangService.Get(idCustomer);

        var alamat = await _accountService.GetAlamat(idCustomer);

        ViewBag.AlamatList = alamat.Select(x=> new SelectListItem(x.Item2.ToString(), x.Item1.ToString())).ToList();
        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int? produkId)
    {
        if (produkId == null)
        {
            return BadRequest();
        }

        await _keranjangService.Add(new Datas.Entities.Keranjang
        {
            IdProduk = produkId.Value,
            JmlBarang = 1,
            IdCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt()
        });

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(KeranjangUpdateViewModel request)
    {

        if (!ModelState.IsValid)
        {
            return Json(new
            {
                success = false,
                message = "bad request"
            });
        }

        try
        {

            await _keranjangService.Update(new Datas.Entities.Keranjang
            {
                Id = request.Id,
                JmlBarang = request.JmlBarang,
                IdCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt()
            });

            return Json(new
            {
                success = true
            });
        }
        catch (InvalidOperationException ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
        catch
        {
            throw;
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int?  id)
    {
        if(id == null)
        {
            return Json(new
            {
                success = false,
                message = "keranjang item yang mau dihapus tidak ditemukan"
            });
        }

        try
        {

            await _keranjangService.Delete(id.Value);

            return Json(new
            {
                success = true
            });
        }
        catch (InvalidOperationException ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message
            });
        }
        catch
        {
            throw;
        }
    }
}
