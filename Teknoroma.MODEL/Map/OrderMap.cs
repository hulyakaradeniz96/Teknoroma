using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class OrderMap : CoreMap<Order>
    {
        public OrderMap()
        {
            Property(x => x.ShipAddress).HasMaxLength(250);
            Property(x => x.Name).HasColumnName("ShipCountryName");
        }
    }
}
