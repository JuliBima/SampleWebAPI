﻿using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebAPI.Data.DAL
{
    public class RegistrasiDAL : IRegistrasi
    {
        private readonly SamuraiContext _context;
        public RegistrasiDAL(SamuraiContext context)
        {
            _context = context;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var results = await _context.Users.ToListAsync();
            return results;
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Insert(User obj)
        {
            try
            {
                _context.Users.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<User> Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
