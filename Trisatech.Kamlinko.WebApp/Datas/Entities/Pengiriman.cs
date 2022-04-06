using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Pengiriman
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public string Kurir { get; set; } = null!;
        public string NoResi { get; set; } = null!;
        public decimal Ongkir { get; set; }
        public int IdAlamat { get; set; }
        public string Status { get; set; } = null!;
        public string Keterangan { get; set; } = null!;

        public virtual Alamat IdAlamatNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
