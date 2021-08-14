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
    public partial class Clc : Form
    {
        double resultValue = 0;
        string operationPerf = "";
        bool isOperationPerf = false;
        public Clc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            if ((textBox_Result.Text == "0") || isOperationPerf )
            {
                textBox_Result.Clear();
            }
            isOperationPerf = false;
            Button button = (Button)sender;
            if (button.Text==".")
            {
                if (!textBox_Result.Text.Contains("."))
                    textBox_Result.Text = textBox_Result.Text + button.Text;
            }
            else
            {
                textBox_Result.Text = textBox_Result.Text + button.Text;
            }
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                btnEqual.PerformClick();
                operationPerf = button.Text;
                currentOperation.Text = resultValue + " " + operationPerf;
                isOperationPerf = true;
            }
            else
            {
                operationPerf = button.Text;
                resultValue = double.Parse(textBox_Result.Text);
                currentOperation.Text = resultValue + " " + operationPerf;
                isOperationPerf = true;
            }
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerf)
            {
                case "+":
                    textBox_Result.Text = (resultValue + double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (resultValue - double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (resultValue / double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (resultValue * double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(textBox_Result.Text);
            currentOperation.Text = "";
        }
    }
}
