using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEKELT_TERA1.API
{
    internal class Customers
    {
        static readonly string connectionString = Config.getConnectionString();
        public int id;
        public String firstName;
        public String lastName;
        public String email;
        public String address;


       


        public Customers createCustomer(Customers customers)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into customer values('" + customers.firstName + "', '" + customers.lastName + "','" + customers.email + "','" + customers.address + "')", connection);
                cmd.ExecuteNonQuery();
                SqlCommand cmdd = new SqlCommand("SELECT TOP 1 * FROM customer ORDER BY id DESC;", connection);
                SqlDataReader reader = cmdd.ExecuteReader();
                Customers response = new Customers();
                while (reader.Read())
                {
                    response.id = int.Parse(reader["id"].ToString());
                    response.firstName = reader["first_name"].ToString();
                    response.lastName = reader["last_name"].ToString();
                    response.email = reader["email"].ToString();
                    response.address = reader["address"].ToString();

                }
                return response;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return new Customers();
        }

        public Customers searchById(Customers customers)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmdd = new SqlCommand("Select * from customer where id = "+ customers.id + ";", connection);
                SqlDataReader reader = cmdd.ExecuteReader();
                Customers response = new Customers();
                while (reader.Read())
                {
                    response.id = int.Parse(reader["id"].ToString());
                    response.firstName = reader["first_name"].ToString();
                    response.lastName = reader["last_name"].ToString();
                    response.email = reader["email"].ToString();
                    response.address = reader["address"].ToString();

                }
                return response;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return new Customers();
        }
    }
}
