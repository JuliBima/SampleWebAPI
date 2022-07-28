using EcommerceWebAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebAPI.Data.DAL
{
    public class RegistrasiDAL : IRegistrasi
    {
        private readonly EcommerceContex _context;
        public RegistrasiDAL(EcommerceContex context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var delete = await _context.Users.FirstOrDefaultAsync(s => s.Id == id);
                if (delete == null)
                    throw new Exception($"Data dengan id {id} tidak ditemukan");
                _context.Users.Remove(delete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var user = await _context.Users.OrderBy(q => q.Id).ToListAsync();
            return user;
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

        public async Task<User> Update(User obj)
        {
            try
            {
                var update = await _context.Users.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (update == null)
                    throw new Exception($"Data dengan id {obj.Id} tidak ditemukan");

                update.FirstName = obj.FirstName;
                update.LastName = obj.LastName;
                update.Alamat = obj.Alamat;
                update.Username = obj.Username;
                update.Password = obj.Password;
                update.Role = obj.Role;
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
