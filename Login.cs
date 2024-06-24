using ATEKELT_TERA1.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEKELT_TERA1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButtn_Click(object sender, EventArgs e)
        {
            if (UsrNamTxtBx.Text != "" && PassTxtBx.Text != "" && RollCombo.SelectedIndex != -1)
            {
                API.Useraccount useraccount = new API.Useraccount();
                if (RollCombo.SelectedIndex==0)
                {

                    //TODO make sure to use the admin class instead of the dashboard
                    Useraccount response = useraccount.AdminLogin(UsrNamTxtBx.Text, PassTxtBx.Text);


                    if (response.username == null)
                        MessageBox.Show("incorrect username or password");
                    else
                    {
                        MessageBox.Show("Welcome " + response.username);
                        Admin admin  = new Admin();
                        this.Hide();
                        admin.Show();
                    }
                }
                else
                {
                    Useraccount response = useraccount.UserLogin(UsrNamTxtBx.Text, PassTxtBx.Text);
                    

                    if (response.username == null)
                        MessageBox.Show("incorrect username or password");
                    else
                    {
                        MessageBox.Show("Welcome " + response.username);
                        Dashboard dashboard = new Dashboard(response.rollId);
                        this.Hide();
                        dashboard.Show();
                    }
                }
               
                
                
                  
               
            }
            else
            {
                MessageBox.Show("please insert username or password correctly");
            }

        }

        private void UsrNamTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }
    }
}
