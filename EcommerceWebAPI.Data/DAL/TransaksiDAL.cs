using EcommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public class TransaksiDAL : ITransaksi
    {
        private readonly EcommerceContex _context;
        public TransaksiDAL(EcommerceContex context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transaksi>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Transaksi> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Transaksi> Insert(Transaksi obj)
        {
            //var ambilproduk = _context.Produks.FirstOrDefault(s => s.Harga == );
            //var ambilproduk = _context.Produks.Sum(s => s.Harga == obj.TotalHarga);
            //var ambilkeranjang = _context.Keranjangs.FirstOrDefault(s => s.Id == obj.Id);

            //obj.TotalHarga = obj.
            


            throw new NotImplementedException();
        }

        public Task<Transaksi> Update(Transaksi obj)
        {
            throw new NotImplementedException();
        }
    }
}
