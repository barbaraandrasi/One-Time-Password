using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OTP
{
    public partial class Form1 : Form
    {
        private readonly string NUMS = "0123456789";
        private readonly int LENGTH = 5;
        private readonly Random RANDOM;
        
        private OneTimePassword oneTimePassword;
        
        public Form1()
        {
            InitializeComponent();
            RANDOM = new Random();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string value = textBox1.Text;
            string message = "";
            if (value == oneTimePassword.Value)
            {
                if (oneTimePassword.Valid)
                {
                    oneTimePassword.Valid = false;
                    message = "Login succeed!";
                }
                else
                {
                    message = "Login failed: password expired!";               
                }
            }
            else
            {
                message = "Login failed: wrong password!";
            }
            if (MessageBox.Show(message) == DialogResult.OK)
            {
                textBox1.Text = "";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            oneTimePassword = new OneTimePassword()
            {
                Value = generateValue(),
                Valid = true
            };
            if (MessageBox.Show(oneTimePassword.Value) == DialogResult.OK)
            {
                textBox1.Text = "";
            }
        }

        private string generateValue()
        {
            string value = "";
            for (int i = 0; i < LENGTH; i++)
            {
                value += NUMS[RANDOM.Next(NUMS.Length)];
            }
            return value;
        }

    }
}
