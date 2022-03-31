using System.ComponentModel.DataAnnotations;
using Trisatech.Kamlinko.WebApp.Datas.Entities;

namespace Trisatech.Kamlinko.WebApp.ViewModels;

public class RegisterViewModel
{
    public RegisterViewModel()
    {
        Username = string.Empty;
        Password = string.Empty;
    }
    public RegisterViewModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    [Required]
    public string Nama { get; set; } = null!;
    [Required]
    public string NomorHp { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }

    public Customer ConvertToDataModel() {
        return new Customer {
            Nama = this.Nama,
            NomorHp = this.NomorHp,
            Email = this.Email,
            Username = this.Username,
            Password = this.Password,
            GambarProfil = string.Empty
        };
    }
}