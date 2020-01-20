using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.MODEL.Entity;
using Teknoroma.SERVICE.Base;

namespace Teknoroma.SERVICE.Option
{
    public class ProductService:BaseService<Product>
    {
        //Product has own Statu which needs to be changed after Removing or Updating
        public void RemoveProduct(Product item)
        {
            item.Statu = CORE.Entity.Enum.Status.Deleted;
            Update(item);
        }
        public void RemoveAllProduct(Expression<Func<Product, bool>> exp)
        {
            foreach (var item in GetDefault(exp))
            {
                item.Statu = CORE.Entity.Enum.Status.Deleted;
                Update(item);
            }
        }
        public void RemoveProduct(int id)
        {
            Product item = GetById(id);
            item.Statu = CORE.Entity.Enum.Status.Updated;
            Update(item);
        }
    }
}
