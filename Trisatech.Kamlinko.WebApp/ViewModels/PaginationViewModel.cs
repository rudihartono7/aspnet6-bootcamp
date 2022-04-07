namespace Trisatech.Kamlinko.WebApp.ViewModels;
public class PaginationViewModel
{
    public PaginationViewModel()
    {
        Label = "Home";
        Action = "Index";
        Controller = "Home";
    }
    public string Label { get; set; }
    public string Action { get; set; }
    public string Controller { get; set; }
    public int PageIndex { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
    public int TotalData { get; set; }
}