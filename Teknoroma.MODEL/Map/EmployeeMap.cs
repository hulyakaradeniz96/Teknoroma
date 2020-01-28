using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class EmployeeMap : CoreMap<Employee>
    {
        public EmployeeMap()
        {
            ToTable("Employees");
            Property(x => x.Password).IsRequired().HasMaxLength(15);
            Property(x => x.Name).HasColumnName("FirstName").IsRequired().HasMaxLength(20);
            Property(x => x.LastName).IsRequired().HasMaxLength(20);
            Property(x => x.Salary).IsOptional();
            Property(x => x.SalesQuota).IsOptional();

        }
    }
}
