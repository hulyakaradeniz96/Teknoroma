using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity.Expenses;

namespace Teknoroma.MODEL.Map.ExpenseMap
{
    public class TechnicalInfrastructureMap : CoreMap<TechnicalInfrastructure>
    {
        public TechnicalInfrastructureMap()
        {
            ToTable("TechnicalInfrastructures");
            Property(x => x.PaidAmount).IsRequired();
            Property(x => x.Type).IsRequired();
            Property(x => x.Name).HasColumnName("Explanation").IsOptional();
        }
    }
}
