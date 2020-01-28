using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity
{
    public class Order : CoreEntity
    {
        //name => ShipCountryName

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        public string ShipAddress { get; set; }

        public int? CustomerID { get; set; }
        public int? EmployeeID { get; set; }


        //Every Order has one Customer
        public virtual Customer Customer { get; set; }

        //Every Order has own Employeer (Creater)
        public virtual Employee Employee { get; set; } //employer is a saler which an only one can make the order ready. CashierNumber is also reachable +


        //Every Order has one or more OrderDetail inside(more than one product and its features inside of it)
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}
