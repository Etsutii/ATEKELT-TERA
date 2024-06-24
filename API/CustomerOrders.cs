using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEKELT_TERA1.API
{

    internal class CustomerOrders
    {
        static readonly string connectionString = Config.getConnectionString();
        public int id {  get; set; }
        public int customerId { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public int paymentId { get; set; }

        public int CreateCustomerOrder(CustomerOrders customerOrders)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into customers_order values('" + customerOrders.customerId + "', '" +customerOrders.productId + "','" + customerOrders.quantity + "','" + customerOrders.paymentId + "')", connection);
                
               
                return cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally { connection.Close(); }
            return 0;
        }


        public SqlDataReader getAllCustomerOrders()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM customer_order_view", connection);
                reader = sqlCommand.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }

            return reader;
        }
    }


    

}
