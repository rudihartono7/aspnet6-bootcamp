using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class ProdukBaseViewModel
{
    public ProdukBaseViewModel()
    {
    }

    public ProdukBaseViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        Id = id;
        Nama = nama;
        Harga = harga;
    }
    public int Id { get; set; }
    public string Nama { get; set; } = null!;
    public decimal Harga { get; set; }
    public string? Gambar { get; set; }
    public string GambarSrc {
        get {
            return (string.IsNullOrEmpty(Gambar) ? "images/default.png" : Gambar );
        }
    }
}