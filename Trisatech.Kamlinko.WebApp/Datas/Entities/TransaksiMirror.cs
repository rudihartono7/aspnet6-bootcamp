using System;
using System.Collections.Generic;

namespace Trisatech.Kamlinko.WebApp.Datas.Entities
{
    public partial class TrannsaksiMirror
    {
        public TrannsaksiMirror()
        {
            
        }

        public int Id { get; set; }
        public string Nama { get;set; }
        public int IdOrder {get; set;}

        public virtual Order Order { get; set; } = null!;
    }
}
