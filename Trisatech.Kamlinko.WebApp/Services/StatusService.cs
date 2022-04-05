using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.ViewModels;

namespace Trisatech.Kamlinko.WebApp.Services;
public class StatusService : BaseDbService, IStatusService
{
    public StatusService(KamlinkoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<StatusOrder>> Get()
    {
        return await DbContext.StatusOrders.ToListAsync();
    }
}