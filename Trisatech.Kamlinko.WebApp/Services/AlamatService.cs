using System.Linq.Expressions;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using Trisatech.Kamlinko.WebApp.Interfaces;

namespace Trisatech.Kamlinko.WebApp.Services;
public class AlamatService : BaseDbService, IAlamatService
{
    public AlamatService(KamlinkoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Alamat> Add(Alamat obj)
    {
        await DbContext.Alamats.AddAsync(obj);
        await DbContext.SaveChangesAsync();

        return obj;
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Alamat>> Get(int limit, int offset, string keyword)
    {
        throw new NotImplementedException();
    }

    public Task<Alamat?> Get(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Alamat?> Get(Expression<Func<Alamat, bool>> func)
    {
        throw new NotImplementedException();
    }

    public Task<List<Alamat>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Alamat> Update(Alamat obj)
    {
        throw new NotImplementedException();
    }
}