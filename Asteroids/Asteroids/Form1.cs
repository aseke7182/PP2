using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        Pen pen;
        int radius = 50;
        int r = 30;
        int circle=30;
        Pen pencil = new Pen(Color.White);
        SolidBrush sb = new SolidBrush(Color.White);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush green = new SolidBrush(Color.Green);
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Yellow,5);
            pictureBox1.Location = new Point(FindForm().Location.X, FindForm().Location.Y);
            pictureBox1.Size = new Size(FindForm().Width, FindForm().Height);
            label1.Text = "Level: 1  Score: 200  Live: ***";
            label1.Location = new Point(pictureBox1.Width - label1.Width-20 , 20);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Point[] p = { new Point(pictureBox1.Width/2 - radius  , pictureBox1.Height/2 - radius/2),
                          new Point(pictureBox1.Width/2           , pictureBox1.Height/2 - radius),
                          new Point(pictureBox1.Width/2 + radius  , pictureBox1.Height/2 - radius/2),
                          new Point(pictureBox1.Width/2 + radius  , pictureBox1.Height/2 + radius/2),
                          new Point(pictureBox1.Width/2           , pictureBox1.Height/2 + radius),
                          new Point(pictureBox1.Width/2 - radius  , pictureBox1.Height/2 + radius/2)
                          };
            Point[] arr = { new Point(pictureBox1.Width/2 - r , pictureBox1.Height/2 ),
                            new Point(pictureBox1.Width/2     , pictureBox1.Height/2 - r ),
                            new Point(pictureBox1.Width/2 + r , pictureBox1.Height/2),
                            new Point(pictureBox1.Width/2 + r/2 , pictureBox1.Height/2),
                            new Point(pictureBox1.Width/2 + r/2 , pictureBox1.Height/2 +r),
                            new Point(pictureBox1.Width/2 - r/2 , pictureBox1.Height/2 +r),
                            new Point(pictureBox1.Width/2 - r/2 , pictureBox1.Height/2)
                            };
            Point[] star =
            {
                new Point(pictureBox1.Width/2  , pictureBox1.Height/2 - radius - r ),
                new Point(pictureBox1.Width/2 + r/2 -5  , pictureBox1.Height/2 - radius - r  - 5),
                new Point(pictureBox1.Width/2 + r/2 , pictureBox1.Height/2 - radius - 3*r/2  ),
                new Point(pictureBox1.Width/2 + r/2 +5 , pictureBox1.Height/2 -radius -r -5 ),
                new Point(pictureBox1.Width/2 + r  , pictureBox1.Height/2 - radius -r),
                new Point(pictureBox1.Width/2 + r/2 +5 , pictureBox1.Height/2 -radius - r +5),
                new Point(pictureBox1.Width/2 + r/2 , pictureBox1.Height/2 -radius -r  +15),
                new Point(pictureBox1.Width/2 + r/2 -5 , pictureBox1.Height/2 -radius -r +5)
            };
            Point[] Firsttriangle1 =
            {
                new Point(140 , pictureBox1.Height/2 -radius +20),
                new Point(140-circle , pictureBox1.Height/2-radius-circle),
                new Point(140 +circle , pictureBox1.Height/2 - radius- circle),
            };
            Point[] Firsttriangle2 =
            {
                new Point(140, pictureBox1.Height/2 -radius - circle- 20),
                new Point(140 -circle , pictureBox1.Height/2-radius  ),
                new Point(140+circle ,pictureBox1.Height/2 - radius)
            };
            Point[] secondtriangle1 =
            {
                new Point(pictureBox1.Width- 140 , pictureBox1.Height/2 -radius +20-20),
                new Point(pictureBox1.Width-140-circle , pictureBox1.Height/2-radius-circle-20),
                new Point(pictureBox1.Width-140 +circle , pictureBox1.Height/2 - radius- circle-20),
            };
            Point[] secondtriangle2 =
            {
                new Point(pictureBox1.Width-140, pictureBox1.Height/2 -radius - circle- 20-20),
                new Point(pictureBox1.Width-140 -circle , pictureBox1.Height/2-radius -20 ),
                new Point(pictureBox1.Width-140+circle ,pictureBox1.Height/2 - radius-20)
            };
            Point[] thirdtriangle1 =
            {
                new Point(pictureBox1.Width-140 -140, pictureBox1.Height/2 +radius -20 +20),
                new Point(pictureBox1.Width-140-circle-140 , pictureBox1.Height/2+radius+circle+20),
                new Point(pictureBox1.Width-140 +circle-140 , pictureBox1.Height/2 + radius+ circle+20),
            };
            Point[] thirdtriangle2 =
            {
                new Point(pictureBox1.Width-140 -140, pictureBox1.Height/2 +radius + circle+ 20 +20),
                new Point(pictureBox1.Width-140 -140 -circle , pictureBox1.Height/2+radius +20 ),
                new Point(pictureBox1.Width-140 -140+circle ,pictureBox1.Height/2 + radius+20)
            };
            Point[] lasttriangle1 =
            {
                new Point(140 + 40 , pictureBox1.Height/2 +radius -20),
                new Point(140-circle+40 , pictureBox1.Height/2+radius+circle),
                new Point(140 +circle +40, pictureBox1.Height/2 + radius+ circle),
            };
            Point[] lastriangle2 =
            {
                new Point(140 +40, pictureBox1.Height/2 +radius + circle+ 20),
                new Point(140 -circle +40 , pictureBox1.Height/2+radius  ),
                new Point(140+circle +40,pictureBox1.Height/2 + radius)
            };

            pictureBox1.BackColor = Color.Blue;
            e.Graphics.DrawRectangle(pen, label1.Location.X-1, label1.Location.Y - 1, label1.Width + 2, label1.Height + 1);
            e.Graphics.FillPolygon(new SolidBrush(Color.Yellow), p);
            e.Graphics.FillPolygon(green, arr);
            e.Graphics.FillPolygon(green, star);
            e.Graphics.FillEllipse(sb, 40, 40, circle, circle);
            e.Graphics.FillEllipse(sb, 200, 30, circle, circle);
            e.Graphics.FillEllipse(sb, pictureBox1.Width/2 +radius +r , 60, circle, circle);
            e.Graphics.FillEllipse(sb, pictureBox1.Width - 80, pictureBox1.Height / 2 - radius, circle, circle);
            e.Graphics.FillEllipse(sb, pictureBox1.Width - 200, pictureBox1.Height / 2 + radius, circle, circle);
            e.Graphics.FillEllipse(sb, pictureBox1.Width - 80, pictureBox1.Height - 80, circle,circle);
            e.Graphics.FillEllipse(sb, 280, pictureBox1.Height / 2 + 2 * radius, circle, circle);
            e.Graphics.FillEllipse(sb, 60, pictureBox1.Height / 2 + 2 * radius + 20, circle, circle);
            e.Graphics.FillPolygon(red, Firsttriangle1);
            e.Graphics.FillPolygon(red, Firsttriangle2);
            e.Graphics.FillPolygon(red, secondtriangle1);
            e.Graphics.FillPolygon(red, secondtriangle2);
            e.Graphics.FillPolygon(red, thirdtriangle1);
            e.Graphics.FillPolygon(red, thirdtriangle2);
            e.Graphics.FillPolygon(red, lasttriangle1);
            e.Graphics.FillPolygon(red, lastriangle2);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 5), pictureBox1.Location.X+2, pictureBox1.Location.Y+2, pictureBox1.Width-20, pictureBox1.Height-44);
        }
    }
}
