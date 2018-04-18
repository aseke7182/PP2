using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minigame2
{
    public partial class Form1 : Form
    {
        int timer;
        Graphics g;
        Random random = new Random();
        int tool;
        Pen pen;
        int x, y;
        int size;
        int score;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer = int.Parse(label2.Text) - 1;
            label2.Text = timer.ToString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (tool == 0)
            {
                if ( e.X>= x && x +size>= e.X   && e.Y >=y && y + size >= e.Y )
                {
                    score += 1;
                    label1.Text = "Score: " + score.ToString();
                }
                else
                {
                    score -= 1;
                    label1.Text = "Score: " + score;
                }
            }
            else
            {
                score -= 1;
                label1.Text = "Score: " + score;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tool =  random.Next(0, 2);
            x = random.Next(0, 450);
            y = random.Next(0, 400);
            size = random.Next(10, 100);
            if (tool == 0)
            {
                pen = new Pen(Color.Blue, 3);
            }
            else
            {
                pen = new Pen(Color.Red, 3);
            }
            Refresh();
            g.DrawRectangle(pen, x, y, size, size);
        }
    }
}
