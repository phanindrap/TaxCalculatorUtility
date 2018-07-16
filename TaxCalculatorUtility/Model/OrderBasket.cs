using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorUtility
{
    public class OrderBasket
    {
        public List<TaxRequestItem> Items { set; get; }
        public bool IsValidBasket { set; get; }
        public OrderBasket()
        {
            Items = new List<TaxRequestItem>();
        }

    }

}
