using EcommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public class ProdukDAL : IProduk
    {
        private readonly EcommerceContex _context;
        public ProdukDAL(EcommerceContex context)
        {
            _context = context;
        }

        //public async Task <Keranjang> AddKeranjang(int produkId, int userId, Keranjang jumlahItem)
        //{
        //    var ambilproduk = _context.Produks.FirstOrDefault(s => s.Id == produkId);
        //    var ambiluser = _context.Users.FirstOrDefault(s => s.Id == userId);

        //    ambiluser.Produks.Add(ambilproduk);
           
        //    //foreach (var item in ambiluser.Produks)
        //      _context.Keranjangs.Add(jumlahItem);

        //    await _context.SaveChangesAsync();
        //    return jumlahItem;
        //}

        public async Task<Keranjang> AddKeranjang2(Keranjang obj)
        {
            _context.Keranjangs.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task AddProdukToExistingKatalog(int produkID, int katalogID)
        {
            var ambilproduk = _context.Produks.FirstOrDefault(s => s.Id== produkID);
            var ambilkatalog = _context.Katalogs.FirstOrDefault(s => s.KatalogId == katalogID);

            ambilkatalog.Produks.Add(ambilproduk);
            //katalogg.Produks.Add(produkk);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteproduk = await _context.Produks.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteproduk == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Produks.Remove(deleteproduk);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Produk>> GetAll()
        {
            var produks = await _context.Produks.OrderBy(q => q.Name).ToListAsync();
            return produks;
            //throw new NotImplementedException();
        }

        public Task<Produk> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produk>> GetProdukByHarga(int harga)
        {

           
            //var produk = await _context.Produks.Where(s => s.Harga == harga).Include(s => s.TypeProduk).Include(s => s.Katalogs)
            // .OrderBy(s => s.Name).ToListAsync();
            //return produk;


            var produk = await _context.Produks.Where(s => s.Harga == (harga)).Include(s => s.TypeProduk).Include(s => s.Katalogs)
              .OrderBy(s => s.Name).ToListAsync();
            return produk;
        }

        public async Task<IEnumerable<Produk>> GetProdukByName(string name)
        {
            var produk = await _context.Produks.Where(s => s.Name.Contains(name)).Include(s => s.TypeProduk).Include(s => s.Katalogs)
              .OrderBy(s => s.Name).ToListAsync();
            return produk;
        }

        public async Task<IEnumerable<Produk>> GetProdukByType(string type)
        {
            var produk = await _context.Produks.Include(s => s.TypeProduk).Where(s => s.TypeProduk.Name.Contains(type)).Include(s => s.Katalogs)
              .OrderBy(s => s.Name).ToListAsync();
            return produk;
        }

        public async Task<IEnumerable<Produk>> GetProdukTypeKatalog()
        {
            var produks = await _context.Produks.Include(s => s.TypeProduk).Include(s => s.Katalogs).ToListAsync();

            return produks;
        }

        public async Task<IEnumerable<Produk>> GetProdukTypeKatalogPaging(int skip, int take)
        {
            var produks = await _context.Produks.Include(s => s.TypeProduk).Include(s => s.Katalogs)
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return produks;
        }

        public Task<Produk> Insert(Produk obj)
        {
            throw new NotImplementedException();
        }

        public async Task<Produk> InsertWithType(Produk produk)
        {
            try
            {
                _context.Produks.Add(produk);
                await _context.SaveChangesAsync();
                return produk;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
            //throw new NotImplementedException();
    }

        public async Task<Produk> Update(Produk obj)
        {
            try
            {
                var updateproduk = await _context.Produks.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateproduk == null)
                    throw new Exception($"Data Produk dengan id {obj.Id} tidak ditemukan");

                updateproduk.Name = obj.Name;
                updateproduk.Harga = obj.Harga;
                updateproduk.Berat = obj.Berat;
                updateproduk.Deskripsi = obj.Deskripsi;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


    }
}
