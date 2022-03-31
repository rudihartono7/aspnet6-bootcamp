using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class ProdukDetailViewModel: ProdukViewModel
{
    public ProdukDetailViewModel()
    {
        Kategories = new List<KategoriViewModel>();
    }

    public ProdukDetailViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        Id = id;
        Nama = nama;
        Harga = harga;
        Kategories = new List<KategoriViewModel>();
    }
    public string Deskripsi { get; set; }
    public int Stok { get; set; }
    public int Terjual { get; set; }
}