﻿using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class SwordsDAL : ISword
    {

        private readonly SamuraiContext _context;
        public SwordsDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task AddExistingSword(int swordID, int elemenID)
        {
            var sword = _context.Swords.FirstOrDefault(s => s.Id == swordID);
            var element = _context.Elements.FirstOrDefault(s => s.ElementId == elemenID);
            

            element.Swords.Add(sword);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSword == null)
                    throw new Exception($"Data Sword dengan id {id} tidak ditemukan");
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }



        //public async Task<Sword> ExistingSword(Sword obj)
        //{

        //    try
        //    {
        //        var sword = _context.Swords.Find(obj.Id);
        //        var element = _context.Elements.Find(obj.ElementId);

        //        element.Swords.Add(sword);

        //        await _context.SaveChangesAsync();
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"{ex.Message}");
        //    }

        //}

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var results = await _context.Swords.OrderBy(s => s.Weight).ToListAsync();
            return results;
        }

        public Task<Sword> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var swords = await _context.Swords.Where(s => s.Name.Contains(name))
               .OrderBy(s => s.Name).ToListAsync();
            return swords;
        }


        public async Task<IEnumerable<Sword>> GetWithType(int skip, int take)

        {
            var swordWithtype = await _context.Swords.Include(s => s.TypeSwords)
                .Skip(skip).Take(take).ToArrayAsync();
            return swordWithtype;
            
        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Sword> InsertWithType(Sword sword)
        {
            try
            {
                _context.Swords.Add(sword);
                await _context.SaveChangesAsync();
                return sword;
               
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var updateSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateSword == null)
                    throw new Exception($"Data Sword dengan id {obj.Id} tidak ditemukan");

                updateSword.Name = obj.Name;
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
