using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Domain
{
    public class Produk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Harga { get; set; }
        public int Berat { get; set; }
        public string Deskripsi { get; set; }

        public TypeProduk TypeProduk { get; set; }
        public List<Katalog> Katalogs { get; set; } = new List<Katalog>();

        public List<User> Users { get; set; } = new List<User>();

    }
}
