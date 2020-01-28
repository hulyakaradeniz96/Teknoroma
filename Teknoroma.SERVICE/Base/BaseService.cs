using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;
using Teknoroma.CORE.Service;
using Teknoroma.MODEL.Context;

namespace Teknoroma.SERVICE.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        //Singleton
        private static ProjectContext _db;
        public ProjectContext Db
        {

            get
            {
                if (_db == null)
                {
                    _db = new ProjectContext();
                    return _db;
                }
                return _db;
            }
        }

        public void Add(T item)
        {
            Db.Set<T>().Add(item);
            Db.SaveChanges();
        }

        public void Add(List<T> items)
        {
            Db.Set<T>().AddRange(items);
            Db.SaveChanges();
        }

        public bool Any(Expression<Func<T, bool>> exp) => Db.Set<T>().Any(exp);

        public List<T> GetAll()
        {
            return Db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        /// <summary>
        /// According to query, it returns the list of the selected class.
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return Db.Set<T>().Where(exp).ToList();
        }

        public void Remove(T item)
        {
            item.Statu = CORE.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void Remove(int id)
        {
            T item = GetById(id);
            item.Statu = CORE.Entity.Enum.Status.Deleted;
            Update(item);
        }

        public void RemoveAll(Expression<Func<T, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                Update(item);
            }
        }

        public void Update(T item)//chai
        {
            //aşağıdaki işlemde parametreden gelen bilgiler ile veritabanında kayıtlı olan bilgiler kıyaslanarak değişiklikleri güncel şeklinde (CurrentValues) set (ayarla) işlemi gerçekleştirildi.
            T updated = GetById(item.ID);
            item.Statu = CORE.Entity.Enum.Status.Updated;
            DbEntityEntry entry = Db.Entry(updated);
            entry.CurrentValues.SetValues(item);
            Db.SaveChanges();
        }
    }
}
