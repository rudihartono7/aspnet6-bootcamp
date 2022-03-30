using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class ProdukReqViewModel : ProdukBaseViewModel
{
    public ProdukReqViewModel()
    {

    }

    public ProdukReqViewModel(int id, string nama, string deskripsi, decimal harga)
    {
        Id = id;
        Nama = nama;
        Deskripsi = deskripsi;
        Harga = harga;
        Stok = 100;
        KategoriId = Array.Empty<int>();
    }
    [Required]
    public new string Nama { get; set; } = null!;
    public string Deskripsi { get; set; } = null!;
    [Required]
    public new decimal Harga { get; set; }
    public int Stok { get; set; }
    public IFormFile? GambarFile { get; set; }
    public int[] KategoriId { get; set; }
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