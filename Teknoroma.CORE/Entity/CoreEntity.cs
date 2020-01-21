using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity.Enum;

namespace Teknoroma.CORE.Entity
{
    public class CoreEntity : IEntity
    {
        public CoreEntity()
        {
            this.CreatedDate = DateTime.Now;
            this.CreatedAdUserName = WindowsIdentity.GetCurrent().Name;
            this.CreatedComputerName = Environment.MachineName;
            this.CreatedIP = "192.168.1.1";
        }
        public int ID { get; set; }

        //Durum 
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public string CreatedAdUserName { get; set; }
    }
}
