namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using Trisatech.Kamlinko.WebApp.ViewModels;

public interface IOrderService
{
    Task<Order> Checkout(Order newOrder);
    Task<List<OrderViewModel>> Get(int idCustomer);
    Task<List<OrderViewModel>> GetV1(int limit, int offset, int? status, DateTime? date);
    Task<List<OrderViewModel>> GetV2(int limit, int offset, int? status, DateTime? date);
    Task<List<OrderViewModel>> GetV3(int limit, int offset, int? status = null, DateTime? date = null);    
}
