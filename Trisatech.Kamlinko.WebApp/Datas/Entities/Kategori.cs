﻿using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Kategori
    {
        public Kategori()
        {
            ProdukKategoris = new HashSet<ProdukKategori>();
        }

        public int Id { get; set; }
        public int Nama { get; set; }
        public string Deskripsi { get; set; } = null!;
        public string? Icon { get; set; }

        public virtual ICollection<ProdukKategori> ProdukKategoris { get; set; }
    }
}