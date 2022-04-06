using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Pembayaran
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public DateTime TglBayar { get; set; }
        public decimal JmlBayar { get; set; }
        public decimal Pajak { get; set; }
        public string Metode { get; set; } = null!;
        public int IdCustomer { get; set; }
        public string Status { get; set; } = null!;
        public string? Note { get; set; }
        public string IdTujuan { get; set; } = null!;
        public string? FileBuktiBayar { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual Order IdOrderNavigation { get; set; } = null!;
    }
}
