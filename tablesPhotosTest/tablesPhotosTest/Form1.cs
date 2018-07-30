using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tablesPhotosTest
{
    public partial class Form1 : Form
    {
        string s = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mh-sh\Documents\test.mdf;Integrated Security=true;Connect Timeout=30";
        SqlDataAdapter da;
        SqlConnection con;

        DataSet st_dataSet = new DataSet();
        public Form1()
        {


            con = new SqlConnection(s);
            string sql = "Select * FROM students";
            da = new SqlDataAdapter(sql, s);
            con.Open();
            da.Fill(st_dataSet, "students");
            /*MemoryStream ms = new MemoryStream();
            Image im = Bitmap.FromFile("");
            im.Save(ms, ImageFormat.Bmp);
            byte[] arr = (byte[])ms.ToArray();*/
            con.Close();
            InitializeComponent();



        }
        OpenFileDialog openfiledialog1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {

            openfiledialog1.Filter = "Image files|*.bmp;*.gif;*.jpg;*.tif|All files|*.*";
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openfiledialog1.FileName, true);
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

            DataRow r = st_dataSet.Tables["students"].NewRow();
            r["Id"] = int.Parse(textBox1.Text);
            r["name"] = textBox2.Text;
            MemoryStream ms = new MemoryStream();

            pictureBox1.Image.Save(ms, ImageFormat.Bmp);
            byte[] arr = ms.ToArray();
            r["img"] = arr;
            st_dataSet.Tables["students"].Rows.Add(r);
            try
            {

                con.Open();
                SqlCommandBuilder cb;
                cb = new SqlCommandBuilder(da);

                //da.UpdateCommand = cb.GetUpdateCommand(true);

                da.Update(st_dataSet, "students");
                con.Close();
            }
            catch (Exception ee)
            {


                MessageBox.Show("Test fail " + ee.ToString());
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in st_dataSet.Tables["students"].Rows)
            {
                if (Convert.ToInt32(r["Id"]) == int.Parse(textBox1.Text))
                {
                    textBox2.Text = Convert.ToString(r["name"]);
                    byte[] arr = (byte[])(r["img"]);
                    MemoryStream ms = new MemoryStream(arr);

                    Bitmap b = new Bitmap(ms);
                    pictureBox1.Image = b;
                    //pictureBox1.Image = new Bitmap(new MemoryStream((byte[])r["id"));
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /* con = new SqlConnection(s);
             SqlCommand cmd = new SqlCommand("Select * FROM students", con);
             con.Open();
             dataGridView1.DataSource = cmd.ExecuteReader();
             dataGridView1.DataBind();
             con.Close();*/
            dataGridView1.DataSource = st_dataSet.Tables["students"];
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
