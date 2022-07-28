using EcommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public class KatalogDAL : IKatalog
    {
        private readonly EcommerceContex _context;
        public KatalogDAL(EcommerceContex context)
        {
            _context = context;
        }

        public async Task AddKatalogExisting(int katalogID, int produkID)
        {
            var element = _context.Katalogs.FirstOrDefault(s => s.KatalogId == katalogID);
            var sword = _context.Produks.FirstOrDefault(s => s.Id == produkID);

            sword.Katalogs.Add(element);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var delete = await _context.Katalogs.FirstOrDefaultAsync(s => s.KatalogId == id);
                if (delete == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Katalogs.Remove(delete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteKatalogProduk(int id)
        {
            var produk = await _context.Produks.Include(b => b.Katalogs).FirstOrDefaultAsync(s => s.Id == id);
            var katalog = produk.Katalogs[0];
            produk.Katalogs.Remove(katalog);
            await _context.SaveChangesAsync();
           

            //var elemet = await _context.Swords.Include(b => b.Elements).FirstOrDefaultAsync(s => s.Id == id);
            //var sword = elemet.Elements[0];
            //elemet.Elements.Remove(sword);
            //await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Katalog>> GetAll()
        {
            var produks = await _context.Katalogs.OrderBy(q => q.Name).ToListAsync();
            return produks;   
        }

        public Task<Katalog> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Katalog> Insert(Katalog obj)
        {

            try
            {
                _context.Katalogs.Add(obj);
                await _context.SaveChangesAsync();
                return obj;

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Katalog> Update(Katalog obj)
        {
            try
            {
                var updatekatalog = await _context.Katalogs.FirstOrDefaultAsync(s => s.KatalogId == obj.KatalogId);
                if (updatekatalog == null)
                    throw new Exception($"Data dengan id {obj.KatalogId} tidak ditemukan");

                updatekatalog.Name = obj.Name;
                
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
