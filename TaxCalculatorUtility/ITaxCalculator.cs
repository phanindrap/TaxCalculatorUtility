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
   public interface ITaxCalculator
    {
        OrderReciept TaxCalculation(OrderBasket orderBasket);
    }
    
}
