using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Data.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T GetByName(string name);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}