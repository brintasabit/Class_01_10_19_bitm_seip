using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopLayer.Model;

namespace CoffeeShopLayer.Repository
{
    
    class OrderRepository
    {
        public DataTable ShowOrder()
        {

            string conn = @"Server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"select * from Item";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            sqlConn.Close();
            return dataTable;


        }
        public DataTable SearchOrder(Item _item)
        {

            string conn = @"Server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"select * from Item where Name='" + _item.SearchName + "'";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);


            sqlConn.Close();

            return dataTable;
        }
        public bool AddInfo(Item _item)
        {

            
                string connectionString = @"Server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = @"insert into Item values('" + _item.Name + "' ," + _item.Price + " )";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                int isExecuted = sqlCommand.ExecuteNonQuery();
                if (isExecuted > 0)
                {
                    return true;
                }

                sqlConnection.Close();
               
            
           
            return false;






        }
        public bool UpdateItem(Item _item)
        {


            string conn = @"Server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"update Item set Name='" + _item.Name + "',Price= "+_item.Price+" where ID=" + _item.Id + "";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            bool isExecuted = Convert.ToBoolean(sqlCommand.ExecuteNonQuery());
            if (isExecuted)
            {
                string command2 = @"select * from Item where Name='" + _item.Name + "'";
                SqlCommand sqlCommand2 = new SqlCommand(command2, sqlConn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                // customerDataGridView.DataSource = dataTable;

            }
            else
            {
                // MessageBox.Show("Can Not Update");
            }
            sqlConn.Close();


            return false;
        }

        public bool DeleteItem(Item _item)
        {
            string conn = @"Server=PC-301-29\SQLEXPRESS; Database=CoffeeShop; Integrated Security=true";
            SqlConnection sqlConn = new SqlConnection(conn);
            string command = @"delete from Item where ID=" + _item.Id + "";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConn);
            sqlConn.Open();
            int isExecuted=sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                return true;
            }
            else
            {
               
            }
            sqlConn.Close();
            return false;
        }
    }
}
