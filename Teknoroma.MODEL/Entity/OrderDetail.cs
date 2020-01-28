using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity
{
    public class OrderDetail : CoreEntity
    {
        //name => Explanation
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }


        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
