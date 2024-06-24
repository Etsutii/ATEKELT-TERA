using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEKELT_TERA1.API
{
    internal class Payments
    {
        static readonly string connectionString = Config.getConnectionString();
        public int id {  get; set; }
        public string fullname { get; set; }
        public string cardtype { get; set; }
        public string cardnumber { get; set; }
        public float amount { get; set; }


        public Payments createPayment(Payments payments)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into payments values('"+payments.cardtype+"', '"+payments.cardnumber+"','"+payments.amount+"','"+payments.fullname+"')", connection);
                cmd.ExecuteNonQuery();
                SqlCommand cmdd = new SqlCommand("SELECT TOP 1 * FROM payments ORDER BY id DESC;", connection);
                SqlDataReader reader = cmdd.ExecuteReader();
                Payments response = new Payments();
                while (reader.Read())
                {
                    response.id = int.Parse(reader["id"].ToString());
                    response.cardnumber = reader["card_number"].ToString();
                    response.amount = float.Parse(reader["amount"].ToString());
                    response.fullname= reader["fullname"].ToString();
                    response.cardtype = reader["card_type"].ToString();
                    
                }
                return response;

            }
            catch(Exception ex) {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return new Payments();
        }
    }
}
