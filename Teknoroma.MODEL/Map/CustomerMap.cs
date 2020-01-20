using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class CustomerMap : CoreMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customers");
            Property(x => x.Name).HasMaxLength(150);
            Property(x => x.ContactName).HasMaxLength(50);
            Property(x => x.ContactTitle).HasMaxLength(20);
            Property(x => x.Phone).HasMaxLength(20);
            Property(x => x.Fax).HasMaxLength(20);
            Property(x => x.Address).HasMaxLength(100);

        }
    }
}
