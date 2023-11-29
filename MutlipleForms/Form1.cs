using System;
using System.Windows.Forms;

namespace MutlipleForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Validate input for low and high numbers
            if (!int.TryParse(lowTextBox.Text, out int lowNumber) || !int.TryParse(highTextBox.Text, out int highNumber) || lowNumber >= highNumber)
            {
                MessageBox.Show("Invalid input. Please enter valid low and high numbers.");
                return;
            }

            // Create and show the GameForm
            GameForm gameForm = new GameForm(lowNumber, highNumber);
            gameForm.ShowDialog();
        }

        private void LowTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys in the lowTextBox
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void HighTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits and control keys in the highTextBox
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

