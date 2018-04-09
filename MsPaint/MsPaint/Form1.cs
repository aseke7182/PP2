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
using System.Drawing.Imaging;
namespace MsPaint
{
    public partial class Form1 : Form
    {
        int tool = 0;
        int size  =1;
        string picture, operation, s;
        bool click;
        Point prev, cur, p;
        Graphics g;
        Pen pen;
        Color colors,asd;
        Bitmap bmp;
        bool paint = true;
        bool oper = false;
        Queue<Point> queue;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            colors = Color.Black;
            pen = new Pen(colors, size);
            click = false;
            queue = new Queue<Point>();
            button4.BackgroundImageLayout = ImageLayout.Stretch;
            Bmp();
        }
        public void Bmp()
        {
            for(int i=0; i < pictureBox1.Height; i++)
            {
                for( int j=0; j < pictureBox1.Width;j++)
                {
                    bmp.SetPixel(j, i, Color.White);
                }
            }
        }
        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            click = true;
            prev = e.Location;
            if(e.Button == MouseButtons.Left)
            {
                colors = button20.BackColor;
            }
            if(e.Button == MouseButtons.Right)
            {
                colors = button19.BackColor;
            }
            pen = new Pen(colors, size);
            if (oper)
            {
                switch (operation)
                {
                    case "palitra":
                        colors = bmp.GetPixel(prev.X, prev.Y);
                        pen = new Pen(colors, size);
                        if (!paint)
                        {
                            button19.BackColor = colors;
                        }
                        else
                        {
                            button20.BackColor = colors;
                        }
                        operation = "";
                        break;
                    case "fill":
                        asd = bmp.GetPixel(prev.X, prev.Y);
                        queue.Enqueue(prev);
                        while(queue.Count != 0)
                        {
                            p = queue.Dequeue();
                            
                            bmp.SetPixel(p.X, p.Y, colors);
                            if (bmp.GetPixel(Math.Min(pictureBox1.Width-1, p.X + 1), Math.Min(pictureBox1.Height - 1, p.Y)) == asd)
                            {
                                if (!queue.Contains(new Point(Math.Min(pictureBox1.Width - 1, p.X + 1), Math.Min(pictureBox1.Height - 1, p.Y))))
                                    queue.Enqueue(new Point(Math.Min(pictureBox1.Width - 1, p.X + 1), Math.Min(pictureBox1.Height - 1, p.Y)));
                            } 
                            if (bmp.GetPixel(Math.Max(0, p.X - 1),Math.Min(pictureBox1.Height-1, p.Y)) == asd)
                            {
                                if (!queue.Contains(new Point(Math.Max(0, p.X - 1),Math.Min(pictureBox1.Height-1, p.Y))))
                                    queue.Enqueue(new Point(Math.Max(0, p.X - 1), Math.Min(pictureBox1.Height - 1, p.Y)));
                            }
                            if (bmp.GetPixel(Math.Max(0, p.X) , Math.Min(pictureBox1.Height-1, p.Y+1)) == asd)
                            {
                                if (!queue.Contains(new Point(Math.Max(0, p.X), Math.Min(pictureBox1.Height-1, p.Y + 1))))
                                    queue.Enqueue(new Point(Math.Max(0, p.X), Math.Min(pictureBox1.Height-1, p.Y + 1)));
                            }
                            if (bmp.GetPixel(Math.Max(0, p.X), Math.Max(0, p.Y-1)) == asd)
                            {
                                if (!queue.Contains(new Point(Math.Max(0, p.X), Math.Max(0, p.Y - 1))))
                                    queue.Enqueue(new Point(Math.Max(0, p.X), Math.Max(0, p.Y-1)));
                            }
                            
                        }
                        pictureBox1.Refresh();
                        break;
                    case "text":
                        s = textBox1.Text;
                        g.DrawString(s, DefaultFont, new SolidBrush(Color.Black), prev.X, prev.Y);
                        pictureBox1.Refresh();
                        break;
                }
            }
        }
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
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
                pictureBox1.Refresh();
            }
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
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
            if(tool == 7)
            {
                e.Graphics.DrawLine(pen, prev.X, prev.Y, cur.X, cur.Y);
            }
        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
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
            if(tool == 7)
            {
                g.DrawLine(pen, prev.X, prev.Y, cur.X, cur.Y);
            }
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            oper = false;
            tool = 1;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            oper = false;
            tool = 2;
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            oper = false;
            tool = 3;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            tool = 4;
            oper = false;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            oper = false;
            tool = 5;
        }
        private void Colors(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            colors = btn.BackColor;
            pen = new Pen(colors, size);
            if (!paint)
            {
                button19.BackColor = colors;
            }
            else
            {
                button20.BackColor = colors;
            }
        }
        private void Button7_Click(object sender, EventArgs e)
        {
            operation = "palitra";
            oper = true;
        }
        private void Button16_Click(object sender, EventArgs e)
        {
            tool = 6;
            operation = "text";
            oper = true;
        }
        private void Button8_Click(object sender, EventArgs e)
        {
            operation = "fill";
            oper = true;
        }
        private void Button17_Click(object sender, EventArgs e)
        {
            oper = false;
            tool = 7;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = int.Parse(comboBox1.Text);
            pen = new Pen(colors, size);
        }
        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
        }
        private void saveToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            click = false;
            pen = new Pen(Color.Transparent, 1);
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            click = false;
            pen = new Pen(Color.Transparent, 1);
        }
        private void Button18_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            colors = colorDialog1.Color;
            pen = new Pen(colors, size);
            if (!paint)
            {
                button19.BackColor = colors;
            }
            else
            {
                button20.BackColor = colors;
            }
        }
        private void Button20_Click(object sender, EventArgs e)
        {
            colors = button20.BackColor;
            paint = true;
            pen = new Pen(colors, size);
        }
        private void Button19_Click(object sender, EventArgs e)
        {
            colors = button19.BackColor;
            paint = false;
            pen = new Pen(colors, size);
        }


        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picture = openFileDialog1.FileName;
            bmp = new Bitmap(picture);
            pictureBox1.Refresh();
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
        }
        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //saveFileDialog1.ShowDialog();
                picture = saveFileDialog1.FileName;
                bmp.Save(picture);
            }
        }
        
    }
}
