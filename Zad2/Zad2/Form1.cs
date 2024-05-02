using System.Diagnostics;

namespace Zad2
{
    public partial class Kalkulator : Form
    {
        string input = string.Empty;
        string operand1 = string.Empty;
        string operand2 = string.Empty;
        char operation;
        double result = 0.0;
        public Kalkulator()
        {
            var watch = Stopwatch.StartNew();
            InitializeComponent();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            if (elapsedMs > 10) // prog wyzwolenia bledu
            {
                // Log to event log
                EventLog.WriteEntry("Application", "Inicjalizacja trwala zbyt dlugo: " + elapsedMs + "ms", EventLogEntryType.Warning);
            }
        }

        private void num_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            this.input += button.Text;
            textbox3.Text = input;
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operand1 = input;
            operation = button.Text[0];
            input = string.Empty;
        }

        private void equals_Click(object sender, EventArgs e)
        {
            operand2 = input;
            double num1, num2;
            double.TryParse(operand1, out num1);
            double.TryParse(operand2, out num2);

            switch (operation)
            {
                case '+':
                    result = num1 + num2;
                    textbox3.Text = result.ToString();
                    break;
                case '-':
                    result = num1 - num2;
                    textbox3.Text = result.ToString();
                    break;
                case '*':
                    result = num1 * num2;
                    textbox3.Text = result.ToString();
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        textbox3.Text = result.ToString();
                    }
                    else
                    {
                        textbox3.Text = "Nie dziel przez zero!";
                    }
                    break;
            }
            input = result.ToString();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            this.input = string.Empty;
            this.operand1 = string.Empty;
            this.operand2 = string.Empty;
            textbox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            num_Click(sender, e);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);

        }

        private void button15_Click(object sender, EventArgs e)
        {
            equals_Click(sender, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            clear_Click(sender, e);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            operator_Click(sender, e);

        }
    }
}
