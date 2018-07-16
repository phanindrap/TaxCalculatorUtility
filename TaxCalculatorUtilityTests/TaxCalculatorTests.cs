using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxCalculatorUtility.Tests
{
    [TestClass()]
    public class TaxCalculatorTests
    {
        [TestMethod()]
        public void TaxCalculationForBasket1()
        {
            OrderBasket order = new OrderBasket();
            GetOrderItems(order);
            ITaxCalculator obj = new TaxCalculator();
            OrderReciept response = obj.TaxCalculation(order);
            Assert.IsNotNull(response);
            Assert.AreNotSame(response.IsTaxCalculationDone, true);
            Assert.AreNotSame(response.TotalPrice, 29.83);
            // Assert.Fail();
        }
        [TestMethod()]
        public void TaxCalculationForBasket2()
        {
            OrderBasket order = new OrderBasket();
            GetOrderBasket2Items(order);
            ITaxCalculator obj = new TaxCalculator();
            OrderReciept response = obj.TaxCalculation(order);
            Assert.IsNotNull(response);
            Assert.AreNotSame(response.IsTaxCalculationDone, true);
            Assert.AreNotSame(response.TotalPrice, 29.83);
        }


        [TestMethod()]
        public void TaxCalculationForBasket3()
        {
            OrderBasket order = new OrderBasket();
            GetOrderBasket3Items(order);
            ITaxCalculator obj = new TaxCalculator();
            OrderReciept response = obj.TaxCalculation(order);
            Assert.IsNotNull(response);
            Assert.AreNotSame(response.IsTaxCalculationDone, true);
            Assert.AreNotSame(response.TotalPrice, 0.00);
        }

        private static void GetOrderItems(OrderBasket order)
        {
            TaxRequestItem item1 = new TaxRequestItem();
            item1.Item = "book";
            item1.ItemType = ItemType.Book;
            item1.Price = 12.49;
            item1.ItemQuantity = 1;
            item1.IsImported = false;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "Music CD ";
            item1.ItemType = ItemType.Others;
            item1.Price = 14.99;
            item1.ItemQuantity = 1;
            item1.IsImported = false;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "Choacolate bar ";
            item1.ItemType = ItemType.Food;
            item1.Price = 0.85;
            item1.ItemQuantity = 1;
            item1.IsImported = false;
            order.Items.Add(item1);
        }

        private static void GetOrderBasket2Items(OrderBasket order)
        {
            TaxRequestItem item1 = new TaxRequestItem();
            item1.Item = "box of chacolate";
            item1.ItemType = ItemType.Food;
            item1.Price = 10.00;
            item1.ItemQuantity = 1;
            item1.IsImported = true;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "bottle of perfume";
            item1.ItemType = ItemType.Others;
            item1.Price = 47.50;
            item1.ItemQuantity = 1;
            item1.IsImported = true;
            order.Items.Add(item1);
        }

        private static void GetOrderBasket3Items(OrderBasket order)
        {
            TaxRequestItem item1 = new TaxRequestItem();
            item1 = new TaxRequestItem();
            item1.Item = "Imported bottle of perfume";
            item1.ItemType = ItemType.Others;
            item1.Price = 27.99;
            item1.ItemQuantity = 1;
            item1.IsImported = true;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "bottle of perfume";
            item1.ItemType = ItemType.Others;
            item1.Price = 18.99;
            item1.ItemQuantity = 1;
            item1.IsImported = false;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "packate of headache pills";
            item1.ItemType = ItemType.Medical;
            item1.Price = 9.75;
            item1.ItemQuantity = 1;
            item1.IsImported = false;
            order.Items.Add(item1);
            item1 = new TaxRequestItem();
            item1.Item = "Imported box of chacolates";
            item1.ItemType = ItemType.Medical;
            item1.Price = 11.25;
            item1.ItemQuantity = 1;
            item1.IsImported = true;
            order.Items.Add(item1);
        }
    }
}