using System.ComponentModel.DataAnnotations;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class BayarRequestViewModel {
    public BayarRequestViewModel()
    {
        
    }
    [Required]
    public int IdOrder { get; set; }
    [Required]
    public DateTime TglBayar { get; set; }
    [Required]
    public decimal JmlBayar { get; set; }
    [Required]
    public string Method { get; set; }
    [Required]
    public string IdTujuan { get; set;}
    public string? Note { get; set; }
    [Required]
    public IFormFile FileBuktiBayar { get; set; }
}
