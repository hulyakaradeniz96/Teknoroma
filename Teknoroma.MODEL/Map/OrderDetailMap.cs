using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Property(x => x.Name).HasColumnName("Explanation").IsOptional().HasMaxLength(150);
            
        }
    }
}
