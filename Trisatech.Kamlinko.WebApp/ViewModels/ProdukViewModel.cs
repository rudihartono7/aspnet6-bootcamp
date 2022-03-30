using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class ProdukViewModel: ProdukBaseViewModel
{
    public ProdukViewModel()
    {
        Kategories = new List<KategoriViewModel>();
    }

    public ProdukViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        Id = id;
        Nama = nama;
        Harga = harga;
        Kategories = new List<KategoriViewModel>();
    }
    public List<KategoriViewModel> Kategories { get; set; }

    public Produk ConvertToDbModel(){
        return new Produk() {
            Id = this.Id,
            Nama = this.Nama,
            Harga = this.Harga,
            Gambar = this.Gambar ?? string.Empty,
        };
    }
}