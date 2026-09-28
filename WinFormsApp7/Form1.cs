using System;
using System.Globalization;
using System.Windows.Forms;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        double firstNumber = 0;
        string operation = "";
        bool newNumber = true;

        public Form1()
        {
            InitializeComponent();

            button1.Click += Number_Click;
            button2.Click += Number_Click;
            button3.Click += Number_Click;
            button4.Click += Number_Click;
            button5.Click += Number_Click;
            button6.Click += Number_Click;
            button7.Click += Number_Click;
            button8.Click += Number_Click;
            button9.Click += Number_Click;
            button10.Click += Number_Click;

            button11.Click += Decimal_Click;

            button12.Click += Operation_Click;
            button13.Click += Operation_Click;
            button14.Click += Operation_Click;
            button15.Click += Operation_Click;

            button16.Click += Sqrt_Click;
            button17.Click += Percent_Click;
            button18.Click += Square_Click;

            button19.Click += Equals_Click;
            button20.Click += Clear_Click;

            buttonx.Click += Backspace_Click;
        }

        private void Number_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button =
                (System.Windows.Forms.Button)sender;

            if (newNumber)
            {
                if (operation != "")
                {
                    richTextBox1.Text += button.Text;
                }
                else
                {
                    richTextBox1.Text = button.Text;
                }

                newNumber = false;
            }
            else
            {
                richTextBox1.Text += button.Text;
            }
        }

        private void Decimal_Click(object sender, EventArgs e)
        {
            if (newNumber)
            {
                if (operation != "")
                {
                    richTextBox1.Text += "0.";
                }
                else
                {
                    richTextBox1.Text = "0.";
                }

                newNumber = false;
                return;
            }

            string currentText = richTextBox1.Text;

            int lastSpace = currentText.LastIndexOf(' ');

            string currentNumber;

            if (lastSpace >= 0)
            {
                currentNumber = currentText.Substring(lastSpace + 1);
            }
            else
            {
                currentNumber = currentText;
            }

            if (!currentNumber.Contains("."))
            {
                richTextBox1.Text += ".";
            }
        }

        private void Operation_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button =
                (System.Windows.Forms.Button)sender;

            if (!double.TryParse(
                GetCurrentNumber(),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out firstNumber))
            {
                MessageBox.Show("Düzgün ədəd daxil edin.");
                return;
            }

            operation = button.Text;

            richTextBox1.Text =
                firstNumber.ToString(CultureInfo.InvariantCulture)
                + " "
                + operation
                + " ";

            newNumber = true;
        }

        private void Equals_Click(object sender, EventArgs e)
        {
            if (operation == "")
            {
                return;
            }

            string secondNumberText = GetCurrentNumber();

            if (!double.TryParse(
                secondNumberText,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double secondNumber))
            {
                MessageBox.Show("Düzgün ədəd daxil edin.");
                return;
            }

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("0-a bölmək olmaz!");
                        return;
                    }

                    result = firstNumber / secondNumber;
                    break;

                default:
                    return;
            }

            string expression =
                firstNumber.ToString(CultureInfo.InvariantCulture)
                + " "
                + operation
                + " "
                + secondNumber.ToString(CultureInfo.InvariantCulture)
                + " = "
                + result.ToString(CultureInfo.InvariantCulture);

            richTextBox1.Text =
                result.ToString(CultureInfo.InvariantCulture);

            listBox1.Items.Add(expression);

            firstNumber = result;
            operation = "";
            newNumber = true;
        }

        private void Sqrt_Click(object sender, EventArgs e)
        {
            string numberText = GetCurrentNumber();

            if (!double.TryParse(
                numberText,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double number))
            {
                MessageBox.Show("Düzgün ədəd daxil edin.");
                return;
            }

            if (number < 0)
            {
                MessageBox.Show(
                    "Mənfi ədədin kvadrat kökü yoxdur.");
                return;
            }

            double result = Math.Sqrt(number);

            richTextBox1.Text =
                result.ToString(CultureInfo.InvariantCulture);

            listBox1.Items.Add(
                "Sqrt("
                + number.ToString(CultureInfo.InvariantCulture)
                + ") = "
                + result.ToString(CultureInfo.InvariantCulture));

            firstNumber = result;
            operation = "";
            newNumber = true;
        }

        private void Percent_Click(object sender, EventArgs e)
        {
            string numberText = GetCurrentNumber();

            if (!double.TryParse(
                numberText,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double number))
            {
                MessageBox.Show("Düzgün ədəd daxil edin.");
                return;
            }

            double result = number / 100;

            richTextBox1.Text =
                result.ToString(CultureInfo.InvariantCulture);

            listBox1.Items.Add(
                number.ToString(CultureInfo.InvariantCulture)
                + "% = "
                + result.ToString(CultureInfo.InvariantCulture));

            firstNumber = result;
            operation = "";
            newNumber = true;
        }

        private void Square_Click(object sender, EventArgs e)
        {
            string numberText = GetCurrentNumber();

            if (!double.TryParse(
                numberText,
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out double number))
            {
                MessageBox.Show("Düzgün ədəd daxil edin.");
                return;
            }

            double result = number * number;

            richTextBox1.Text =
                result.ToString(CultureInfo.InvariantCulture);

            listBox1.Items.Add(
                number.ToString(CultureInfo.InvariantCulture)
                + "^2 = "
                + result.ToString(CultureInfo.InvariantCulture));

            firstNumber = result;
            operation = "";
            newNumber = true;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";

            firstNumber = 0;
            operation = "";
            newNumber = true;
        }

        private void Backspace_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
            {
                richTextBox1.Text =
                    richTextBox1.Text.Substring(
                        0,
                        richTextBox1.Text.Length - 1);
            }

            if (richTextBox1.Text.Length == 0)
            {
                firstNumber = 0;
                operation = "";
                newNumber = true;
            }
        }

        private string GetCurrentNumber()
        {
            string text = richTextBox1.Text.Trim();

            int lastSpace = text.LastIndexOf(' ');

            if (lastSpace >= 0)
            {
                return text.Substring(lastSpace + 1).Trim();
            }

            return text;
        }

        private void richTextBox1_TextChanged(
            object sender,
            EventArgs e)
        {
        }
    }
}