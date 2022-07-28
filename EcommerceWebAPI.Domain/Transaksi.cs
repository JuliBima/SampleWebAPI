using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Domain
{
    public class Transaksi
    {
        public int Id { get; set; }
        public DateTime DateJoined { get; set; }
        public int TotalHarga { get; set; }
        public Keranjang Keranjang { get; set; }
        public int KeranjangId { get; set; }
    }
}
