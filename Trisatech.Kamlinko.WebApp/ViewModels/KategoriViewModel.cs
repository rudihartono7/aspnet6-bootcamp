using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels
{
    public class KategoriViewModel
    {
        public KategoriViewModel()
        {
            Nama = string.Empty;
            Deskripsi = string.Empty;
        }
        public KategoriViewModel(Kategori item) {
            Id = item.Id;
            Nama = item.Nama;
            Deskripsi = item.Deskripsi;
            Icon = item.Icon;
        }
        public int Id { get; set; }
        [Required]
        public string Nama { get; set; }
        public string Deskripsi { get; set; }
        public string? Icon { get; set; }

        public Kategori ConvertToDbModel(){
            return new Kategori {
                Id = this.Id,
                Nama = this.Nama,
                Deskripsi = this.Deskripsi,
                Icon = this.Icon
            };
        }
    }
}
