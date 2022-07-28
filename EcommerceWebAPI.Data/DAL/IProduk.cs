using EcommerceWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public interface IProduk : ICrud<Produk>
    {
        Task<Produk> InsertWithType(Produk produk);

        Task AddProdukToExistingKatalog(int produkID, int katalogID);

        Task<IEnumerable<Produk>> GetProdukTypeKatalog();

        Task<IEnumerable<Produk>> GetProdukTypeKatalogPaging(int skip, int take);

        Task<IEnumerable<Produk>> GetProdukByType(string type);
        Task<IEnumerable<Produk>> GetProdukByName(string name);
        Task<IEnumerable<Produk>> GetProdukByHarga(int harga);

        //Task <Keranjang> AddKeranjang(int produkId, int userId, Keranjang jumlahItem);

        Task<Keranjang> AddKeranjang2(Keranjang obj);
    }
}
