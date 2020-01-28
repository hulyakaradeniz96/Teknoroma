using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;
using Teknoroma.CORE.Entity.Enum;

namespace Teknoroma.MODEL.Entity
{
   
    public class Employee : CoreEntity
    {
        //Name:FirstName
        public string LastName { get; set; }

        public string Password { get; set; }


        public EmployeeTitle Title { get; set; }
    public Nullable<int> CashierID
        {
            get
            {
                if (Title == EmployeeTitle.CashierSalesRepresentative)
                {
                    cashierNumber++;
                    return cashierNumber;
                }
                return null;
            }
            set
            {

            }
        }

            //If a saler overcome the 10.000 TL s/he gets premium within the TotalWage.
        public decimal? Salary { get; set; }

        //read only (none can set it) //calculating overcome according to SalesQuota
        public decimal PremiumSalary
        {
            get
            {
                if (SalesQuota > 10000)
                {
                    double overcome = 10000 - Convert.ToDouble(SalesQuota); //12.000 => 2.000 TL overcomed
                    return Convert.ToDecimal(overcome * (0.10)); //2.000 * 0.10 = 200 TL
                }
                else
                {
                    return 0;
                }
            }
        }
        public decimal? SalesQuota { get; set; } //Satış yaptıkça artmalı.
        public decimal? TotalWage //read only 
        {
            get
            {
                return Salary + PremiumSalary;
            }
        }

        public static int cashierNumber;
    }

}

