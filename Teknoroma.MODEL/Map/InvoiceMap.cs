using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Map;
using Teknoroma.MODEL.Entity;

namespace Teknoroma.MODEL.Map
{
    public class InvoiceMap : CoreMap<Invoice>
    {

        public InvoiceMap()
        {
            //Required for an invoice tp be an invoice
            //name =>Seri
            //ID => Sıra
            //CreatedDate => DateOfIssue
            ToTable("Invoices");
            Property(x => x.DeliveryDate).IsOptional();
            Property(x => x.CreatedDate).IsRequired().HasColumnName("DateOfIssue");
            Property(x => x.Name).IsRequired();
        }
    }
}
