using ATEKELT_TERA1.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATEKELT_TERA1
{
    public partial class Admin : Form
    {
        private string imagePath;
        public Admin()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DeleteTabPage_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FindButtn_Click(object sender, EventArgs e)
        {
            Customers customers = new Customers();
            customers.id = int.Parse(IDTextBx.Text);
            customers = customers.searchById(customers);

            NamTextBx.Text = customers?.firstName;
            textBox1.Text = customers?.lastName;
            textBox2.Text = customers?.email;
            textBox3.Text = customers?.address;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TODO validation
            Products products = new Products();
            products.id = int.Parse(textBox6.Text);
            products.name = ItemIDTxtBx.Text;
            products.catagory =ItemNamTxtBx.Text;
            products.availability = int.Parse(textBox4.Text);
            products.price = int.Parse(textBox5.Text);
            String imgpath = UploadImageToDatabase(imagePath);
            products.image = imgpath;
            int result = products.updateProduct(products);
            if (result > 0)
                MessageBox.Show("product updated successfully");
            else
                MessageBox.Show("Unknown error occured");



        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select an Image File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;

                    // Process the selected image path (e.g., upload to database)
                    pictureBox1.ImageLocation = imagePath;
                    //MessageBox.Show(imagePath);
                    // UploadImageToDatabase(imagePath);
                }
            }
        }


        private String UploadImageToDatabase(string imagePath)
        {
            string imageDirectory = "C:\\atekelt";
            string fileName = Path.GetFileName(imagePath);
            string uniqueFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + fileName;
            string destinationPath = Path.Combine(imageDirectory, uniqueFileName);

            File.Copy(imagePath, destinationPath);


            return (imageDirectory + "\\" + uniqueFileName);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO validation
            if (string.IsNullOrEmpty(ItemIDTxtBx.Text) ||
            string.IsNullOrEmpty(ItemNamTxtBx.Text) ||
            string.IsNullOrEmpty(textBox4.Text) ||
            string.IsNullOrEmpty(textBox5.Text) ||
            string.IsNullOrEmpty(imagePath))
            {
                MessageBox.Show("Please fill in all the required information and select an image.");
                return;
            }

            Products products = new Products();
            products.name = ItemIDTxtBx.Text;
            products.catagory = ItemNamTxtBx.Text;
            products.availability = int.Parse(textBox4.Text);
            products.price = int.Parse(textBox5.Text);
            String imgpath = UploadImageToDatabase(imagePath);
            products.image = imgpath;


            int result = products.addProduct(products);
            if (result > 0)
                MessageBox.Show("product uploaded successfully");
            else
                MessageBox.Show("Unknown error occured");

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void DelButtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox6.Text, out int productId))
            {
                Products products = new Products();

                // Call the deleteProduct method to delete the product by its ID
                int result = products.deleteProduct(productId);

                if (result > 0)
                {
                    MessageBox.Show("Product deleted successfully");
                }
                else
                {
                    MessageBox.Show("Product not found or an error occurred during deletion");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid product ID");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AdminTabCntrl.SelectedTab == tabPage1)
            {
               CustomerOrders customerOrders = new CustomerOrders();
                SqlDataReader reader = customerOrders.getAllCustomerOrders();
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("First Name");
                dataTable.Columns.Add("Last Name");
                dataTable.Columns.Add("Address");
                dataTable.Columns.Add("Quantity");
                dataTable.Columns.Add("Payment Id");
                dataTable.Columns.Add("Amount");
                dataTable.Columns.Add("Product Name");

                while (reader.Read())
                {
                    DataRow row = dataTable.NewRow();
                    row["ID"] = reader["id"];
                    row["First Name"] = reader["first_name"];
                    row["Last Name"] = reader["last_name"];
                    row["Address"] = reader["address"];
                    row["Quantity"] = reader["quantity"];
                    row["Payment Id"] = reader["payment_id"];
                    row["Amount"] = reader["amount"];
                    row["Product Name"] = reader["name"];
                    dataTable.Rows.Add(row);
                }
                dataGridView1.DataSource = dataTable;
                dataGridView1.Refresh();
            }
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
