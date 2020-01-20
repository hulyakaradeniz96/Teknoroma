using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");
            Property(x => x.Description).IsOptional().HasMaxLength(255);
            Property(x => x.Name).IsRequired().HasMaxLength(60).HasColumnName("CategoryName");
        }
    }
}
