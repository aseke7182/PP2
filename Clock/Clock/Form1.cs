using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class Form1 : Form
    {
        Graphics g;
        int r = 150;
        int secondradius = 140;
        int minuteradius = 100;
        int hourradius = 50;
        int width;
        int height;
        int secondx , secondy;
        int seconddegree;
        int minutedegree;
        int hourdegree;
        int minutex,minutey;
        int hourx,houry;
        int numb=2;
        int numbx, numby;
        public Form1()
        {
            InitializeComponent();
            width = pictureBox1.Width / 2;
            height = pictureBox1.Height / 2;
            DateTime date = DateTime.Now;
            seconddegree = date.Second * 6 - 90;
            minutedegree = date.Minute * 6 - 90;
            hourdegree = date.Hour * 30 - 90;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new Pen(Color.Black, 4), width - r, height - r, 2 * r, 2 * r);

            secondx = width +  (int)(secondradius * Math.Cos(seconddegree * Math.PI / 180));
            secondy = height +  (int)(secondradius * Math.Sin(seconddegree * Math.PI / 180));

            minutex = width + (int)(minuteradius * Math.Cos(minutedegree * Math.PI / 180));
            minutey = height + (int)(minuteradius * Math.Sin(minutedegree * Math.PI / 180));

            hourx = width + (int)(hourradius * Math.Cos(hourdegree * Math.PI / 180));
            houry = height + (int)(hourradius * Math.Sin(hourdegree * Math.PI / 180));

            e.Graphics.DrawLine(new Pen(Color.Red, 2), width, height, secondx, secondy);
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), width, height, minutex, minutey);
            e.Graphics.DrawLine(new Pen(Color.Black, 3), width, height, hourx, houry);
            for(int i=0; i<360; i += 6)
            {
                if (i % 30 == 0)
                {
                    numbx = width + (int)((secondradius-10) * Math.Cos(i * Math.PI / 180));
                    numby = height + (int)((secondradius-10) * Math.Sin(i * Math.PI / 180));
                    numb += 1;
                    if (numb == 13) numb = 1;
                    e.Graphics.DrawString(numb.ToString(), DefaultFont, new SolidBrush(Color.Black), numbx, numby);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconddegree += 6;
            if((seconddegree+90 )% 360==0)
            {
                minutedegree += 6;
            }
            if((minutedegree+90) % 360 == 0)
            {
                if ((seconddegree + 90) % 360 == 0)
                {
                    hourdegree += 30;
                }
            }
            pictureBox1.Refresh();
        }
    }
}
