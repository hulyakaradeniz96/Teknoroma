﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;

namespace Teknoroma.MODEL.Entity
{
    public class Invoice : CoreEntity
    {
        //name =>Seri
        //ID => Sıra
        //CreatedDate => DateOfIssue
        public virtual DateTime DeliveryDate { get; set; }
        public int? OrderID { get; set; }


        //every invoice has its own order
        public virtual Order Order { get; set; }
        //Caution: Do I get all the informations I need?
        /*
         * What I need?
         * Employee infos
         * Customer infos
         */
    }
}
