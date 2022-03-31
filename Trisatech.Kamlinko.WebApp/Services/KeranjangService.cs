using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.ViewModels;
using System.Linq;

namespace Trisatech.Kamlinko.WebApp.Services;
public class KeranjangService : BaseDbService, IKeranjangService
{
    private readonly IProdukService _produkService;
    public KeranjangService(KamlinkoDbContext dbContext, IProdukService produkService
    ) : base(dbContext)
    {
        _produkService = produkService;
    }

    public async Task<Keranjang> Add(Keranjang obj)
    {
        if(await DbContext.Keranjangs.AnyAsync(x=>x.IdProduk == obj.IdProduk && x.IdCustomer == obj.IdCustomer))
        {
            return obj;
        }

        //get data produk
        var produk = await _produkService.Get(obj.IdProduk);

        if(produk == null)
        {
            throw new InvalidOperationException("Produk tidak ditemukan");
        }

        if(obj.JmlBarang < 1) 
        {
            obj.JmlBarang = 1;
        }

        //rumus subtotal = harga * jumlah produk
        obj.Subtotal = produk.Harga * obj.JmlBarang;

        await DbContext.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        return obj;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Keranjang>> Get(int limit, int offset, string keyword)
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang?> Get(Expression<Func<Keranjang, bool>> func)
    {
        throw new NotImplementedException();
    }

    public Task<List<Keranjang>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Keranjang> Update(Keranjang obj)
    {
        throw new NotImplementedException();
    }

    async Task<List<KeranjangViewModel>> IKeranjangService.Get(int idCustomer)
    {
        var result = await (from a in DbContext.Keranjangs
        join b in DbContext.Produks on a.IdProduk equals b.Id
        where a.IdCustomer == idCustomer
        select new KeranjangViewModel 
        {
            Id = a.Id,
            IdCustomer = a.IdCustomer,
            IdProduk = a.IdProduk,
            Image = b.Gambar,
            JmlBarang  = a.JmlBarang,
            Subtotal  = a.Subtotal,
            NamaProduk = b.Nama
        }).ToListAsync();

        return result;
    }
}