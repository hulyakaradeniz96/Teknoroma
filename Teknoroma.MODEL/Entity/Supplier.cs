using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity
{
    public class Supplier : CoreEntity, ICompanyInfo
    {
        //name =>SupplierCompanyName
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
}
