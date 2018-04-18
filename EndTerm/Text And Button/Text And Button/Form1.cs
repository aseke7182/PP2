using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Text_And_Button
{
    public partial class Form1 : Form
    {
        int cnt = 0;
        Random random = new Random();
        int x, y;
        int b;
        int a;
        Button[] btn = new Button[1000001];
        TextBox[] txt = new TextBox[10000001];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button asd = sender as Button;
            
            
                for (int i = 1; i < 100000; i++)
                {
                    if (asd == btn[i])
                    {
                            txt[i - 1].Text = "Hello";
                      
                    }
                }
            }
        
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cnt++;
            if (cnt % 2 == 1)
            {
                x = random.Next(0, 450);
                y = random.Next(0, 400);
                b = cnt ;
                txt[b] = new TextBox();
                txt[b].Location = new Point(x, y);
                txt[b].Text = b.ToString();
                Controls.Add(txt[b]);
            }
            else
            {
                x = random.Next(0, 450);
                y = random.Next(0, 400);
                a = cnt;
                btn[a] = new Button();
                btn[a].Location = new Point(x, y);
                btn[a].Text = a.ToString();
                btn[a].Click += new System.EventHandler(this.button1_Click);
                Controls.Add(btn[a]);
            }
        }
    }
}
