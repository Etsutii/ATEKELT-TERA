using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ATEKELT_TERA1.API
{
    internal class Products
    {
        static readonly string connectionString = Config.getConnectionString(); 
        public int id { get; set; }
        public string name { get; set; }
        public string catagory { get; set; }
        public int availability { get; set; }
        public float price { get; set; }
        public string image { get; set; }
        public SqlDataReader getAllProducts()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(" SELECT id, name, price, availability, catagory, image FROM products", connection);
                reader = sqlCommand.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }

            return reader;
        }


        public int addProduct(Products products)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into products values('" + products.name + "', '" + products.catagory + "'," + products.availability + ",'" + products.price + "','" + products.image + "')", connection);


                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally { connection.Close(); }
            return 0;
        }
        public int deleteProduct(int productId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM products WHERE id = @ProductId", connection);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }


        public int updateProduct(Products products)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE products SET name = @name, catagory = @category, availability = @availability, price = @price, image = @image WHERE id = @id", connection);
                cmd.Parameters.AddWithValue("@name", products.name);
                cmd.Parameters.AddWithValue("@category", products.catagory);
                cmd.Parameters.AddWithValue("@availability", products.availability);
                cmd.Parameters.AddWithValue("@price", products.price);
                cmd.Parameters.AddWithValue("@image", products.image);
                cmd.Parameters.AddWithValue("@id", products.id);


                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error: " + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return 0;
        }
    }
}
