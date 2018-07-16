using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorUtility
{
    /// <summary>
    /// 
    /// </summary>
    public class TaxRequestItem
    {
        public string Item { set; get; }
        public int ItemQuantity { set; get; }
        public double Price { set; get; }
        public bool IsImported { set; get; }
        public ItemType ItemType { set; get; }
    }

  public enum ItemType
    {
        Book,
        Food,
        Medical,
        Others
    }


}
