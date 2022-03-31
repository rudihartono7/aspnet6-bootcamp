namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
using Trisatech.Kamlinko.WebApp.ViewModels;

public interface IKeranjangService : ICrudService<Keranjang>
{
    Task<List<KeranjangViewModel>> Get(int idCustomer);   
}