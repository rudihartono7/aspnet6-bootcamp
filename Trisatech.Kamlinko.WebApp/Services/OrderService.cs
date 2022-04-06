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
        where a.IdCustomer == idCustomer
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

#region  Get Order List
    public async Task<List<OrderViewModel>> GetV3(int limit, int offset, int? status = null, DateTime? date = null)
    {
        
        if(status != null && date != null){
            return await (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                where a.Status == status.Value &&
                                date.Value.Date == a.TglTransaksi.Date
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).Skip(offset)
                                .Take(limit).ToListAsync();
        }else if(status != null && date == null){
            return await (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                where a.Status == status.Value
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).Skip(offset)
                                .Take(limit).ToListAsync();
        }else if(status == null && date != null)
        {
            return await (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                where a.TglTransaksi.Date == date.Value.Date
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).Skip(offset)
                                .Take(limit).ToListAsync();   
        }else{
            return await (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).Skip(offset)
                                .Take(limit).ToListAsync();  
        }
        
    }
    
    public async Task<List<OrderViewModel>> GetV2(int limit, int offset, int? status, DateTime? date)
    {
        var selectCondition = (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).AsQueryable();
        
        if(status != null)
        {
            selectCondition = selectCondition.Where(x=>x.IdStatus == status.Value);
        }

        if(date != null)
        {
            selectCondition = selectCondition.Where(x=>x.TglOrder.Date == date.Value.Date);
        }

        return await selectCondition
        .Skip(offset)
        .Take(limit)
        .ToListAsync();
    }
    
    public async Task<List<OrderViewModel>> GetV1(int limit, int offset, int? status, DateTime? date)
    {
        return await (from a in DbContext.Orders
                                join b in DbContext.StatusOrders on a.Status equals b.Id
                                join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
                                where status == null ? 1 == 1 : status.Value == a.Status 
                                && date == null ? 1 == 1 : date.Value.Date == a.TglTransaksi.Date
                                select new OrderViewModel
                                {
                                    Id = a.Id,
                                    Status = b.Nama,
                                    TglOrder = a.TglTransaksi,
                                    TotalBayar = a.JmlBayar
                                }).Skip(offset)
                                .Take(limit).ToListAsync();
    }

#endregion
    public async Task<OrderViewModel> GetDetail(int idCustomer, int idOrder)
    {
        var result = await (from a in DbContext.Orders
        //inner join
        join b in DbContext.StatusOrders on a.Status equals b.Id
        join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
        //end join
        
        //left join
        join pembayaran in DbContext.Pembayarans on a.Id equals pembayaran.IdOrder into tempPembayaran
        from pembayaran in tempPembayaran.DefaultIfEmpty()
        //end join

        join pengiriman in DbContext.Pengirimen on a.Id equals pengiriman.IdOrder into tempPengiriman
        from pengiriman in tempPengiriman.DefaultIfEmpty()
        
        where a.IdCustomer == idCustomer && a.Id == idOrder
        select new OrderViewModel
        {
            Id = a.Id,
            Status = b.Nama,
            IdStatus = b.Id,
            TglOrder = a.TglTransaksi,
            TotalBayar = a.JmlBayar,

            //mendapatkan data detail item order
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
                }).ToList(),

            //mendapatkan data pembayaran jika sudah ada 
            Pembayaran = pembayaran == null ? new PembayaranViewModel() : new PembayaranViewModel{
                Id = pembayaran.Id,
                Metode = pembayaran.Metode,
                IdTujuan = pembayaran.IdTujuan,
                JmlBayar = pembayaran.JmlBayar,
                Note = pembayaran.Note,
                Pajak = pembayaran.Pajak,
                Status = pembayaran.Status,
                TglBayar = pembayaran.TglBayar,
                FileBuktiBayar = pembayaran.FileBuktiBayar
            },

            Pengiriman = pengiriman == null? new PengirimanViewModel() : new PengirimanViewModel
                {
                    Id = pengiriman.Id,
                    Keterangan = pengiriman.Keterangan,
                    Kurir = pengiriman.Kurir,
                    NoResi = pengiriman.NoResi,
                    Ongkir = pengiriman.Ongkir,
                    Status = pengiriman.Status
                }
        }).FirstOrDefaultAsync();

        return result;
    }

    public async Task<OrderViewModel> GetDetail(int idOrder)
    {
        var result = await (from a in DbContext.Orders
        //inner join
        join b in DbContext.StatusOrders on a.Status equals b.Id
        join alamat in DbContext.Alamats on a.IdAlamat equals alamat.Id
        //end join
        //left join
        join pembayaran in DbContext.Pembayarans on a.Id equals pembayaran.IdOrder into tempPembayaran
        from pembayaran in tempPembayaran.DefaultIfEmpty()
        //end join
        where a.Id == idOrder
        select new OrderViewModel
        {
            Id = a.Id,
            Status = b.Nama,
            IdStatus = b.Id,
            TglOrder = a.TglTransaksi,
            TotalBayar = a.JmlBayar,
            Alamat = alamat.Deskripsi,
            IdAlamat = alamat.Id,
            //mendapatkan data detail item order
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
                }).ToList(),

            //mendapatkan data pembayaran jika sudah ada 
            Pembayaran = pembayaran == null ? new PembayaranViewModel() : new PembayaranViewModel{
                Id = pembayaran.Id,
                Metode = pembayaran.Metode,
                IdTujuan = pembayaran.IdTujuan,
                JmlBayar = pembayaran.JmlBayar,
                Note = pembayaran.Note,
                Pajak = pembayaran.Pajak,
                Status = pembayaran.Status,
                TglBayar = pembayaran.TglBayar,
                FileBuktiBayar = pembayaran.FileBuktiBayar
            }
        }).FirstOrDefaultAsync();

        return result;
    }

    public async Task UpdateStatus(int idOrder, short dIBAYAR)
    {
        var order = await DbContext.Orders.FirstOrDefaultAsync(x=>x.Id == idOrder);

        if(order == null)
        {
            throw new ArgumentNullException("Data order tidak ditemukan");
        }

        order.Status = dIBAYAR;

        DbContext.Update(order);
        await DbContext.SaveChangesAsync();
    }

    public async Task Bayar(Pembayaran newBayar)
    {
        if(await DbContext.Pembayarans.AnyAsync(x=>x.IdOrder == newBayar.IdOrder))
        {
            throw new InvalidOperationException("Pembayaran sudah dilakukan");
        }

        await DbContext.AddAsync(newBayar);
        await DbContext.SaveChangesAsync();
    }

    public async Task<bool> SudahDibayar(int idOrder)
    {
        return await DbContext.Orders.AnyAsync(x=>x.Id == idOrder && x.Status == AppConstant.StatusOrder.DIBAYAR);
    }

    public async Task Kirim(Pengiriman dataPengiriman)
    {
        if(await DbContext.Pengirimen.AnyAsync(x=>x.IdOrder == dataPengiriman.IdOrder))
        {
            throw new InvalidOperationException("Pengiriman sudah dilakukan");
        }

        await DbContext.AddAsync(dataPengiriman);
        await DbContext.SaveChangesAsync();
    }

    public async Task Ulas(Ulasan ulasan)
    {
        if(await DbContext.Ulasans.AnyAsync(x=>x.IdOrder == ulasan.IdOrder))
        {
            throw new InvalidOperationException("Anda sudah memberikan review");
        }

        await DbContext.AddAsync(ulasan);
        await DbContext.SaveChangesAsync();
    }
}