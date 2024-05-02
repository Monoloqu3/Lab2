using System.Diagnostics;

namespace AplikacjaOkienkowa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double dzielna = Convert.ToDouble(textBox1.Text);
                double dzielnik = Convert.ToDouble(textBox2.Text);

                if (dzielnik == 0)
                {
                    throw new DivideByZeroException("Dzielnik r�wny 0 jest niedozwolony.");
                }

                double wynik = dzielna / dzielnik;
                textBox3.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Prosz� wprowadzi� poprawne liczby w pola 'Dzielna' i 'Dzielnik'.", "B��d formatu danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B��d formatu!";
                LogError(ex);

            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Dzielenie przez zero jest niedozwolone.", "B��d dzielenia przez zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B��d dzielenia!";
                LogError(ex);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst�pi� nieoczekiwany b��d: {ex.Message}", "B��d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B��d!";
                LogError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            string eventInfo = $"B��d: {ex.Message}";
            EventLog.WriteEntry("Application", eventInfo, EventLogEntryType.Error);
        }

    }
}
