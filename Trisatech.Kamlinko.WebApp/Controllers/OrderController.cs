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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trisatech.Kamlinko.WebApp.Controllers;

[Authorize]
public class OrderController : BaseController
{
    private readonly ILogger<OrderController> _logger;
    private readonly IKeranjangService _keranjangService;
    private readonly IOrderService _orderService;
    private readonly IStatusService _statusService;

    public OrderController(ILogger<OrderController> logger, 
    IKeranjangService keranjangService,
    IOrderService orderService,
    IStatusService statusService)
    {
        _logger = logger;
        _keranjangService = keranjangService;
        _orderService = orderService;
        _statusService = statusService;
    }

    public override void OnActionExecuting(ActionExecutingContext context){
        
        base.OnActionExecuting(context);
    }

    [Authorize(Roles = AppConstant.ADMIN)]
    public async Task<IActionResult> Index(int? page, int? pageCount)
    {
        var tuplePagination = Common.ToLimitOffset(page, pageCount);

        var result = await _orderService.GetV3(tuplePagination.Item1, tuplePagination.Item2);

        await SetStatusListAsSelectListItem();
        ViewBag.FilterDate = null;

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Index([FromQuery]int? page, [FromQuery]int? pageCount, int? status, DateTime? date)
    {
        var tuplePagination = Common.ToLimitOffset(page, pageCount);

        var result = await _orderService.GetV3(tuplePagination.Item1, tuplePagination.Item2, status, date);
    
        await SetStatusListAsSelectListItem(status);
        if(date != null)
        {
            ViewBag.FilterDate = date.Value.ToString("MM/dd/yyyy");
        }
        return View(result);
    }

    private async Task SetStatusListAsSelectListItem(int? status = null){
        var statusList = await _statusService.Get();

        if(statusList == null || !statusList.Any()){
            ViewBag.StatusList = new List<SelectListItem>();
        }else{
            ViewBag.StatusList = statusList.Select(x=> new SelectListItem {
                Value = x.Id.ToString(),
                Text = x.Nama,
                Selected = status != null && status.Value == x.Id
            }).ToList();
        }
    }

    [Authorize(Roles = AppConstant.CUSTOMER)]
    public async Task<IActionResult> MyOrder(){
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
