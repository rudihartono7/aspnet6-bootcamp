using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class ProdukViewModel
{
    public ProdukViewModel()
    {
        Kategories = new List<KategoriViewModel>();   
    }
    public ProdukViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        Id = id;
        Nama = nama;
        Deskripsi = deskripsi;
        Harga = harga;
        Stok = 100;
        KategoriId = Array.Empty<int>();
        Kategories = new List<KategoriViewModel>();
    }
    public int Id { get; set; }
    [Required]
    public string Nama { get; set; } = null!;
    public string Deskripsi { get; set; } = null!;
    [Required]
    public decimal Harga { get; set; }
    public int Stok { get; set; }
    public string? Gambar { get; set; }
    public int[] KategoriId { get; set; }
    public List<KategoriViewModel> Kategories { get; set; }

    public Produk ConvertToDbModel(){
        return new Produk() {
            Id = this.Id,
            Nama = this.Nama,
            Deskripsi = this.Deskripsi,
            Harga = this.Harga,
            Gambar = this.Gambar ?? string.Empty,
            Stok = this.Stok
        };
    }
}