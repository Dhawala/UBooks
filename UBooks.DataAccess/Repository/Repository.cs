using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UBooks.DataAccess.Repository.IRepository;

namespace UBooks.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        ApplicationDbContext _db;
        DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(string? includes = null)
        {
            return dbSet.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includes = null)
        {
            return dbSet.Where(filter).FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<T> entityList)
        {
            dbSet.RemoveRange(entityList);
            _db.SaveChanges();
        }
    }
}
