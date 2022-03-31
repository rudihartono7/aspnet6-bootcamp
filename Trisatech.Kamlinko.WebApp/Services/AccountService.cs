using Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Trisatech.Kamlinko.WebApp.ViewModels;

namespace Trisatech.Kamlinko.WebApp.Services;
public class AccountService : BaseDbService, IAccountService
{
    public AccountService(KamlinkoDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Admin> Login(string username, string password)
    {
        var result = await DbContext.Admins.FirstOrDefaultAsync(x=>x.Username == username && x.Password == password);

        return result;
    }

    public async Task<Customer> LoginCustomer(string username, string password)
    {
        return await DbContext.Customers.FirstOrDefaultAsync(x=>x.Username == username && x.Password == password);
    }

    public async Task<Customer> Register(RegisterViewModel request){
        //check username sudah ada atau belum di db
        if(await DbContext.Customers.AnyAsync(x=>x.Username == request.Username)){
            throw new InvalidOperationException($"{request.Username} already exist");
        }

        //check email exist or not
        if(await DbContext.Customers.AnyAsync(x=>x.Email == request.Email)){
            throw new InvalidOperationException($"{request.Email} already exist");
        }
        
        //check nohp exist or not
        if(await DbContext.Customers.AnyAsync(x=>x.NomorHp == request.NomorHp)){
            throw new InvalidOperationException($"{request.NomorHp} already exist");
        }

        var newCustomer = request.ConvertToDataModel();
        await DbContext.Customers.AddAsync(newCustomer);

        await DbContext.SaveChangesAsync();

        return newCustomer; 
    }
}