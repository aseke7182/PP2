using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniPaint
{
    public partial class Form1 : Form
    {
        int tool = 0;
        int r = 50;
        int x, y;
        Pen pen = new Pen(Color.Black, 3);
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = 3;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Refresh();
            x = int.Parse(textBox1.Text);
            y = int.Parse(textBox2.Text);
            if(tool == 1)
            {
                g.DrawEllipse(pen, x, y, r, r);
            }
            if(tool == 2)
            {
                g.DrawRectangle(pen, x, y, r, r);
            }
            if(tool ==3)
            {
                Point[] p = { new Point(x, y), new Point(x + r, y + r), new Point(x + r / 2, y - r) };
                g.DrawPolygon(pen, p);
            }
        }
    }
}
