using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        int x=10;
        int r = 5;
        Pen pen = new Pen(Color.Black, 2);
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, x, 200, x + 33, 170);
            e.Graphics.DrawRectangle(pen, x + 33, 170, 10, 30);
            e.Graphics.DrawRectangle(pen, x, 200, 50, 25);
            e.Graphics.DrawEllipse(pen, x + r, 220, 20, 20);
            e.Graphics.DrawEllipse(pen, x + r + 25,220, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            if (pictureBox1.Width <= x)
            {
                x = 10;
            }
            pictureBox1.Refresh();
        }
    }
}
