using EcommerceWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public interface IKatalog : ICrud<Katalog>
    {
        Task AddKatalogExisting(int katalogID, int produkID);

        Task DeleteKatalogProduk(int id);
    }
}
