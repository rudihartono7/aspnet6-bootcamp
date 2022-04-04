using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.ViewModels;

namespace Trisatech.Kamlinko.WebApp.Services;
public class OrderService : BaseDbService, IOrderService
{
    public OrderService(KamlinkoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Order> Checkout(Order newOrder)
    {
        await DbContext.AddAsync(newOrder);
        await DbContext.SaveChangesAsync();

        return newOrder;
    }

    public async Task<List<OrderViewModel>> Get(int idCustomer)
    {
        var result = await (from a in DbContext.Orders
        join b in DbContext.StatusOrders on a.Status equals b.Id
        join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
        select new OrderViewModel
        {
            Id = a.Id,
            Status = b.Nama,
            TglOrder = a.TglTransaksi,
            TotalBayar = a.JmlBayar,
            Details = (from c in DbContext.DetailOrders
                join d in DbContext.Produks on c.IdProduk equals d.Id
                where c.IdOrder == a.Id
                select new OrderDetailViewModel
                {
                    Id = c.Id,
                    Produk = d.Nama,
                    Harga = c.Harga,
                    Qty = c.JmlBarang,
                    SubTotal = c.SubTotal
                }).ToList()
        }).ToListAsync();

        return result;
    }
}