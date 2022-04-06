using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Order
    {
        public Order()
        {
            Pembayarans = new HashSet<Pembayaran>();
            Pengirimen = new HashSet<Pengiriman>();
            DetailOrders = new HashSet<DetailOrder>();
            Ulasans = new HashSet<Ulasan>();
        }

        public int Id { get; set; }
        public DateTime TglTransaksi { get; set; }
        public decimal JmlBayar { get; set; }
        public int IdAlamat { get; set; }
        public int IdCustomer { get; set; }
        public string? Note { get; set; }
        public int Status { get; set; }

        public virtual Alamat IdAlamatNavigation { get; set; } = null!;
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual StatusOrder StatusNavigation { get; set; } = null!;
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
        public virtual ICollection<Pengiriman> Pengirimen { get; set; }
        public virtual ICollection<DetailOrder> DetailOrders { get; set; }
        public virtual ICollection<Ulasan> Ulasans { get; set; }
    }
}
