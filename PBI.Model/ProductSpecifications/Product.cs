using System;
using PBI.Model.Accounting;

namespace PBI.Model.ProductSpecifications
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int FactorId { get; set; }
        public virtual Factor Factor { get; set; }
    }
}