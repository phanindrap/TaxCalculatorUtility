using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaxCalculatorUtility;

namespace WinFormForTestCalculator
{
    public partial class Form1 : Form
    {
        ITaxCalculator m_TaxCalculator;
        public Form1()
        {
            InitializeComponent();
            m_TaxCalculator = new TaxCalculator();
            LoadComboBoxItems();
        }

        private void LoadComboBoxItems()
        {
            List<string> basketLists = new List<string>();
            basketLists.Add("Select Basket");
            basketLists.Add("Basket 1");
            basketLists.Add("Basket 2");
            basketLists.Add("Basket 3");
            comboBox1.DataSource = basketLists;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int item = comboBox1.SelectedIndex;
            OrderBasket order = new OrderBasket();
            switch (item)
            {
                case 1:
                    GetOrderItems(order);
                    break;
                case 2:
                    GetOrderBasket2Items(order);
                    break;
                case 3:
                    GetOrderBasket3Items(order);
                    break;
                default:
                    break;
            }
            
            OrderReciept response = m_TaxCalculator.TaxCalculation(order);

            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Item", typeof(string));
            dtResult.Columns.Add("Item qty", typeof(string));
            dtResult.Columns.Add("Item price", typeof(string));
            if (response.IsTaxCalculationDone)
            {
                DataRow row;
                foreach (TaxRequestItem taxitem in response.TaxRequestItems)
                {
                    row = dtResult.NewRow();
                    row["Item"] = taxitem.Item;
                    row["Item qty"] = taxitem.ItemQuantity;
                    row["Item price"] = taxitem.Price;
                    dtResult.Rows.Add(row);
                }
                row = dtResult.NewRow();
                row["Item qty"] = "sales tax";
                row["Item price"] = response.SalesTax;
                dtResult.Rows.Add(row);
                row = dtResult.NewRow();
                row["Item qty"] = "Total Price";
                row["Item price"] = response.TotalPrice;
                dtResult.Rows.Add(row);
            }
            dataGridView1.DataSource = dtResult;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                MessageBox.Show("please select valid basket!");
            int item = comboBox1.SelectedIndex;
            OrderBasket order = new OrderBasket();
            switch (item)
            {
                case 1:
                    GetOrderItems(order);
                    break;
                case 2:
                    GetOrderBasket2Items(order);
                    break;
                case 3:
                    GetOrderBasket3Items(order);
                    break;
                default:
                    break;
            }
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("Item", typeof(string));
            dtResult.Columns.Add("Item qty", typeof(string));
            dtResult.Columns.Add("Item price", typeof(string));
            DataRow row;
            foreach (TaxRequestItem taxitem in order.Items)
            {
                row = dtResult.NewRow();
                row["Item"] = taxitem.Item;
                row["Item qty"] = taxitem.ItemQuantity;
                row["Item price"] = taxitem.Price;
                dtResult.Rows.Add(row);
            }
            dataGridView2.DataSource = dtResult;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
