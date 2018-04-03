using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool point,oper,equal;
        string operation;
        double last,first,final,second,memory;
        int cnt;
        public Form1()
        {
            InitializeComponent();
            point = true;
            oper = false;
            equal = false;
            operation = "";
            final = 0;
            first = 0;
            second = 0;
            memory = 0;
            last = 0;
            cnt = 0;
        }

        private void Number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (oper)
            {
                textBox1.Text = "0";
                oper = false;
                point = true;
            }
            if (textBox1.Text[0] == '0' && !textBox1.Text.Contains("0,"))
            {
                    textBox1.Text = "";
            }
            textBox1.Text = textBox1.Text + btn.Text;
        }
        private void plusORminus(object sender, EventArgs e)
        {
            textBox1.Text = (int.Parse(textBox1.Text) * (-1)).ToString();
        }
        private void Cancel(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
            }
        }
        private void FastWrite(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "Sqrt":
                    textBox1.Text = Math.Sqrt(double.Parse(textBox1.Text)).ToString();
                    break;
                case "cos":
                    textBox1.Text = Math.Cos(double.Parse(textBox1.Text) / 180 * Math.PI).ToString();
                    break;
                case "sin":
                    textBox1.Text = Math.Sin(double.Parse(textBox1.Text) / 180 * Math.PI).ToString();
                    break;
                case "tan":
                    textBox1.Text = Math.Tan(double.Parse(textBox1.Text) / 180 * Math.PI).ToString();
                    break;
                case "x!":
                    double sum = 1;
                    if (double.Parse(textBox1.Text) == Math.Round(double.Parse(textBox1.Text)))
                    {
                        for(int i=1; i <= double.Parse(textBox1.Text); i++)
                        {
                            sum = sum * i;
                        }
                    }
                    else
                    {
                        sum = Math.Sqrt(2 * Math.PI * double.Parse(textBox1.Text)) * Math.Pow(double.Parse(textBox1.Text) / Math.E, double.Parse(textBox1.Text));
                    }
                    textBox1.Text = sum.ToString();
                    break;
                case "1/x":
                    textBox1.Text = Math.Pow(double.Parse(textBox1.Text), -1).ToString();
                    break;
                case "10^x":
                    textBox1.Text = Math.Pow(10, double.Parse(textBox1.Text)).ToString();
                    break;
                case "x^2":
                    textBox1.Text = Math.Pow(double.Parse(textBox1.Text), 2).ToString();
                    break;
                case "e^x":
                    textBox1.Text = Math.Exp(double.Parse(textBox1.Text)).ToString();
                    break;
            }
        }
        private void Clear(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "CE":
                    textBox1.Text = "0";
                    break;
                case "C":
                    textBox1.Text = "0";
                    point = true;
                    oper = false;
                    operation = "";
                    final = 0;
                    first = 0;
                    second = 0;
                    memory = 0;
                    break;
            }
        }
        private void Memory(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Text)
            {
                case "M+":
                    memory = memory + double.Parse(textBox1.Text);
                    button36.Enabled = true;
                    button35.Enabled = true;
                    break;
                case "M-":
                    memory = memory - double.Parse(textBox1.Text);
                    button36.Enabled = true;
                    button35.Enabled = true;
                    break;
                case "MS":
                    memory = double.Parse(textBox1.Text);
                    button36.Enabled = true;
                    button35.Enabled = true;
                    break;
                case "MC":
                    memory = 0;
                    button36.Enabled = false;
                    button35.Enabled = false;
                    break;
                case "MR":
                    textBox1.Text = memory.ToString();
                    break;
            }

        }
        private void Point(object sender, EventArgs e)
        {
            if (point)
            {
                textBox1.Text = textBox1.Text + ',';
                point = false;
            }
        }
        public void Equal(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains(','))
            {
                for(int i=textBox1.Text.Length-1; i >=0; i--)
                {
                    if (textBox1.Text[i] =='0')
                    {
                        textBox1.Text = textBox1.Text.Remove(i);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            second = double.Parse(textBox1.Text);
            if (!equal)
            {
                last = second;
            }
            switch (operation)
            {
                case "+":
                    final = first + last;
                    textBox1.Text = final.ToString();
                    break;
                case "*":
                    final = first * last;
                    textBox1.Text = final.ToString();
                    break;
                case "/":
                    final = first / last;
                    textBox1.Text = final.ToString();
                    break;
                case "-":
                    final = first - last;
                    textBox1.Text = final.ToString();
                    break;
                case "logx(y)":
                    final = Math.Log(last, first);
                    textBox1.Text = final.ToString();
                    break;
                case "x^y":
                    final = Math.Pow(first,last);
                    textBox1.Text = final.ToString();
                    break;
                case "x^(1/y)":
                    final = Math.Pow(first, 1/last);
                    textBox1.Text = final.ToString();
                    break;
                case "xmod(y)":
                    final = first % last;
                    textBox1.Text = final.ToString();
                    break; 
            }
            first = double.Parse(textBox1.Text);
            oper = true;
            equal = true;
            cnt = 0;
        }
        private void Operator(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (first != 0 && cnt == 0)
            {
                Equal(btn, e);
                cnt++;
            }
            first = double.Parse(textBox1.Text) ;
            oper = true;
            operation = btn.Text;
            equal = false;
        }
    }
}
