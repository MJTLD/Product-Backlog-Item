using System;

namespace PBI.Model.Accounting
{
    public class Purchaser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FactorId { get; set; }
        public virtual Factor Factor { get; set; }
    }
}