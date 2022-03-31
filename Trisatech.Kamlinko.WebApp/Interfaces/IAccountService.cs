namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using Trisatech.Kamlinko.WebApp.ViewModels;

public interface IAccountService
{
    Task<Admin> Login(string username, string password); 
    Task<Customer> LoginCustomer(string username, string password);
    Task<Customer> Register(RegisterViewModel request);    
}
