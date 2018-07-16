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
    public class OrderReciept
    {
        public List<TaxRequestItem> TaxRequestItems { set; get; }
        public double SalesTax { set; get; }
        public double TotalPrice { set; get; }
        public bool IsTaxCalculationDone { set; get; }
        public Error ErrorInfo { set; get; }

    }
    public class Error
    {
        public string ErrorCode { set; get; }
        public string ErrorMessage { set; get; }
    }
}
