using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double num1 = 0;
        double num2 = 0;
        double result = 0;
        string op = "";
        bool opflag = false;
        bool eqflag=false;
        public Form1()
        {
            InitializeComponent();
            bttnExit.Click += bttnExit_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numberButton_Click(object sender, EventArgs e)
        {
            Button bttn = (Button)sender;
            if (lblDisplay.Text == "0" || opflag == true||eqflag==true)
            {
                lblDisplay.Text = bttn.Text;
                opflag = false;
                eqflag = false;
            }
            else
            {
                lblDisplay.Text = lblDisplay.Text + bttn.Text;
            }
        }



        private void bttnPeriod_Click_1(object sender, EventArgs e)
        {
            if (!lblDisplay.Text.Contains("."))
            {
                lblDisplay.Text = lblDisplay.Text + ".";
            }
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button bttn = (Button)sender;
            if (op != "")
            {
                num2 = Convert.ToDouble(lblDisplay.Text);
                compute();
            }
            num1 = Convert.ToDouble(lblDisplay.Text);
            op = bttn.Text;
            opflag = true;

        }

        private void bttnEqual_Click(object sender, EventArgs e)
        {
            num2 = Convert.ToDouble(lblDisplay.Text);
            compute();
            eqflag = true;
        }

        private void compute()
        {
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
            }
            //PROBLEMA CALCULARE CU VIRGULA
            lblDisplay.Text = result.ToString();
            op = "";
        }

        private void bttnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2= 0;
            result = 0;
            op = "";
            opflag= false;
            lblDisplay.Text = "0";
        }

        private void bttnSqrt_Click(object sender, EventArgs e)
        {
            num1=Convert.ToDouble(lblDisplay.Text);
            result = Math.Sqrt(num1);
            lblDisplay.Text = result.ToString();
        }

        private void bttnPlusNeg_Click(object sender, EventArgs e)
        {
            if(lblDisplay.Text != "0")
            {
                if (lblDisplay.Text.Contains("-"))
                {
                    lblDisplay.Text = lblDisplay.Text.Replace("-", "");
                }
                else
                {
                   lblDisplay.Text="-"+lblDisplay.Text;
                }
            }
        }

        private void bttnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
