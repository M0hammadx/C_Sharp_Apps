using System;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace alarm
{
    public partial class Form1 : Form
    {
        
        int h = 1;
        public static int alarm;
        static public DateTime a1;
        DateTime now;
        SoundPlayer s1=new SoundPlayer(@"D:\Unity\Projects\hassan\Assets\Resources\Gun.wav");
        public Form1()
        {
            InitializeComponent();
        }
        ImageList img;
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (h == 1)
            {
                label1.Text = DateTime.Now.ToString("hh:mm:ss") + " " + DateTime.Now.ToString("tt");

            }
            else
            {
                label1.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            if (alarm == 1)
            {
                now = DateTime.Now;
                if (now.Hour==a1.Hour&&now.Minute==a1.Minute&&now.Second==a1.Second){
                    s1.Play();
                    MessageBox.Show("alarm","alarm :)",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                    alarm = 0;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToString("hh:mm:ss tt yy:dd"));
        }
    }
}
