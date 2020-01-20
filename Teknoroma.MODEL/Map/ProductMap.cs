using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class ProductMap : CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            Property(x => x.Barcode).HasMaxLength(20).IsRequired();
            Property(x => x.Name).IsRequired();
            //For usage of None Status: UnitPrice,Stock and CriticLevel could not be necessary.
            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.UnitInStock).IsOptional();
            Property(x => x.CriticLevel).IsOptional();
        }
    }
}
