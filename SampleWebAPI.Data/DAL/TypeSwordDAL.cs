using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class TypeSwordDAL : ITypeSword
    {
        private readonly SamuraiContext _context;
        public TypeSwordDAL(SamuraiContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteTypeSword = await _context.TypeSwords.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteTypeSword == null)
                    throw new Exception($"Data TypeSword dengan id {id} tidak ditemukan");
                _context.TypeSwords.Remove(deleteTypeSword);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<TypeSword>> GetAll()
        {
            var results = await _context.TypeSwords.OrderBy(s => s.Name).ToListAsync();
            return results;
        }

        public Task<TypeSword> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TypeSword> Insert(TypeSword obj)
        {
            try
            {
                _context.TypeSwords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<TypeSword> Update(TypeSword obj)
        {
            try
            {
                var updateTypeSword = await _context.TypeSwords.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateTypeSword == null)
                    throw new Exception($"Data TypeSword dengan id {obj.Id} tidak ditemukan");

                updateTypeSword.Name = obj.Name;
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
