using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Kategori
    {
        public Kategori()
        {
            ProdukKategoris = new HashSet<ProdukKategori>();
            Nama = string.Empty;
            Deskripsi = string.Empty;
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Deskripsi { get; set; } = null!;
        public string? Icon { get; set; }

        public virtual ICollection<ProdukKategori> ProdukKategoris { get; set; }
    }
}
