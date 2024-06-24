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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == null || textBox2.Text==null || textBox3.Text==null || textBox4.Text==null || textBox5.Text==null || textBox6.Text==null) {
                MessageBox.Show("please fill the form appropriatly");
            }


            Customers customers = new Customers();
            customers.firstName = textBox1.Text;
            customers.lastName = textBox2.Text;
            customers.email = textBox3.Text;
            customers.address = textBox4.Text;
            customers = customers.createCustomer(customers);
            if(customers.id != 0)
            {
                Useraccount useraccount = new Useraccount();
                useraccount.username = textBox5.Text;
                useraccount.password = textBox6.Text;
                useraccount.rollId = customers.id;
                int result = useraccount.addUserAccount(useraccount);
                MessageBox.Show(result.ToString());
            }
        }
    }
}
