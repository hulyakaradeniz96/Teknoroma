using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity.Expenses
{
    public class OtherExpense : CoreEntity, IExpense
    {
        //name => Explanation
        public string PaidOutTo { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
