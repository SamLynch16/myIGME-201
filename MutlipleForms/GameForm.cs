using System;
using System.Windows.Forms;

namespace MutlipleForms
{
    public partial class GameForm : Form
    {
        private int lowNumber;
        private int highNumber;
        private int targetNumber;
        private int elapsedTimeInSeconds;
        private int nGuesses;

        public GameForm(int lowNumber, int highNumber)
        {
            InitializeComponent();

            this.lowNumber = lowNumber;
            this.highNumber = highNumber;

            Random rand = new Random();
            targetNumber = rand.Next(lowNumber, highNumber + 1);

            toolStripProgressBar.Maximum = 45;
            toolStripProgressBar.Value = 45;

            timer.Interval = 500;
            timer.Tick += Timer_Tick;
            timer.Start();

            AcceptButton = guessButton; // Set the AcceptButton for Enter key functionality
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTimeInSeconds++;

            toolStripProgressBar.Value = Math.Max(0, 45 - elapsedTimeInSeconds);

            if (elapsedTimeInSeconds >= 45)
            {
                timer.Stop();
                MessageBox.Show("Time's up! Game over.");
                Close();
            }
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(guessTextBox.Text, out int userGuess))
            {
                nGuesses++;

                if (userGuess < targetNumber)
                {
                    outputLabel.Text = $"Your guess of {userGuess} was HIGH";
                }
                else if (userGuess > targetNumber)
                {
                    outputLabel.Text = $"Your guess of {userGuess} was LOW";
                }
                else
                {
                    timer.Stop();
                    MessageBox.Show($"Woohoo, you got it in {nGuesses} guesses!");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}




