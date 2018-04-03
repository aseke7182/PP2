using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace MsPaint
{
    public partial class Form1 : Form
    {
        int tool = 0;
        int size ;
        bool click;
        Point prev, cur;
        Graphics g;
        Pen pen;
        Color colors;
        Bitmap bmp;
        string operation;
        TextBox text;
        Queue<Point> queue;
        public Form1()
        {
            InitializeComponent();
            click = false;
            queue = new Queue<Point>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            colors = Color.Black;
            pen = new Pen(colors, size);
            button4.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = 2;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
            prev = e.Location;
            switch (operation)
            {
                case "palitra":
                    pen = new Pen(bmp.GetPixel(prev.X, prev.Y), size);
                    operation = "";
                    break;
                case "fill":
                    
                    break;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            if (click)
            {
                if(tool == 1)
                {
                    g.DrawLine(pen, prev.X, prev.Y, e.X, e.Y);
                    prev = e.Location;
                }
                if(tool == 4)
                {
                    Pen eraser = new Pen(Color.White, size*3);
                    g.DrawLine(eraser, prev.X, prev.Y, cur.X, cur.Y);
                    prev = e.Location;
                }
                if(tool  == 6)
                {
                    text = new TextBox();
                    text.Location = new Point(prev.X, prev.Y);
                    text.Multiline = true;
                    text.UseWaitCursor = true;
                    text.Size = new Size(e.X-prev.X,e.Y-prev.Y);
                 }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(tool ==2)
            {
                e.Graphics.DrawRectangle(pen, Math.Min(prev.X, cur.X), Math.Min(prev.Y, cur.Y), Math.Abs(prev.X - cur.X), Math.Abs(prev.Y - cur.Y));
            }
            if (tool == 3)
            {
                if (prev.X < cur.X && prev.Y < cur.Y)
                {
                    e.Graphics.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                    e.Graphics.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                    e.Graphics.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                }
                if (prev.X > cur.X && prev.Y > cur.Y)
                {
                    e.Graphics.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                    e.Graphics.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                    e.Graphics.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                }
                if (prev.X < cur.X && prev.Y > cur.Y)
                {
                    e.Graphics.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                    e.Graphics.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                    e.Graphics.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                }
                if (prev.X > cur.X && prev.Y < cur.Y)
                {
                    e.Graphics.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                    e.Graphics.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                    e.Graphics.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                }
            }
            if (tool == 5)
            {
                e.Graphics.DrawEllipse(pen, prev.X, prev.Y, cur.X-prev.X, cur.Y-prev.Y);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tool = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tool = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tool = 5;
        }

        private void Colors(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            colors = btn.BackColor;
            pen = new Pen(colors,size);
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {
            size = trackBar1.Value;
            pen = new Pen(colors, size);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            operation = "palitra";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tool = 6;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            operation = "fill";
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            click = false;
            if (tool == 2)
            {
                g.DrawRectangle(pen, Math.Min(prev.X, cur.X), Math.Min(prev.Y, cur.Y), Math.Abs(prev.X - cur.X), Math.Abs(prev.Y - cur.Y));
                pictureBox1.Refresh();
            }
            if (tool == 3)
            {
                if (prev.X < cur.X && prev.Y<cur.Y)
                {
                    g.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                    g.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                    g.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                }
                if(prev.X >cur.X && prev.Y> cur.Y)
                {
                    g.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                    g.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                    g.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                }
                if(prev.X<cur.X && prev.Y > cur.Y)
                {
                    g.DrawLine(pen, prev.X, prev.Y, cur.X, prev.Y);
                    g.DrawLine(pen, cur.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                    g.DrawLine(pen, prev.X, prev.Y, (cur.X + prev.X) / 2, cur.Y);
                }
                if(prev.X>cur.X && prev.Y < cur.Y)
                {
                    g.DrawLine(pen, prev.X, cur.Y, cur.X, cur.Y);
                    g.DrawLine(pen, cur.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                    g.DrawLine(pen, prev.X, cur.Y, (cur.X + prev.X) / 2, prev.Y);
                }
                pictureBox1.Refresh();
            }
            if(tool == 5)
            {
                g.DrawEllipse(pen, prev.X, prev.Y, cur.X - prev.X, cur.Y - prev.Y);
                pictureBox1.Refresh();
            }
            if(tool == 6)
            {
                pictureBox1.Controls.Add(text);
            }
        }
    }
}
