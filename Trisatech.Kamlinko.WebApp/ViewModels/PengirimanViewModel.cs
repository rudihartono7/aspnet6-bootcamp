namespace Trisatech.Kamlinko.WebApp.ViewModels
{
    public class PengirimanViewModel
    {
        public int Id { get; set; }
        public string Kurir { get; set; } = null!;
        public string NoResi { get; set; } = null!;
        public decimal Ongkir { get; set; }
        public string Status { get; set; } = null!;
        public string Keterangan { get; set; } = null!;
    }
}
