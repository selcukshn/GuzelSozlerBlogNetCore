using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using web.Data.Abstract;

namespace web.Data.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        protected readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {

            return _context.Set<TEntity>().Find(id);

        }

        public TEntity GetByName(string name)
        {

            return _context.Set<TEntity>().Find(name);
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

        }
        public void Delete(TEntity entity)
        {

            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}