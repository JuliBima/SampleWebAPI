using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Domain
{
    public class Katalog
    {
        public int KatalogId { get; set; }
        public string Name { get; set; }

        public List<Produk> Produks { get; set; } = new List<Produk> ();
        //public int ProdukId { get; set; }
    }
}
