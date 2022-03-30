using System.ComponentModel.DataAnnotations;

namespace Trisatech.Kamlinko.WebApp.ViewModels;

public class AccountLoginViewModel
{
    public AccountLoginViewModel()
    {
        Username = string.Empty;
        Password = string.Empty;
    }
    public AccountLoginViewModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}