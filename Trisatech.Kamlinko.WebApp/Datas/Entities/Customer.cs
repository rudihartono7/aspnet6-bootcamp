using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Alamats = new HashSet<Alamat>();
            Keranjangs = new HashSet<Keranjang>();
            Orders = new HashSet<Order>();
            Pembayarans = new HashSet<Pembayaran>();
            Ulasans = new HashSet<Ulasan>();
        }

        public int Id { get; set; }
        public string Nama { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NomorHp { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string GambarProfil { get; set; } = null!;

        public virtual ICollection<Alamat> Alamats { get; set; }
        public virtual ICollection<Keranjang> Keranjangs { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Pembayaran> Pembayarans { get; set; }
        public virtual ICollection<Ulasan> Ulasans { get; set; }
    }
}
