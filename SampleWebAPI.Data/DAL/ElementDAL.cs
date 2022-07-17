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
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

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

        public Task<Element> Insert(Element obj)
        {
            throw new NotImplementedException();
        }

        public Task<Element> Update(Element obj)
        {
            throw new NotImplementedException();
        }
    }
}
