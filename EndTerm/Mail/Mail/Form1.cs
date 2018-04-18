using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mail
{
    public partial class Form1 : Form
    {
        int cnt = 0;
        string mail,mail2;
        string password,password2;
        List<string> mails = new List<string>();
        List<string> passwords = new List<string>();
        int right = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mails.Count; i++)
            {
                if (mails[i] == textBox3.Text )
                {
                    right++;
                }
            }
            for (int i = 0; i < passwords.Count; i++)
            {
                if (passwords[i] == textBox2.Text)
                {
                    right++;
                }
            }
            if (right == 2) {
                label4.Text = "Done";
            }
            else
            {
                label4.Text = "WRONG";
            }
            right = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Contains("@"))
            {
             //   cnt++;
                label3.Text = "OK";
               // if (cnt == 1)
                //{
                    mails.Add(textBox1.Text);
                    passwords.Add(textBox4.Text);
                   // mail = textBox1.Text;
                    //password = textBox4.Text;
               // }if(cnt ==2)
               // {
                 //   mail2 = textBox1.Text;
                  //  password2 = textBox4.Text;
                //}
            }
            else
            {
                label3.Text = "WRONG";
            }
        }
    }
}
