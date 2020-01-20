using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity.Expenses;

namespace Teknoroma.MODEL.Map.ExpenseMap
{
    public class OtherExpenseMap : CoreMap<OtherExpense>
    {
        public OtherExpenseMap()
        {
            Property(x => x.PaidAmount).IsRequired();
            Property(x => x.PaidOutTo).IsRequired().HasMaxLength(70);
            Property(x => x.Name).HasColumnName("Explanation").IsOptional();
        }
    }
}
