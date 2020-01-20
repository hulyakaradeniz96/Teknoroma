using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.MODEL.Entity.Expenses
{
    public interface IExpense
    {
        decimal PaidAmount { get; set; }
    }
}
