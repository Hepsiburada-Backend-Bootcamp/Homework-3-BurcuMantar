using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EFRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        private readonly ProjectDbContext _db;

        public EFRepository(ProjectDbContext db)
        {
            _db = db;
        }
        public async Task<T> Add(T entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public async Task<T> GetById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public async Task<List<T>> ListAll()
        {
            return _db.Set<T>().ToList();
        }

        public async Task Update(T entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
