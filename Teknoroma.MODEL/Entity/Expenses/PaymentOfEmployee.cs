using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity.Expenses
{
    public class PaymentOfEmployee : CoreEntity, IExpense
    {
        //name => Explanation
        public decimal PaidAmount { get; set; } //PaidAmount
        public int? EmployeeID { get; set; }

        public virtual Employee Employee { get; set; } //PaidTo
    }
}
