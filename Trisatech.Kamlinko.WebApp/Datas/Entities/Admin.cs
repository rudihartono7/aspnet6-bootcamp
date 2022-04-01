using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Nama { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? NomorHp { get; set; }
        public string? Email { get; set; }
    }
}
