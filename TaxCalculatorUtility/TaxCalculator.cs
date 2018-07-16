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
    public class TaxCalculator:ITaxCalculator
    {
        #region private variables
        private int m_importDuty = 5; //5 % of amount
        private int m_salesTax = 10; //10 % of amount
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="taxRequestItems"></param>
        /// <returns></returns>
        public OrderReciept TaxCalculation(OrderBasket orderBasket)
        {
            //
            OrderReciept orderResponse = new OrderReciept();
            try
            {
                orderResponse.TaxRequestItems = new List<TaxRequestItem>();
                //validate basket
                if (orderBasket == null || orderBasket.Items == null)
                {
                    orderResponse.IsTaxCalculationDone = false;
                    return orderResponse;
                }

                //tax calcluation for each item
                
                double totalPrice = 0.0;
                double saleTax = 0.0;
                foreach (TaxRequestItem item in orderBasket.Items)
                {
                    double tax = 0.0;
                    if (item.ItemType == ItemType.Others)
                    {
                        tax += (item.Price / 100) * m_salesTax;
                    }
                    if (item.IsImported)
                    {
                        tax += (item.Price / 100) * m_importDuty;
                    }
                    item.Price = item.Price + Math.Round(tax, 2);
                    totalPrice += item.Price;
                    saleTax += tax;
                    orderResponse.TaxRequestItems.Add(item);
                }
                orderResponse.SalesTax = Math.Round(saleTax, 2);
                orderResponse.TotalPrice = totalPrice;
                orderResponse.IsTaxCalculationDone = true;
            }
            catch(Exception ex)
            {
                orderResponse.ErrorInfo = new Error();
                orderResponse.ErrorInfo.ErrorCode = "1001"; //Exception code
                orderResponse.ErrorInfo.ErrorCode = ex.Message.ToString();
            }
            return orderResponse;
        }
    }
}
