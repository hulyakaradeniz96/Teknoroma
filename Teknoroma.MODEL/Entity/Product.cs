﻿using System;
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
            ControlBarcode(barcode); //if exists before??
        }
        public void ControlBarcode(string barcode)
        {
            if (barcodeArray.Count == 0)
            {
                CreateBarcode(barcode);
                
            }
            else
            {
                foreach (String item in barcodeArray)
                {
                    if (barcode == item && barcodeArray.Count != 1) //if count==0 =>it already creates one.
                    {
                        GenerateBarcode();
                    }
                    else if (barcode != item)
                    {
                        CreateBarcode(barcode);
                    }
                }
            }

        }
        public void CreateBarcode(string barcode)
        {
            Barcode = barcode;
            barcodeArray.Add(barcode);
        }

        public string Barcode { get; set; }

        public string QuantityPerUnit { get; set; } //2kg. box etc.
        public decimal? UnitPrice { get; set; }
        public short? UnitInStock { get; set; }

        public short CriticLevel { get; set; }
        public int? CategoryID { get; set; }
        public int? SupplierID { get; set; }



        //Every product has one Category
        //Every product has one Supplier
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
