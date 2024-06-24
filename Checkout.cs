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
    public partial class Checkout : Form
    {
        private int total;
        private Dashboard dashboard;
        private DataGridView dataGridView;
        private int customerId;
        public Checkout()
        {
            InitializeComponent();
        }

        public Checkout(int total, Dashboard dashboard, DataGridView dataGridView, int customerId)
        {
            this.total = total;
            this.dashboard = dashboard;
            this.dataGridView = dataGridView;
            this.customerId = customerId;
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            label2.Text = total.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            dashboard.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cardNumber = textBox1.Text;
            String fullName = textBox2.Text;
            if (label2.Text!=null)
            {
                foreach (DataGridViewRow cartRow in dataGridView.Rows)
                {
                    //TODO: validation
                    string cartProductId = cartRow.Cells["ID"].Value?.ToString();
                    if (cartProductId == null)
                        continue;


                    Payments payment = new Payments();
                    payment.cardtype = comboBox1.SelectedItem.ToString();
                    payment.cardnumber = cardNumber;
                    payment.fullname = fullName;
                    int price = int.Parse(cartRow.Cells["Price"].Value.ToString());
                    int quantity = int.Parse(cartRow.Cells["Quantity"].Value.ToString());
                    payment.amount = (price * quantity);
                    payment = payment.createPayment(payment);




                    CustomerOrders customerOrders = new CustomerOrders();
                    customerOrders.quantity = int.Parse(cartRow.Cells["Quantity"].Value.ToString());
                    customerOrders.paymentId = payment.id;
                    customerOrders.customerId = customerId;
                    customerOrders.productId = int.Parse(cartRow.Cells["ID"].Value.ToString());
                    if(customerOrders.CreateCustomerOrder(customerOrders)>0)
                    {
                        MessageBox.Show(customerOrders.productId + " ordered successfully");
                        this.Hide();
                        dashboard.Show();
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("unknowen error occured during ordering the product " + customerOrders.productId);
                    }

                   
                }
            }
        }
    }
}
