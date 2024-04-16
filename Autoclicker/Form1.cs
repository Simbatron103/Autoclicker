using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace Autoclicker
{
    public partial class Form1 : Form
    {
        InputSimulator input = new InputSimulator();
        int oldCount = 0;
        bool getpos = false;
        bool Nobitches = false;
        Random rng = new Random();  
       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            getpos = true;

        }
        private void form1_deactivate(object sender, EventArgs e)
        {


            if (getpos)
            {
                textBox1.Text = Cursor.Position.X.ToString();
                textBox2.Text = Cursor.Position.Y.ToString();

                getpos = false;
            }
            if (Nobitches)
            {
                textBox4.Text = Cursor.Position.X.ToString();
                textBox5.Text = Cursor.Position.Y.ToString();

                Nobitches = false;
            }

        }





        private void button2_Click(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out oldCount);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            int.TryParse(textBox1.Text, out int x);
            int.TryParse(textBox2.Text, out int y);
            int.TryParse(textBox3.Text, out int count);
            int.TryParse(textBox4.Text, out int X);
            int.TryParse(textBox5.Text, out int Y);
            y = rng.Next(y, Y);
            x = rng.Next(x, X);
            x = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Width) * x);
            y = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Height) * y);
            X = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Width) * X);
            Y = (int)((65535.0 / Screen.PrimaryScreen.Bounds.Height) * Y);

            if (count > 0)
            {

                input.Mouse.MoveMouseTo(x,y );
                count--;
                textBox3.Text = count.ToString();
                input.Mouse.LeftButtonClick();
            }
            else if (count == 0)
            {
                textBox3.Text = oldCount.ToString();
                timer1.Stop();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Nobitches = true;
        }
    }
}

       