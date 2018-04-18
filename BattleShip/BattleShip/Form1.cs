using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class Form1 : Form
    {
        List<Point>[] ship = new List<Point>[6];
        List<Point>[] damage = new List<Point>[6];
        List<Point>[] position = new List<Point>[10];
        List<Point>[] dead = new List<Point>[10];
        Button[,] btn = new Button[10, 10];
        Button[,] right = new Button[10, 10];
        bool[,] korabl1  = new bool[10,10];
        bool[,] odino4ka = new bool[10, 10];
        bool[,] rightenable = new bool[10, 10];
        bool[,] enable = new bool[10, 10];
        bool[,] shoot = new bool[10, 10];
        Random random = new Random();
        string dimen;
        enum Boat
        {
            one,two,three,four
        };
        bool access = true;
        int x, y;
        int four = 1;
        int three = 2;
        int two = 3;
        int one = 4;
        bool dimension = true;
        Boat boat = Boat.four;

        public Form1()
        {
            InitializeComponent();
            for (int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    btn[j, i] = new Button();
                    enable[j, i] = true;
                    shoot[j, i] = false;
                    odino4ka[j, i] = false;
                    btn[j, i].Location = new Point(j * 25 + 25, i * 25 + 25);
                    btn[j, i].Size = new Size(25,25);
                    btn[j, i].BackColor = Color.White;
                    btn[j, i].Click += new System.EventHandler(SetPoisition);
                    Controls.Add(btn[j, i]);
                }
            }
            for (int i = 0; i < 6; i++)
            {
                ship[i] = new List<Point>();
                damage[i] = new List<Point>();
            }
            for (int i = 0; i < 10; i++) 
            {
                position[i] = new List<Point>();
                dead[i] = new List<Point>();
            }
            label1.Text = one.ToString();
            label2.Text = two.ToString();
            label3.Text = three.ToString();
            label4.Text = four.ToString();
            label5.Text = "horizontal";
        }



        private void SetPoisition( object sender, EventArgs e)
        {
            Button asd = sender as Button;
            for(int i=0; i<10; i++)
            {
                for(int  j =0; j<10; j++)
                {

                    if(asd == btn[j,i] && dimension && enable[j,i])
                    {
                        switch (boat)
                        {
                            case Boat.one:
                                if (one > 0 && enable[j,i] )
                                {
                                    enable[j, i] = false;
                                    enable[Math.Max(0, j - 1), i] = false;
                                    enable[Math.Min(9, j + 1), i] = false;
                                    position[4 - one].Add(new Point(j, i));
                                    dead[4 - one].Add(new Point(j, i));
                                    for(int k =Math.Max(0, j - 1); k <=Math.Min(9, j + 1); k++)
                                    {
                                        enable[k,Math.Max(0, i-1)] = false;
                                        enable[k, Math.Min(9, i +1)] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    asd.Enabled = false;
                                    one--;
                                }
                                break;
                            case Boat.two:
                                if (two > 0 && j+1<10 && enable[Math.Min(9,j+1),i])
                                {
                                    asd.BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 1), i].BackColor = Color.Blue;
                                    enable[j, i] = false;
                                    enable[Math.Max(0, j - 1), i] = false;
                                    enable[Math.Min(9, j + 2), i] = false;
                                    position[3 - two + 4].Add(new Point(j, i));
                                    position[3 - two + 4].Add(new Point(j+1, i));
                                    dead[3 - two + 4].Add(new Point(j, i));
                                    dead[3 - two + 4].Add(new Point(j + 1, i));
                                    for (int k =Math.Max(0, j - 1); k <=Math.Min(9, j + 2); k++)
                                    {
                                        enable[k,Math.Max(0, i - 1)] = false;
                                        enable[k,Math.Min(9, i + 1)] = false;
                                    }
                                    asd.Enabled = false;
                                    btn[Math.Min(9, j + 1), i].Enabled = false;
                                    two--;
                                }
                                break;
                            case Boat.three:
                                if (three > 0 && j+2<10 && enable[Math.Min(9, j + 1), i] && enable[Math.Min(9,j+2),i])
                                {
                                    asd.BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 1), i].BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 2), i].BackColor = Color.Blue;
                                    enable[j, i] = false;
                                    enable[Math.Max(0, j - 1), i] = false;
                                    enable[Math.Min(9, j + 3), i] = false;
                                    position[2 - three + 7].Add(new Point(j, i));
                                    position[2 - three + 7].Add(new Point(j + 1, i));
                                    position[2 - three + 7].Add(new Point(j + 2, i));
                                    dead[2 - three + 7].Add(new Point(j, i));
                                    dead[2 - three + 7].Add(new Point(j + 1, i));
                                    dead[2 - three + 7].Add(new Point(j + 2, i));
                                    for (int k =Math.Max(0, j - 1); k <= Math.Min(9, j + 3); k++)
                                    {
                                        enable[k, Math.Max(0, i - 1)] = false;
                                        enable[k, Math.Min(9, i + 1)] = false;
                                    }
                                    asd.Enabled = false;
                                    btn[Math.Min(9, j+1), i ].Enabled = false;  
                                    btn[Math.Min(9, j+2), i ].Enabled = false;
                                    three--;
                                }
                                break;
                            case Boat.four:
                                if (four > 0 && j+3<10 && enable[Math.Min(9,j+3),i] && enable[Math.Min(9, j + 1), i] && enable[Math.Min(9, j + 2), i])
                                {
                                    enable[j, i] = false;
                                    enable[Math.Max(0, j - 1), i] = false;
                                    enable[Math.Min(9, j + 4), i] = false;

                                    position[1 - four + 9].Add(new Point(j, i));
                                    position[1 - four + 9].Add(new Point(j + 1, i));
                                    position[1 - four + 9].Add(new Point(j + 2, i));
                                    position[1 - four + 9].Add(new Point(j + 3, i));
                                    dead[1 - four + 9].Add(new Point(j, i));
                                    dead[1 - four + 9].Add(new Point(j + 1, i));
                                    dead[1 - four + 9].Add(new Point(j + 2, i));
                                    dead[1 - four + 9].Add(new Point(j + 3, i));

                                    for (int k =Math.Max(0, j - 1); k <= Math.Min(9, j + 4); k++)
                                    {
                                        enable[k, Math.Max(0, i - 1)] = false;
                                        enable[k, Math.Min(9, i + 1)] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 1), i].BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 2), i].BackColor = Color.Blue;
                                    btn[Math.Min(9, j + 3), i].BackColor = Color.Blue;
                                    asd.Enabled = false;
                                    btn[Math.Min(9, j + 1), i].Enabled = false;
                                    btn[Math.Min(9, j + 2), i].Enabled = false;
                                    btn[Math.Min(9, j + 3), i].Enabled = false;
                                    four--;
                                }
                                break;
                        }
                    }
                    if(asd == btn[j, i] && !dimension && enable[j, i])
                    {
                        switch (boat)
                        {
                            case Boat.one:
                                if (one > 0 && enable[j,i])
                                {
                                    enable[j, i] = false;
                                    enable[j,Math.Max(0, i-1)] = false;
                                    enable[j,Math.Min(9, i+1)] = false;
                                    position[4 - one].Add(new Point(j, i));
                                    dead[4 - one].Add(new Point(j, i));
                                    for (int k = Math.Max(0, i - 1); k <=Math.Min(9, i + 1); k++)
                                    {
                                        enable[Math.Max(0, j-1), k] = false;
                                        enable[Math.Min(9, j+1), k] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    asd.Enabled = false;
                                    one--;
                                }
                                break;
                            case Boat.two:
                                if (two > 0 && i+1<10 &&  enable[j,Math.Min(9,i+1)])
                                {
                                    enable[j, i] = false;
                                    enable[j, Math.Max(0, i - 1)] = false;
                                    enable[j, Math.Min(9, i + 2)] = false;

                                    position[3 - two + 4].Add(new Point(j, i));
                                    position[3 - two + 4].Add(new Point(j, i + 1));
                                    dead[3 - two + 4].Add(new Point(j, i));
                                    dead[3 - two + 4].Add(new Point(j, i + 1));

                                    for (int k = Math.Max(0, i - 1); k <= Math.Min(9, i + 2); k++)
                                    {
                                        enable[Math.Max(0, j - 1), k] = false;
                                        enable[Math.Min(9, j + 1), k] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 1)].BackColor = Color.Blue;
                                    asd.Enabled = false;
                                    btn[j, Math.Min(9, i + 1)].Enabled = false;
                                    two--;
                                }
                                break;
                            case Boat.three:
                                if (three > 0 && i+2<10 && enable[j,Math.Min(9,i+2)] && enable[j, Math.Min(9, i + 1)])
                                {
                                    enable[j, i] = false;
                                    enable[j, Math.Max(0, i - 1)] = false;
                                    enable[j, Math.Min(9, i + 3)] = false;

                                    position[2 - three + 7].Add(new Point(j, i));
                                    position[2 - three + 7].Add(new Point(j, i + 1));
                                    position[2 - three + 7].Add(new Point(j, i + 2));
                                    dead[2 - three + 7].Add(new Point(j, i));
                                    dead[2 - three + 7].Add(new Point(j, i + 1));
                                    dead[2 - three + 7].Add(new Point(j, i + 2));

                                    for (int k = Math.Max(0, i - 1); k <= Math.Min(9, i + 3); k++)
                                    {
                                        enable[Math.Max(0, j - 1), k] = false;
                                        enable[Math.Min(9, j + 1), k] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 1)].BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 2)].BackColor = Color.Blue; asd.Enabled = false;
                                    btn[j, Math.Min(9, i + 1)].Enabled = false;
                                    btn[j, Math.Min(9, i + 2)].Enabled = false;
                                    three--;
                                }
                                break;
                            case Boat.four:
                                if (four > 0 && i+3<10 && enable[j,Math.Min(9,i+3)] && enable[j, Math.Min(9, i + 1)] && enable[j, Math.Min(9, i + 2)])
                                {
                                    enable[j, i] = false;
                                    enable[j, Math.Max(0, i - 1)] = false;
                                    enable[j, Math.Min(9, i + 4)] = false;

                                    position[1 - four + 9].Add(new Point(j, i));
                                    position[1 - four + 9].Add(new Point(j, i+1));
                                    position[1 - four + 9].Add(new Point(j, i+2));
                                    position[1 - four + 9].Add(new Point(j, i+3));
                                    dead[1 - four + 9].Add(new Point(j, i));
                                    dead[1 - four + 9].Add(new Point(j , i+1));
                                    dead[1 - four + 9].Add(new Point(j , i+2));
                                    dead[1 - four + 9].Add(new Point(j , i+3));

                                    for (int k = Math.Max(0, i - 1); k <= Math.Min(9, i + 4); k++)
                                    {
                                        enable[Math.Max(0, j - 1), k] = false;
                                        enable[Math.Min(9, j + 1), k] = false;
                                    }
                                    asd.BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 1)].BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 2)].BackColor = Color.Blue;
                                    btn[j, Math.Min(9, i + 3)].BackColor = Color.Blue;
                                    asd.Enabled = false;
                                    btn[j, Math.Min(9, i + 1)].Enabled = false;
                                    btn[j, Math.Min(9, i + 2)].Enabled = false;
                                    btn[j, Math.Min(9, i + 3)].Enabled = false;
                                    four--;
                                }
                                break;
                        }
                    }
                }
            }
            label1.Text = one.ToString();
            label2.Text = two.ToString();
            label3.Text = three.ToString();
            label4.Text = four.ToString();
            if(one ==0  && two ==0  && three == 0 && four == 0)
            {
                button6.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            if (four == 0)
            {
                button4.Enabled = false;
                if (one != 0) boat = Boat.one;
                if (two != 0) boat = Boat.two;
                if (three != 0) boat = Boat.three;
                
            }
            if (three == 0)
            {
                button3.Enabled = false;
                if (four != 0) boat = Boat.four;
                if (one != 0) boat = Boat.one;
                if(two!=0) boat = Boat.two;
            }
            if (two == 0)
            {
                button2.Enabled = false;
                if (three != 0) boat = Boat.three;
                if (four != 0) boat = Boat.four;
                if (one != 0) boat = Boat.one;
            }
            if (one == 0)
            {
                button1.Enabled = false;
                if (two != 0) boat = Boat.two;
                if (three != 0) boat = Boat.three;
                if(four!=0) boat = Boat.four;
            }
        }
        private void RightMatrix(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            button6.Visible = false;
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    btn[j, i].Size = new Size(33, 33);
                    btn[j, i].Location = new Point(j * 33 + 33, i * 33 + 33);
                    btn[j, i].Enabled = false;
                }
            }
            for(int i=0; i<10; i++)
            {
                for(int j=0; j <10; j++)
                {
                    rightenable[j, i] = true;
                    korabl1[j, i] = false;
                    right[j, i] = new Button();
                    right[j, i].Size = new Size(33, 33);
                    right[j, i].Location = new Point(j * 33 + 440, i * 33 + 33);
                    right[j, i].BackColor = Color.Yellow;
                    right[j, i].Click += new System.EventHandler(PlayerClick);
                    Controls.Add(right[j, i]);
                }
            }
            ComputerPosition();
        }
        private void ComputerPosition()
        {
            for (int i = 0; i < 4; i++)
            {
                access = true;
                while (access)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                    if (rightenable[x, y])
                    {
                        odino4ka[x, y] = true;
                        for(int k= Math.Max(0, x - 1); k <= Math.Min(9, x + 1); k++)
                        {
                            rightenable[k, Math.Max(0, y - 1)] = false;
                            rightenable[k, Math.Min(9, y + 1)] = false;
                            rightenable[k, y] = false;
                        }
                        access = false;
                    }
                }
            }
            access = true;
            for (int i = 0; i < 3; i++)
            {
                access = true;
                if (random.Next(0, 11) % 2 == 0)
                {
                    dimen = "horiz";
                }
                else
                {
                    dimen = "vert";
                }
                while (access)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                    if (dimen == "horiz" && x < 9)
                    {
                        if (rightenable[x, y] && dimen == "horiz" && rightenable[x + 1, y] && x != 9)
                        {
                            korabl1[x, y] = true;
                            korabl1[x + 1, y] = true;
                            ship[i].Add(new Point(x, y));
                            ship[i].Add(new Point(x+1, y));
                            damage[i].Add(new Point(x, y));
                            damage[i].Add(new Point(x+1, y));
                            for (int k = Math.Max(0, x - 1); k <= Math.Min(9, x + 2); k++)
                            {
                                rightenable[k, Math.Max(0, y - 1)] = false;
                                rightenable[k, y] = false;
                                rightenable[k, Math.Min(9, y + 1)] = false;
                            }
                            access = false;
                        }
                    }
                    if (dimen == "vert" && y < 9)
                    {
                        if (rightenable[x, y] && dimen == "vert" && rightenable[x, y + 1] && y != 9)
                        {
                            korabl1[x, y] = true;
                            korabl1[x, y + 1] = true;
                            ship[i].Add(new Point(x, y));
                            ship[i].Add(new Point(x , y+1));
                            damage[i].Add(new Point(x, y));
                            damage[i].Add(new Point(x , y+1));
                            for (int k = Math.Max(0, y - 1); k <= Math.Min(9, y + 2); k++)
                            {
                                rightenable[Math.Max(0, x - 1), k] = false;
                                rightenable[x, k] = false;
                                rightenable[Math.Min(9, x + 1), k] = false;
                            }
                            access = false;
                        }
                    }
                }
            }
            access = true;
            for(int i=0; i<2; i++)
            {
                access = true;
                if (random.Next(0, 11) % 2 == 0)
                {
                    dimen = "horiz";
                }
                else
                {
                    dimen = "vert";
                }
                while (access)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                    if (dimen == "horiz" && x < 8)
                    {
                        if (rightenable[x, y] && dimen == "horiz" && rightenable[x + 1, y] && x != 8 && rightenable[x + 2, y])
                        {
                            korabl1[x, y] = true;
                            korabl1[x + 1, y] = true;
                            korabl1[x + 2, y] = true;
                            damage[i + 3].Add(new Point(x, y));
                            damage[i + 3].Add(new Point(x+1, y));
                            damage[i + 3].Add(new Point(x+2, y));
                            ship[i + 3].Add(new Point(x, y));
                            ship[i + 3].Add(new Point(x+1, y));
                            ship[i + 3].Add(new Point(x+2, y));
                            for (int k = Math.Max(0, x - 1); k <= Math.Min(9, x + 3); k++)
                            {
                                rightenable[k, Math.Max(0, y - 1)] = false;
                                rightenable[k, y] = false;
                                rightenable[k, Math.Min(9, y + 1)] = false;
                            }
                            access = false;
                        }
                    }
                    if (dimen == "vert" && y < 8)
                    {
                        if (rightenable[x, y] && dimen == "vert" && rightenable[x, y + 1] && y != 8 && rightenable[x, y + 2])
                        {
                            korabl1[x, y] = true;
                            korabl1[x, y + 1] = true;
                            korabl1[x, y + 2] = true;
                            damage[i + 3].Add(new Point(x, y));
                            damage[i + 3].Add(new Point(x, y+1));
                            damage[i + 3].Add(new Point(x , y+2));
                            ship[i + 3].Add(new Point(x, y));
                            ship[i + 3].Add(new Point(x , y+1));
                            ship[i + 3].Add(new Point(x , y+2));
                            for (int k = Math.Max(0, y - 1); k <= Math.Min(9, y + 3); k++)
                            {
                                rightenable[Math.Max(0, x - 1), k] = false;
                                rightenable[x, k] = false;
                                rightenable[Math.Min(9, x + 1), k] = false;
                            }
                            access = false;
                        }
                    }
                }
            }
            access = true;
            for(int i =0;i<1; i++)
            {
                access = true;
                if (random.Next(0, 11) % 2 == 0)
                {
                    dimen = "horiz";
                }
                else
                {
                    dimen = "vert";
                }
                while (access)
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                    if (dimen == "horiz" && x < 7)
                    {
                        if (rightenable[x, y] && dimen == "horiz" && rightenable[x + 1, y] && x != 7 && rightenable[x + 2, y] && rightenable[x + 3, y])
                        {
                            korabl1[x, y] = true;
                            korabl1[x + 1, y] = true;
                            korabl1[x + 2, y] = true;
                            korabl1[x + 3, y] = true;
                            ship[5].Add(new Point(x, y));
                            ship[5].Add(new Point(x+1, y));
                            ship[5].Add(new Point(x+2, y ));
                            ship[5].Add(new Point(x+3, y ));
                            damage[5].Add(new Point(x, y));
                            damage[5].Add(new Point(x+1, y ));
                            damage[5].Add(new Point(x+2, y ));
                            damage[5].Add(new Point(x+3, y ));
                            for (int k = Math.Max(0, x - 1); k <= Math.Min(9, x + 4); k++)
                            {
                                rightenable[k, Math.Max(0, y - 1)] = false;
                                rightenable[k, y] = false;
                                rightenable[k, Math.Min(9, y + 1)] = false;
                            }
                            access = false;
                        }
                    }
                    if (dimen == "vert" && y < 7)
                    {
                        if (rightenable[x, y] && dimen == "vert" && rightenable[x, y + 1] && y != 7 && rightenable[x, y + 2] && rightenable[x, y + 3])
                        {
                            korabl1[x, y] = true;
                            korabl1[x, y + 1] = true;
                            korabl1[x, y + 2] = true;
                            korabl1[x, y + 3] = true;
                            ship[5].Add(new Point(x, y));
                            ship[5].Add(new Point(x, y+1));
                            ship[5].Add(new Point(x, y+2));
                            ship[5].Add(new Point(x, y+3));
                            damage[5].Add(new Point(x, y));
                            damage[5].Add(new Point(x, y+1));
                            damage[5].Add(new Point(x, y+2));
                            damage[5].Add(new Point(x, y+3));
                            for (int k = Math.Max(0, y - 1); k <= Math.Min(9, y + 4); k++)
                            {
                                rightenable[Math.Max(0, x - 1), k] = false;
                                rightenable[x, k] = false;
                                rightenable[Math.Min(9, x + 1), k] = false;
                            }
                            access = false;
                        }
                    }
                }
            }
            access = true;
        }
        private void ComputerClick()
        {
            while (shoot[x, y])
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
            }
            if (btn[x, y].BackColor == Color.Blue)
            {
                btn[x, y].BackColor = Color.DarkOrange;
                shoot[x, y] = true;
                for (int k = 0; k < 10; k++)
                {
                    if (position[k].Contains(new Point(x, y)))
                    {
                        position[k].Remove(new Point(x, y));
                    }
                    if (position[k].Count == 0)
                    {
                        for (int l = 0; l < dead[k].Count; l++)
                        {
                            btn[dead[k][l].X, Math.Max(0, dead[k][l].Y - 1)].BackColor = Color.Aqua;
                            btn[dead[k][l].X, Math.Min(9, dead[k][l].Y + 1)].BackColor = Color.Aqua;
                            btn[Math.Max(0, dead[k][l].X - 1), dead[k][l].Y].BackColor = Color.Aqua;
                            btn[Math.Min(9, dead[k][l].X + 1), dead[k][l].Y].BackColor = Color.Aqua;
                            btn[Math.Max(0, dead[k][l].X - 1), Math.Max(0, dead[k][l].Y - 1)].BackColor = Color.Aqua;
                            btn[Math.Max(0, dead[k][l].X - 1), Math.Min(9, dead[k][l].Y + 1)].BackColor = Color.Aqua;
                            btn[Math.Min(9, dead[k][l].X + 1), Math.Max(0, dead[k][l].Y - 1)].BackColor = Color.Aqua;
                            btn[Math.Min(9, dead[k][l].X + 1), Math.Min(9, dead[k][l].Y + 1)].BackColor = Color.Aqua;
                            
                            shoot[dead[k][l].X, Math.Max(0, dead[k][l].Y - 1)] = true;
                            shoot[dead[k][l].X, Math.Min(9, dead[k][l].Y + 1)] = true;
                            shoot[Math.Max(0, dead[k][l].X - 1), dead[k][l].Y] = true;
                            shoot[Math.Min(9, dead[k][l].X + 1), dead[k][l].Y] = true;
                            shoot[Math.Max(0, dead[k][l].X - 1), Math.Max(0, dead[k][l].Y - 1)] = true;
                            shoot[Math.Max(0, dead[k][l].X - 1), Math.Min(9, dead[k][l].Y + 1)] = true;
                            shoot[Math.Min(9, dead[k][l].X + 1), Math.Max(0, dead[k][l].Y - 1)] = true;
                            shoot[Math.Min(9, dead[k][l].X + 1), Math.Min(9, dead[k][l].Y + 1)] = true;
                        }
                        for (int l = 0; l < dead[k].Count; l++)
                        {
                            btn[dead[k][l].X, dead[k][l].Y].BackColor = Color.Red;
                        }
                    }

                }
                ComputerClick();
            }
            else
            {
                shoot[x, y] = true;
                btn[x, y].BackColor = Color.Aqua;
            }
        }
        private void PlayerClick(object sender, EventArgs e)
        {
            Button asd = sender as Button;
            for (int y = 0; y < 10; y++) 
            {
                for (int x = 0; x < 10; x++)
                {
                    if(asd == right[x, y])
                    {
                        if (korabl1[x, y] || odino4ka[x,y])
                        {
                            if(odino4ka[x,y])
                            {
                                right[Math.Max(0, x - 1), y].BackColor = Color.Aqua;
                                right[Math.Max(0, x - 1), y].Enabled = false;
                                right[x, y].Enabled = false;
                                right[Math.Max(0, x + 1), y].Enabled = false;
                                right[Math.Max(0, x + 1), y].BackColor = Color.Aqua;
                                for (int k = Math.Max(0, x - 1); k <= Math.Min(9, x + 1); k++)
                                {
                                    right[k, Math.Min(9, y + 1)].BackColor = Color.Aqua;
                                    right[k, Math.Max(0, y - 1)].BackColor = Color.Aqua;
                                    right[k, Math.Min(9, y + 1)].Enabled = false;
                                    right[k, Math.Max(0, y - 1)].Enabled = false;
                                    right[k, y].Enabled = false;
                                }
                                right[x, y].BackColor = Color.Red;
                                break;
                            }
                            right[x, y].BackColor = Color.DarkOrange;
                            right[x, y].Enabled = false;
                            for (int k = 0; k < 6; k++)
                            {
                                if (ship[k].Contains(new Point(x, y)))
                                {
                                    ship[k].Remove(new Point(x, y));
                                }
                                if (ship[k].Count == 0)
                                {
                                    for (int l = 0; l < damage[k].Count; l++)
                                    {
                                        right[damage[k][l].X, Math.Max(0, damage[k][l].Y - 1)].BackColor = Color.Aqua;
                                        right[damage[k][l].X, Math.Min(9, damage[k][l].Y + 1)].BackColor = Color.Aqua;
                                        right[Math.Max(0, damage[k][l].X - 1), damage[k][l].Y].BackColor = Color.Aqua;
                                        right[Math.Min(9, damage[k][l].X + 1), damage[k][l].Y].BackColor = Color.Aqua;
                                        right[Math.Max(0, damage[k][l].X - 1), Math.Max(0, damage[k][l].Y - 1)].BackColor = Color.Aqua;
                                        right[Math.Max(0, damage[k][l].X - 1), Math.Min(9, damage[k][l].Y + 1)].BackColor = Color.Aqua;
                                        right[Math.Min(9, damage[k][l].X + 1), Math.Max(0, damage[k][l].Y - 1)].BackColor = Color.Aqua;
                                        right[Math.Min(9, damage[k][l].X + 1), Math.Min(9, damage[k][l].Y + 1)].BackColor = Color.Aqua;

                                        right[damage[k][l].X, Math.Max(0, damage[k][l].Y - 1)].Enabled = false;
                                        right[damage[k][l].X, Math.Min(9, damage[k][l].Y + 1)].Enabled = false;
                                        right[Math.Max(0, damage[k][l].X - 1), damage[k][l].Y].Enabled = false;
                                        right[Math.Min(9, damage[k][l].X + 1), damage[k][l].Y].Enabled = false;
                                        right[Math.Max(0, damage[k][l].X - 1), Math.Max(0, damage[k][l].Y - 1)].Enabled = false;
                                        right[Math.Max(0, damage[k][l].X - 1), Math.Min(9, damage[k][l].Y + 1)].Enabled = false;
                                        right[Math.Min(9, damage[k][l].X + 1), Math.Max(0, damage[k][l].Y - 1)].Enabled = false;
                                        right[Math.Min(9, damage[k][l].X + 1), Math.Min(9, damage[k][l].Y + 1)].Enabled = false;

                                    }
                                    for (int l = 0; l < damage[k].Count; l++)
                                    {
                                        right[damage[k][l].X, damage[k][l].Y].BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                        else
                        {
                            right[x, y].BackColor = Color.Aqua;
                            right[x, y].Enabled = false;
                            ComputerClick();
                        }
                    }
                }
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            boat = Boat.one;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            boat = Boat.four;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            boat = Boat.three;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            boat = Boat.two;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dimension == true)
            {
                dimension = false;
                label5.Text = "Vertical";
            }
            else
            {
                dimension = true;
                label5.Text = "Horizontal";
            }
        }
    }
}
