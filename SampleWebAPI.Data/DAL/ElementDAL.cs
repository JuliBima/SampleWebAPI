using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class ElementDAL : IElement
    {
        private readonly SamuraiContext _context;
        public ElementDAL(SamuraiContext context)
        {
            _context = context;
        }

        public async Task AddElementToExistingSword(int elemenID, int swordID)
        {
            var element = _context.Elements.FirstOrDefault(s=>s.ElementId == elemenID);
            var sword = _context.Swords.FirstOrDefault(s => s.Id == swordID);

            sword.Elements.Add(element);

            await _context.SaveChangesAsync();
           
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteElement = await _context.Elements.FirstOrDefaultAsync(s => s.ElementId == id);
                if (deleteElement == null)
                    throw new Exception($"Data Element dengan id {id} tidak ditemukan");
                _context.Elements.Remove(deleteElement);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteElementinSword(int id)
        {
            var elemet = await _context.Swords.Include(b => b.Elements).FirstOrDefaultAsync(s => s.Id == id); 
            var sword = elemet.Elements[0];
            elemet.Elements.Remove(sword);
            await _context.SaveChangesAsync();
        }


        //public async Task<Element> ElementToExistingSword(Element obj)
        //{
        //    try
        //    {

        //        var element = _context.Elements.FirstOrDefault(s => s.ElementId == obj.ElementId);
        //        var sword = _context.Swords.FirstOrDefault(s => s.Id == obj.);

        //        sword.Elements.Add(element);

        //        await _context.SaveChangesAsync();
        //        //var sword = _context.Swords.Find(obj.ElementId);
        //        //if (sword != null)
        //        //{
        //        //    var element = _context.Elements.Find(obj.ElementId);
        //        //    sword.Elements.Add(element);
        //        //    await _context.SaveChangesAsync();
        //        //}
        //        //return obj;


        //        //var element = _context.Elements.Find(obj.ElementId);
        //        //var sword = _context.Swords.Find(obj.ElementId);

        //        //sword.Elements.Add(element);

        //        //await _context.SaveChangesAsync();
        //        //return obj;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"{ex.Message}");
        //    }

        //    //var element = await _context.Elements.FirstOrDefaultAsync(s => s.ElementId == obj.ElementId);
        //    //if (element == null)
        //    //    throw new Exception($"Data Element dengan id {obj.ElementId} tidak ditemukan");

        //    //element.Swords.Add(obj.Id);

        //    //await _context.SaveChangesAsync();
        //    //return obj;

        //    //try
        //    //{

        //    //    _context.Swords.Include(b => b.Elements).ToListAsync();
        //    //    _context.Elements.Add(obj);
        //    //    await _context.SaveChangesAsync();
        //    //    return obj;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new Exception($"{ex.Message}");
        //    //}
        //}

        public async Task<IEnumerable<Element>> GetAll()
        {
            var elements = await _context.Elements.OrderBy(q => q.Name).ToListAsync();
            return elements;
        }

        public Task<Element> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Element>> GetByName(string name)
        {
            var elements = await _context.Elements.Where(s => s.Name.Contains(name))
              .OrderBy(s => s.Name).ToListAsync();
            return elements;
        }

        public async Task<Element> Insert(Element obj)
        {
            try
            {
                _context.Elements.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Element> Update(Element obj)
        {
            try
            {
                var updateElement = await _context.Elements.FirstOrDefaultAsync(s => s.ElementId == obj.ElementId);
                if (updateElement == null)
                    throw new Exception($"Data Element dengan id {obj.ElementId} tidak ditemukan");

                updateElement.Name = obj.Name;
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
