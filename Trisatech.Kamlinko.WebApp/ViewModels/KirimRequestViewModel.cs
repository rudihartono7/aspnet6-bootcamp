using System.ComponentModel.DataAnnotations;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class KirimRequestViewModel {
    public KirimRequestViewModel()
    {
        
    }
    [Required]
    public int IdOrder { get; set; }
    [Required]
    public decimal Ongkir { get; set; }
    [Required]
    public string Kurir { get; set; }
    [Required]
    public int IdAlamat { get; set;}
    [Required]
    public string NoResi { get; set; }
    public string Keterangan { get; set; }
}
