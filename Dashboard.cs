using ATEKELT_TERA1.API;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace ATEKELT_TERA1
{
    public partial class Dashboard : Form
    {
        private int customerId;
       
        public Dashboard()
        {
            InitializeComponent();
        }

        public Dashboard(int customerId)
        {
            this.customerId = customerId;
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 100;
            API.Products products = new API.Products();
            SqlDataReader reader = products.getAllProducts();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Price");
            dataTable.Columns.Add("Availability");
            dataTable.Columns.Add("Catagory");
            dataTable.Columns.Add("Image", typeof(byte[]));


            while (reader.Read())
            {
                // Create a DataRow and add it to the DataTable
                DataRow row = dataTable.NewRow();
                row["ID"] = reader["id"];
                row["Name"] = reader["name"];
                row["Price"] = reader["price"];
                row["Availability"] = reader["availability"];
                row["Catagory"] = reader["catagory"];

                string imagePath = reader["image"].ToString();
                byte[] imageData = File.ReadAllBytes(imagePath);
                row["Image"] = imageData;


                dataTable.Rows.Add(row);
            }

            dataGridView1.DataSource = dataTable;

            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Button";
            buttonColumn.Text = "Cart";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool existingRowFound = false;
            // Check if the clicked cell belongs to the button column
            if (e.ColumnIndex == dataGridView1.Columns["Button"].Index && e.RowIndex >= 0)
            {
                // Handle button click for the specific row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string productId = row.Cells["ID"].Value.ToString();
                MessageBox.Show(productId);

                DataTable dataTable = (DataTable)CartdataGridView1.DataSource;
                if (dataTable == null)
                {
                    dataTable = new DataTable();
                    dataTable.Columns.Add("ID").ReadOnly = true;
                    dataTable.Columns.Add("Name").ReadOnly = true;
                    dataTable.Columns.Add("Price").ReadOnly = true;
                    dataTable.Columns.Add("Quantity");
                    dataTable.Columns.Add("Catagory").ReadOnly = true;
                    CartdataGridView1.DataSource = dataTable;
                    DataGridViewButtonColumn removeButtonColumn = new DataGridViewButtonColumn();
                    removeButtonColumn.Name = "RemoveButton";
                    removeButtonColumn.HeaderText = "Remove";
                    removeButtonColumn.Text = "Remove";
                    removeButtonColumn.UseColumnTextForButtonValue = true;
                    CartdataGridView1.Columns.Add(removeButtonColumn);
                    CartdataGridView1.CellClick += CartdataGridView1_CellClick;

                }

                // Check if the "ID" already exists in the CartdataGridView1
              
                if (CartdataGridView1.RowCount > 1)
                {
                    foreach (DataGridViewRow cartRow in CartdataGridView1.Rows)
                    {
                        string cartProductId = cartRow.Cells["ID"].Value?.ToString();
                        if (cartProductId != null && cartProductId.Equals(productId))
                        {
                            // Update the existing row instead of adding a new one
                            int quantity = int.Parse(cartRow.Cells["Quantity"].Value.ToString()) + 1;
                            cartRow.Cells["Quantity"].Value = quantity.ToString();
                            existingRowFound = true;
                            break;
                        }
                    }
                }


                if (!existingRowFound)
                {
                    DataRow newRow = dataTable.NewRow();
                    newRow["ID"] = row.Cells["ID"].Value.ToString();
                    newRow["Name"] = row.Cells["Name"].Value.ToString();
                    newRow["Price"] = row.Cells["Price"].Value.ToString();
                    newRow["Quantity"] = 1;
                    newRow["Catagory"] = row.Cells["Catagory"].Value.ToString();

                    dataTable.Rows.Add(newRow);
                }

                
                CartdataGridView1.Refresh();
            }
        }

        private void CartdataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
            // Check if the clicked cell belongs to the remove button column
            if (e.ColumnIndex == CartdataGridView1.Columns["RemoveButton"].Index && e.RowIndex >= 0)
            {
                // Remove the specific row
                CartdataGridView1.Rows.RemoveAt(e.RowIndex);
                CartdataGridView1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow cartRow in CartdataGridView1.Rows)
            {

                if (cartRow.Cells["Price"].Value == null || cartRow.Cells["Quantity"].Value == null)
                {
                    continue; // Skip the current iteration and move to the next row
                }
                
                int price = int.Parse(cartRow.Cells["Price"].Value.ToString());
                int quantity = int.Parse(cartRow.Cells["Quantity"].Value.ToString());
                total = total + (price * quantity);
            }

            Checkout checkout = new Checkout(total, this, CartdataGridView1,customerId);
            this.Hide();
            checkout.Show();
        }
    }
}
