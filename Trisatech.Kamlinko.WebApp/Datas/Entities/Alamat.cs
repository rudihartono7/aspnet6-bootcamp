using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Alamat
    {
        public Alamat()
        {
            Orders = new HashSet<Order>();
            Pengirimen = new HashSet<Pengiriman>();
        }

        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public string Deskripsi { get; set; } = null!;
        public string Rt { get; set; } = null!;
        public string Rw { get; set; } = null!;
        public string? Kelurahan { get; set; }
        public string? Kecamatan { get; set; }
        public string? Kota { get; set; }
        public string? Provinsi { get; set; }
        public string KodePos { get; set; } = null!;

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Pengiriman> Pengirimen { get; set; }
    }
}
