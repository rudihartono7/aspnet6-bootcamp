namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
public interface IAccountService
{
    Task<Admin> Login(string username, string password);    
}
