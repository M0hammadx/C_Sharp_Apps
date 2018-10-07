using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hesham_fileSystem
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("Create New Entry");
            comboBox1.Items.Add("Search For Entry");
            comboBox1.Items.Add("Update Entry");
            comboBox1.Items.Add("Delete Entry");
            comboBox1.SelectedIndex = 0;
        }
        string select_file;
        static void Create(string pathFile)
        {

            if (File.Exists(pathFile)) Delete(pathFile);
            using (FileStream fs = File.Create(pathFile))
            {
            }
        }
        static string[] Read(string pathFile)
        {
            if (File.Exists(pathFile))
                return File.ReadAllLines(pathFile);
            return new string[1];
        }
        static void Update(string pathFile, string s)
        {
            // File.SetAttributes(path+file, FileAttributes.Normal);
            if (!File.Exists(pathFile)) Create(pathFile);
            using (StreamWriter sw = File.AppendText(pathFile))
            {
                sw.WriteLine(s);
            }
        }
        static void Delete(string pathFile)
        {

            if (File.Exists(pathFile))
                File.Delete(pathFile);


            // File.SetAttributes(path + file, FileAttributes.Normal);
        }

        OpenFileDialog openfiledialog1 = new OpenFileDialog();
        private void button1_Click(object sender, EventArgs e)
        {
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                select_file = openfiledialog1.FileName;
                textBox1.Text = select_file;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = comboBox1.SelectedItem.ToString();
            //string path = Path.GetDirectoryName(select_file);
            //string file = Path.GetFileName(select_file);
            //MessageBox.Show(comboBox1.SelectedValue.ToString());
            if (s == "Create New Entry")
            {
                string name = textBox2.Text, mail = textBox3.Text, gender = textBox4.Text, num = textBox5.Text;
                Update(select_file, name + " " + mail + " " + gender + " " + num);
            }

            if (s == "Search For Entry")
            {
                listBox1.Items.Clear();
                bool f = false;
                string[] data = Read(select_file);
                foreach (var d in data)
                {
                    var dat = d.Split(' ');
                    if (textBox2.Text == "" || dat[0] == textBox2.Text &&
                        textBox3.Text == "" || dat[1] == textBox3.Text &&
                        textBox4.Text == "" || dat[2] == textBox4.Text &&
                        textBox5.Text == "" || dat[3] == textBox5.Text)
                    {
                        MessageBox.Show("Entry Found");
                        f = true;
                        listBox1.Items.Add(d);
                        //textBox2.Text = dat[0];
                        //textBox3.Text = dat[1];
                        //textBox4.Text = dat[2];
                        //textBox5.Text = dat[3];
                        //break;
                    }
                }
                if (!f) MessageBox.Show("Entry Not Found");
            }
            if (s == "Update Entry")
            {
                string name = textBox2.Text, mail = textBox3.Text, gender = textBox4.Text, num = textBox5.Text;
                string newname = textBox6.Text, newmail = textBox7.Text, newgender = textBox8.Text, newnum = textBox9.Text;
                bool f = false;
                string[] data = Read(select_file);
                for (int i = 0; i < data.Length; i++)
                {
                    var dat = data[i].Split(' ');
                    if (textBox2.Text == "" || dat[0] == textBox2.Text &&
                       textBox3.Text == "" || dat[1] == textBox3.Text &&
                       textBox4.Text == "" || dat[2] == textBox4.Text &&
                       textBox5.Text == "" || dat[3] == textBox5.Text)
                    {
                        f = true;
                        MessageBox.Show("Entry Updated");
                        data[i] = "";
                        if (newname != "")
                            data[i] += newname + " ";
                        else data[i] += dat[0] + " ";
                        if (newmail != "")
                            data[i] += newmail + " ";
                        else data[i] += dat[1] + " ";
                        if (newgender != "")
                            data[i] += newgender + " ";
                        else data[i] += dat[2] + " ";
                        if (newnum != "")
                            data[i] += newnum + " ";
                        else data[i] += dat[3] + " ";

                    }
                }
                Create(select_file);
                for (int i = 0; i < data.Length; i++)
                {

                    Update(select_file, data[i]);
                }
                if (!f) MessageBox.Show("Entry Not Found");
            }
            if (s == "Delete Entry")
            {
                string name = textBox2.Text, mail = textBox3.Text, gender = textBox4.Text, num = textBox5.Text;
                bool f = false;
                string[] data = Read(select_file);
                for (int i = 0; i < data.Length; i++)
                {
                    var dat = data[i].Split(' ');
                    if (textBox2.Text == "" || dat[0] == textBox2.Text &&
                       textBox3.Text == "" || dat[1] == textBox3.Text &&
                       textBox4.Text == "" || dat[2] == textBox4.Text &&
                       textBox5.Text == "" || dat[3] == textBox5.Text) { f = true; MessageBox.Show("Entry Deleted"); data[i] = "xxxdeletedxxx"; }

                }
                Create(select_file);
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != "xxxdeletedxxx")
                        Update(select_file, data[i]);
                }

                if (!f) MessageBox.Show("Entry Not Found");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (comboBox1.SelectedItem.ToString() == "Update Entry")
            {
                groupBox2.Visible = true;
            }
            else
            {
                groupBox2.Visible = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}

