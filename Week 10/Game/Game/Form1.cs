using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class MyGameForBonusPoint : Form
    {
        public MyGameForBonusPoint()
        {
            InitializeComponent();
        }
        Button b = new Button();
        int cnt = 0;
        List<Button> list = new List<Button>();
        private void Form1_Load(object sender, EventArgs e)
        {
            b.Location = new Point(0, Height -100);
            b.Size = new Size(30, 30);
            Controls.Add(b);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            Random rrr = new Random();
            int a = rrr.Next(0, Width-60);
            Button btn = new Button();
            btn.Location = new Point(a, 0);
            btn.Size = new Size(30, 30);
            btn.BackColor = System.Drawing.SystemColors.Highlight;
            Controls.Add(btn);
            list.Add(btn);
            label1.Text = "Score: "+ cnt.ToString();
            for (int i = 0; i < list.Count; i++)
            {
                if(Math.Abs(list[i].Location.X - b.Location.X)<= b.Width && Math.Abs(list[i].Location.Y - b.Location.Y) <= b.Height)
                {
                    trackBar1.Hide();
                    b.Hide();
                    for(int j=0; j<list.Count; j++)
                    {
                        list[j].Hide();
                    }
                    timer1.Stop();
                    timer2.Stop();
                    label2.Visible = true;
                    label3.Text += label1.Text.ToString();
                    label1.Visible = false;
                    label3.Visible = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for(int i=0; i < list.Count; i++)
            {
                if(list[i].Location.Y + 5 >= Height-100)
                {
                    list[i].Visible = false;
                }
                list[i].Location = new Point(list[i].Location.X,list[i].Location.Y +5);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            b.Location = new Point(trackBar1.Value*10, b.Location.Y);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
