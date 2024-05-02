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
                    throw new DivideByZeroException("Dzielnik równy 0 jest niedozwolony.");
                }

                double wynik = dzielna / dzielnik;
                textBox3.Text = wynik.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Proszê wprowadziæ poprawne liczby w pola 'Dzielna' i 'Dzielnik'.", "B³¹d formatu danych", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B³¹d formatu!";
                LogError(ex);

            }
            catch (DivideByZeroException ex)
            {
                MessageBox.Show("Dzielenie przez zero jest niedozwolone.", "B³¹d dzielenia przez zero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B³¹d dzielenia!";
                LogError(ex);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wyst¹pi³ nieoczekiwany b³¹d: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Text = "B³¹d!";
                LogError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            string eventInfo = $"B³¹d: {ex.Message}";
            EventLog.WriteEntry("Application", eventInfo, EventLogEntryType.Error);
        }

    }
}
