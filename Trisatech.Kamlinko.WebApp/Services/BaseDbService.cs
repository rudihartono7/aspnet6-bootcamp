using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Trisatech.Kamlinko.WebApp.Services;
public class BaseDbService
{
    protected readonly KamlinkoDbContext DbContext;
    public BaseDbService(KamlinkoDbContext dbContext)
    {
        DbContext = dbContext;
    }
}