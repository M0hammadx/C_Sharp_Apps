using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        SqlConnection sqlcon;

        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                string name = textBox2.Text;
                string productname = textBox3.Text;
                int amount = Convert.ToInt32(textBox4.Text);
                float price = Convert.ToSingle(textBox5.Text);
                DateTime datetime = dateTimePicker1.Value;

                invoiceTableAdapter1.Insert(id, name, productname, amount, price, datetime);

                invoiceTableAdapter1.Update(this.loginDataSet2.invoice);
            }catch(Exception qe)
            {

            }
            /* try { 
             sqlcon.Open();
             int id = Convert.ToInt32(textBox1.Text);
             string name = textBox2.Text;
             string productname = textBox3.Text;
             int amount = Convert.ToInt32(textBox4.Text);
             float price = Convert.ToSingle(textBox5.Text);
             string datetime = dateTimePicker1.Value.ToString() ;

             SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[invoice] ([Id], [customer name], [product name], [product amout], [product price], [date]) VALUES(@ProductID,@name,@ProductName,@Price,@ProductAmount,@datetime)", sqlcon);
             cmd.Parameters.Clear();
             cmd.Parameters.AddWithValue("@ProductID", id);
             cmd.Parameters.AddWithValue("@name", name);
             cmd.Parameters.AddWithValue("@ProductName", productname);
             cmd.Parameters.AddWithValue("@Price", price);
             cmd.Parameters.AddWithValue("@ProductAmount", amount);
             cmd.Parameters.AddWithValue("@datetime", datetime);
             cmd.ExecuteNonQuery();
                 dataGridView1.Show();
             }
             catch (Exception q)
             {
                 MessageBox.Show("please enter a valid input");
             }
             finally
             {
                 sqlcon.Close();
             }*/

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'loginDataSet2.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter1.Fill(this.loginDataSet2.invoice);

            /* sqlcon = new SqlConnection();
             sqlcon.ConnectionString = "Data Source=DESKTOP-54H4EQ5\\SQLEXPRESS;Initial Catalog=login;Integrated Security=True";
             sqlcon.Open();
             */

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowindex = dataGridView1.CurrentRow.Index;
            DataGridViewRow selectedRow = dataGridView1.Rows[rowindex];

            textBox1.Text = Convert.ToString(selectedRow.Cells[0].Value);
            textBox2.Text = Convert.ToString(selectedRow.Cells[1].Value);
            textBox3.Text = Convert.ToString(selectedRow.Cells[2].Value);
            textBox4.Text = Convert.ToString(selectedRow.Cells[3].Value);
            textBox5.Text = Convert.ToString(selectedRow.Cells[4].Value);
            dateTimePicker1.Value =Convert.ToDateTime( selectedRow.Cells[5].Value);
            textBox6.Text = Convert.ToString(Convert.ToInt32(textBox5.Text) * Convert.ToInt32(textBox4.Text));

        }
             catch (Exception q)
             {
                 MessageBox.Show("please choose a row");
             }


    /*string name = textBox2.Text;
    string productname = textBox3.Text;
    int amount = Convert.ToInt32(textBox4.Text);
    float price = Convert.ToSingle(textBox5.Text);
    DateTime datetime = dateTimePicker1.Value;
    */


}

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            int k = 0;
            for(int i = 0; i<dataGridView1.Rows.Count-1; i++)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[i];
                if ((Convert.ToDateTime(selectedRow.Cells[5].Value) >dateTimePicker2.Value)&& (Convert.ToDateTime(selectedRow.Cells[5].Value) < dateTimePicker3.Value))
                {

                    
                    dataGridView2.Rows.Insert(k, selectedRow.Cells[0].Value, selectedRow.Cells[1].Value, selectedRow.Cells[2].Value, selectedRow.Cells[3].Value, selectedRow.Cells[4].Value, selectedRow.Cells[5].Value);
                    dataGridView2.Rows.Add();
                    k++;
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
