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
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.Controllers;

[Authorize(Roles = AppConstant.CUSTOMER)]
public class OrderController : Controller
{
    private readonly ILogger<OrderController> _logger;
    private readonly IKeranjangService _keranjangService;
    private readonly IOrderService _orderService;

    public OrderController(ILogger<OrderController> logger, IKeranjangService keranjangService,
    IOrderService orderService)
    {
        _logger = logger;
        _keranjangService = keranjangService;
        _orderService = orderService;
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

    public override void OnActionExecuting(ActionExecutingContext context){
        
        base.OnActionExecuting(context);
    }

    public async Task<IActionResult> Index()
    {
        
        var result = await _orderService.Get(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt());

        return View(result);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Checkout(CheckoutViewModel? request)
    {
        if(request == null)
        {
            return BadRequest();
        }

        if(request.Alamat == 0)
        {
            return BadRequest();
        }


        int idCustomer = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.ToInt();
        var result = await _keranjangService.Get(idCustomer);

        if(result == null || !result.Any())
        {
            return BadRequest();
        }

        foreach (var item in result)
        {
            int keranjangId = request.Id.FirstOrDefault(x=> item.Id == x);
            
            if(keranjangId < 1)
            {
                continue;
            }
            int jumlahBarangBaru = request.Qty[Array.IndexOf(request.Id, keranjangId)];

            item.JmlBarang = jumlahBarangBaru;
            item.Subtotal = item.HargaBarang * jumlahBarangBaru;
        }

        var newOrder = new Order();

        newOrder.IdCustomer = idCustomer;
        newOrder.JmlBayar = result.Sum(x=>x.Subtotal);
        newOrder.Note = request.Note;
        newOrder.Status = 1;
        newOrder.IdAlamat = request.Alamat;
        newOrder.TglTransaksi = DateTime.Now;
        newOrder.DetailOrders = new List<DetailOrder>();

        foreach(var item in result)
        {
            newOrder.DetailOrders.Add(new DetailOrder
            {
                IdOrder = newOrder.Id,
                Harga = item.HargaBarang,
                JmlBarang = item.JmlBarang,
                SubTotal = item.Subtotal,
                IdProduk = item.IdProduk
            });
        }
        
        await _orderService.Checkout(newOrder);

        await _keranjangService.Clear(idCustomer);

        return RedirectToAction(nameof(CheckoutBerhasil));
    }

    public IActionResult CheckoutBerhasil(){
        
        return View();
    }
}
