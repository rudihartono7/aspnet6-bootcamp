namespace Trisatech.Kamlinko.WebApp.Interfaces;
using Trisatech.Kamlinko.WebApp.Datas.Entities;
public interface IProdukKategoriService
{
    Task<int[]> GetKategoriIds(int produkId);
    Task Remove(int produkId, int idKategori);
}