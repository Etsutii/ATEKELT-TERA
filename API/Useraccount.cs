using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ATEKELT_TERA1.API
{
    internal class Useraccount
    {
        static readonly string connectionString = Config.getConnectionString();
        public String username { get; set; }
        public String password { get; set; }
        public String roll {  get; set; }
        public int rollId {  get; set; }

        public Useraccount UserLogin(String username, String password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from useraccount where username ='"+username+"'and password= '"+password+"' and roll_type='USER'",connection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    string user = dr["username"].ToString();
                    String rollId = dr["roll_id"].ToString();
                    if(username != "" || (rollId != ""))
                    {
                        Useraccount useraccount = new Useraccount();
                        useraccount.username = user;
                        useraccount.rollId = int.Parse(rollId);
                        return useraccount;
                    }
                   return new Useraccount();
                    

                }
                else
                    return new Useraccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return new Useraccount();

        }

        public Useraccount AdminLogin(String username, String password)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("select * from useraccount where username ='" + username + "'and password= '" + password + "' and roll_type='ADMIN'", connection);
                SqlDataReader dr = sqlCommand.ExecuteReader();
                if (dr.Read())
                {
                    string user = dr["username"].ToString();
                    String rollId = dr["roll_id"].ToString();
                    if (username != "" || (rollId != ""))
                    {
                        Useraccount useraccount = new Useraccount();
                        useraccount.username = user;
                        useraccount.rollId = int.Parse(rollId);
                        return useraccount;
                    }
                    return new Useraccount();


                }
                else
                    return new Useraccount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return new Useraccount();

        }

        public int addUserAccount(Useraccount useraccount)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("insert into useraccount values('" + useraccount.username + "', '" + useraccount.password + "','" + "USER" + "'," + useraccount.rollId + ")", connection);


                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Error" + ex.ToString());
            }
            finally { connection.Close(); }
            return 0;
        }

    }
}
