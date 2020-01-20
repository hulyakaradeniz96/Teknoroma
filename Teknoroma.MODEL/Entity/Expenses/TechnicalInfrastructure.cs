using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;
using Teknoroma.CORE.Entity.Enum;

namespace Teknoroma.MODEL.Entity.Expenses
{
    public class TechnicalInfrastructure : CoreEntity, IExpense
    {
        //name => Explanation

        public InfrastructureTypes Type { get; set; }
        public decimal PaidAmount { get; set; }

    }
}
