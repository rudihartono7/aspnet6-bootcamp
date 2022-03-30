using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Trisatech.Kamlinko.WebApp.Services;
public class ProdukKategoriService : BaseDbService, IProdukKategoriService
{
    public ProdukKategoriService(KamlinkoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<int[]> GetKategoriIds(int produkId)
    {
        var result = await DbContext.ProdukKategoris
        .Where(x=>x.IdProduk == produkId)
        .Select(x=>x.IdKategori)
        .Distinct()
        .ToArrayAsync();

        return result;
    }

    public async Task Remove(int produkId, int idKategori)
    {
        var item = await DbContext.ProdukKategoris.FirstOrDefaultAsync(x => x.IdProduk == produkId && x.IdKategori == idKategori);
        
        if(item == null)
        {
            return;
        }
        
        DbContext.ProdukKategoris.Remove(item);

        await DbContext.SaveChangesAsync();
    }
}