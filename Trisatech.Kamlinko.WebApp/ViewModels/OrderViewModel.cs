namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class OrderViewModel {
    public OrderViewModel()
    {
        Details = new List<OrderDetailViewModel>();
    }
    public int Id { get; set; }
    public DateTime TglOrder { get; set; }
    public int TotalQty { get {
        return (Details == null || !Details.Any()) ? 0 : Details.Sum(x=>x.Qty);
    }}
    public decimal TotalBayar { get; set; }
    public int IdStatus {get; set;}
    public string Status { get; set; }
    public int IdAlamat { get; set; }
    public string Alamat { get; set; }

    public List<OrderDetailViewModel> Details { get; set; }
    public PembayaranViewModel Pembayaran { get; set; }
    public PengirimanViewModel Pengiriman { get; set; }
}
