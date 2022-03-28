namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
public interface IProdukService : ICrudService<Produk>
{
    Task<Produk> Add(Produk obj, int idKategori);
}