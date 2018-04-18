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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button[,] btn = new  Button[6,6];
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 6; i++)
            {
                for (int j =0 ; j < 6; j++)
                {
                    btn[j,i] = new Button();
                    btn[j,i].Location = new Point(j * 50 + 50, i * 50 + 50);
                    btn[j,i].Size = new Size(45, 45);
                    btn[j,i].BackColor = Color.White;
                    btn[j,i].Click += new EventHandler(button1_Click);
                    Controls.Add(btn[j,i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button asd = sender as Button;
            if (asd.BackColor == Color.Black)
            {
                asd.BackColor = Color.White;
            }
            else
            {
                asd.BackColor = Color.Black;
            }
            for(int i=0; i<6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (asd == btn[j, i])
                    {
                        for (int k = 0; k < 6; k++)
                        {
                            if (btn[j, k].BackColor == Color.White)
                            {
                                btn[j, k].BackColor = Color.Black;
                            }
                            else
                            {
                                btn[j, k].BackColor = Color.White;
                            }
                        }
                        for(int l = 0; l < 6; l++)
                        {
                            if (btn[l,i].BackColor == Color.White)
                            {
                                btn[l,i].BackColor = Color.Black;
                            }
                            else
                            {
                                btn[l, i].BackColor = Color.White;
                            }
                        }
                    }
                }
            }

        }
    }
}
        
