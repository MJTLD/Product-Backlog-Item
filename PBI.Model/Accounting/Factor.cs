using System;
using System.Collections.Generic;
using PBI.Model.ProductSpecifications;

namespace PBI.Model.Accounting
{
    public class Factor
    {
        public int ID { get; set; }
        public string SerialNumber { get; set; }
        public DateTime FactorDate { get; set; }
        public virtual IList<Purchaser> Purchasers { get; set; }
        public virtual IList<Vendor> Vendors { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}