namespace Trisatech.Kamlinko.WebApp.Datas.Entities;
public class Ulasan {
    public Ulasan()
    {
        
    }
    public int Id { get; set; }
    public int IdOrder { get; set; }
    public int IdCustomer { get; set; }
    public string Komentar { get; set; } = null!;
    public string Gambar { get; set; } = null!;
    public int Rating { get; set; }

    public virtual Order Order { get; set; }
    public virtual Customer Customer { get; set; }
}