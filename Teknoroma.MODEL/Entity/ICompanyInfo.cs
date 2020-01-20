using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknoroma.MODEL.Entity
{
    public interface ICompanyInfo
    {
        string ContactName { get; set; }
        string ContactTitle { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string Fax { get; set; }
    }
}
