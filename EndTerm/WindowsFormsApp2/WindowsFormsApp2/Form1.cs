using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point prev;
        Pen pen;
        int r = 5;
        enum Tool{
            Black,
            Yellow,
            Red,
            Green
           };
        int color;
        
        public Form1()
        {
            InitializeComponent();
      //      bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        //    pictureBox1.Image = bmp; 
            
            g = CreateGraphics();
            int red = 1;
            int blue = 2;
            int black = 3;
            int yellow = 4;
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            r += 10; Random random = new Random();
            color = random.Next(1, 5);
            if (color == 1)
            {
                pen = new Pen(Color.Red, 2);
            }
            if (color == 2)
            {

                pen = new Pen(Color.Blue, 2);
            }
            if (color == 3)
            {

                pen = new Pen(Color.Black, 2);
            }
            if (color == 4)
            {

                pen = new Pen(Color.Yellow, 2);
            }
            g.DrawEllipse(pen, prev.X - r / 2, prev.Y - r / 2, r, r);
          //  Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            r = 5;
            prev = new Point(e.X, e.Y);
            timer1.Enabled = true;
        }
    }
}
