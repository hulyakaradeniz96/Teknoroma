using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknoroma.CORE.Entity;
using Teknoroma.CORE.Entity.Enum;

namespace Teknoroma.MODEL.Entity
{
    public class Product : CoreEntity
    {
        //name => ProductName

        ArrayList barcodeArray = new ArrayList();
        public Product()
        {
            GenerateBarcode();
        }
        /// <summary>
        /// It Generates 5 digits number and converts to the string.
        /// </summary>
        /// <returns></returns>
        public string GenerateNumber()
        {
            Random rnd = new Random();
            var rndNumber = rnd.Next(10000, 100000);
            return Convert.ToString(rndNumber);
        }
        /// <summary>
        /// It creates a barcode which is not created before for any of the product.
        /// Barcode is a string value for usage of writing the barCode.
        /// </summary>
        public void GenerateBarcode()
        {
            string barcode = "869";
            barcode += GenerateNumber();
            foreach (string item in barcodeArray)
            {
                if (barcode == item)
                {
                    GenerateBarcode();
                }
                else
                {
                    Barcode = barcode;
                    barcodeArray.Add(barcode);
                }
            }
        }


        public string Barcode { get; set; }

        public string QuantityPerUnit { get; set; } //2kg. box etc.
        public decimal UnitPrice { get; set; }
        public short UnitInStock { get; set; }
        public Status Statu { get; set; }
        public short CriticLevel { get; set; }



        //Every product has one Category
        //Every product has one Supplier
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}
