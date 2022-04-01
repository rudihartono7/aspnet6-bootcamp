using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class KeranjangUpdateViewModel
{
    public KeranjangUpdateViewModel()
    {
    }

    [Required]
    public int Id { get; set; }
    [Required]
    public int JmlBarang { get; set; }
}
