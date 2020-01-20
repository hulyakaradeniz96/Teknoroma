using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.CORE.Service
{
    public interface ICoreService<T> where T : CoreEntity //BLL Core
    {
        void Add(T item);
        void Add(List<T> items);

        void Update(T item);

        void Remove(T item);

        void Remove(int id);

        //(x=>x.createddate==datetime.now)
        void RemoveAll(Expression<Func<T, bool>> exp);

        T GetById(int id);

        List<T> GetDefault(Expression<Func<T, bool>> exp);

        List<T> GetAll();

        bool Any(Expression<Func<T, bool>> exp);

    }
}
