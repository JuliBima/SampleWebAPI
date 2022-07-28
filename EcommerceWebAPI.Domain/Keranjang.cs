using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Domain
{
    public class Keranjang
    {
        public int Id { get; set; }
        public int JumlahItem { get; set; }
        public int ProdukId { get; set; }
        public int UserId { get; set; }
        public List<Transaksi> Transaksis { get; set; } = new List<Transaksi>();

    }
}
