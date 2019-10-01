using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;


using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopLayer.Bill;
using CoffeeShopLayer.Model;
namespace CoffeeShopLayer
{
    
    public partial class Order : Form
    {
        OrderManager _orderManager = new OrderManager();
        Item _item = new Item();
        public Order()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                _item.Name = nameTextBox.Text;
                _item.Price = Convert.ToInt32(priceTextBox.Text);
                DataTable isSearch = _orderManager.SearchOrder(_item);
                if (isSearch.Rows.Count > 0)
                {

                    //  customerDataGridView.DataSource = _customerManager.SearchCustomer(searchTextBox.Text);
                    MessageBox.Show("Item Name Exists");
                }


                else
                {
                    bool isAdded = _orderManager.AddInfo(_item);
                    MessageBox.Show("Saved");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {
            try
            {
                orderDataGridView.DataSource = _orderManager.ShowOrder();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                _item.SearchName = searchTextBox.Text;
                DataTable isSearch = _orderManager.SearchOrder(_item);
                if (isSearch.Rows.Count > 0)
                {

                    orderDataGridView.DataSource = _orderManager.SearchOrder(_item);
                    MessageBox.Show("Data Found");
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                _item.Name = nameTextBox.Text;
                _item.Price = Convert.ToInt32(priceTextBox.Text);
                _item.Id = Convert.ToInt32(idTextBox.Text);
                bool isUpdated = _orderManager.UpdateItem(_item);
                orderDataGridView.DataSource = _orderManager.ShowOrder();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            
        }
        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                _item.Id = Convert.ToInt32(idTextBox.Text);
                bool isDeleted = _orderManager.DeleteItem(_item);
                if (isDeleted)
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("No Data Found");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
