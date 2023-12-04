using System;
using System.Drawing;
using System.Windows.Forms;

namespace Presidents
{
    public partial class Form1 : Form
    {
        private RadioButton[] presidentRadioButtons;
        private TextBox[] presidentGuessTextBoxes;

        public Form1()
        {
            InitializeComponent();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            //picture box customization
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.MouseEnter += pictureBox_MouseEnter;
            pictureBox.MouseLeave += pictureBox_MouseLeave;
            pictureBox.BringToFront();

            exitButton.Click += exitButton_Click;
            // Create an array to store the existing radio buttons
            presidentRadioButtons = new RadioButton[]
            {
                radioButton1, radioButton2, radioButton3, radioButton4,
                radioButton5, radioButton6, radioButton7, radioButton8,
                radioButton9, radioButton10, radioButton11, radioButton12,
                radioButton13, radioButton14, radioButton15, radioButton16
            };
            //Create an array to store the eisting textboxes
            presidentGuessTextBoxes = new TextBox[]
            {
                textBox1, textBox2, textBox3, textBox4,
                textBox5, textBox6, textBox7, textBox8,
                textBox9, textBox10, textBox11, textBox12,
                textBox13, textBox14, textBox15, textBox16
            };

            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Make sure the array length matches the number of your existing radio buttons

            // Update the text of each radio button with president names
            for (int i = 0; i < presidentRadioButtons.Length; i++)
            {
                presidentRadioButtons[i].AutoSize = true;
                presidentRadioButtons[i].CheckedChanged += PresidentRadioButton_CheckedChanged;
                presidentRadioButtons[i].Tag = i;
                
            }

            for (int i = 0; i < presidentGuessTextBoxes.Length; i++)
            {
                presidentGuessTextBoxes[i].Tag = i;

                // Attach an event handler to each textbox
                presidentGuessTextBoxes[i].TextChanged += PresidentGuessTextBox_TextChanged;
            }

            allRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;
            democratRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;
            republicanRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;
            dRepublicanRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;
            federalistRadioButton.CheckedChanged += FilterRadioButton_CheckedChanged;

            //adds the controls to the filterbox
            filterGroupBox.Controls.AddRange(new Control[]
            {
                allRadioButton, democratRadioButton, republicanRadioButton,
                dRepublicanRadioButton, federalistRadioButton
            });

            timer1.Interval = 1000; 
            timer1.Tick += Timer_Tick;

            // Set up the progress bar
            toolStripProgressBar.Minimum = 0;
            toolStripProgressBar.Maximum = 100;
            toolStripProgressBar.Value = toolStripProgressBar.Maximum;
            toolStripProgressBar.Step = 1;

            foreach (var textBox in presidentGuessTextBoxes)
            {
                textBox.TextChanged += TextBox_TextChanged;
            }
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            // Start the timer when the user begins typing in any textbox
            timer1.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Decrement the progress bar value with each tick
            toolStripProgressBar.Value -= toolStripProgressBar.Step;

            // Check if the progress bar has reached its minimum value
            if (toolStripProgressBar.Value <= toolStripProgressBar.Minimum)
            {
                // Stop the timer when the progress reaches the minimum
                timer1.Stop();

                // Reset the progress bar for future use
                toolStripProgressBar.Value = toolStripProgressBar.Maximum;

                
                Application.Restart();
            }
        }


        private void PresidentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Handle radio button checked change event
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // Get the index associated with the radio button
                int presidentIndex = Array.IndexOf(presidentRadioButtons, radioButton);

                // Load the corresponding president's image into the PictureBox
                pictureBox.Image = GetPresidentImage(presidentIndex);

                // Set the Wikipedia article link for the selected president
                SetWikipediaLinkForPresident(presidentIndex);
            }
        }

        private const int ZoomFactor = 100; 


        private void pictureBox_MouseEnter(object sender, EventArgs e)
        {
            // Increase the size of the PictureBox when the mouse enters
            pictureBox.Width += ZoomFactor;
            pictureBox.Height += ZoomFactor;

            // Center and zoom the content after the size change
            CenterAndZoomWebBrowser();
        }

        private void pictureBox_MouseLeave(object sender, EventArgs e)
        {
            // Restore the original size of the PictureBox when the mouse leaves
            pictureBox.Width -= ZoomFactor;
            pictureBox.Height -= ZoomFactor;

            // Center and zoom the content after the size change
            CenterAndZoomWebBrowser();
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }


        private void CenterAndZoomWebBrowser()
        {
          
            string script = @"
        var contentDiv = document.getElementById('content');
        if (contentDiv) {
            contentDiv.style.margin = 'auto';
            contentDiv.style.width = '100%'; // Adjust the width as needed
        }
    ";

            // Execute the JavaScript code in the WebBrowser control
            webBrowser.Document?.InvokeScript("execScript", new Object[] { script, "JavaScript" });
        }

        private void SetWikipediaLinkForPresident(int presidentIndex)
        {
            // Construct the Wikipedia URL for the selected president
            string wikipediaUrl = GetWikipediaUrlForPresident(presidentIndex);

            // Display the Wikipedia URL as the text in the group box
            wikipediaGroupBox.Text = wikipediaUrl;

            // Navigate to the Wikipedia URL in the WebBrowser control
            webBrowser.Navigate(wikipediaUrl);

            // Attach an event handler for the DocumentCompleted event
            webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Center and zoom the content after the document is fully loaded
            CenterAndZoomWebBrowser();
        }

        private string GetWikipediaUrlForPresident(int presidentIndex)
        {
            
             https://en.wikipedia.org/wiki/President_Name
            string presidentName = GetPresidentName(presidentIndex);
            return $"https://en.wikipedia.org/wiki/{presidentName}";
        }

        private string GetPresidentName(int presidentIndex)
        {
            //array of presidents that link to the url above
            string[] presidentNames = {"Benjamin_Harrison", "Franklin_D_Roosevelt", "William_J_Clinton", "James_Buchanan",
                "Franklin_Pierce", "George_W_Bush", "Barack_Obama", "John_F_Kennedy", "William_McKinely", "Ronald_Reagan",
                "Dwight_D_Eisenhower", "Martin_VanBuren", "George_Washington", "John Adams", "Theodore_Roosevelt", "Thomas_Jefferson"
            };

            if (presidentIndex >= 0 && presidentIndex < presidentNames.Length)
            {
                return presidentNames[presidentIndex];
            }

            return string.Empty; 
        }


        private void PresidentGuessTextBox_TextChanged(object sender, EventArgs e)
        {
            // Handle textbox text changed event
            if (sender is TextBox textBox)
            {
                // Get the index associated with the textbox
                int presidentIndex = (int)textBox.Tag;

                // Get the correct answer for the current president
                int correctAnswer = GetCorrectAnswerForPresident(presidentIndex);

                // Handle the user's input for president number
                // Compare the user's input with the correct answer
                int userInput;
                if (int.TryParse(textBox.Text, out userInput))
                {
                    if (userInput == correctAnswer)
                    {
                        // Clear any previous error
                        errorProvider.SetError(textBox, string.Empty);
                    }
                    else
                    {
                        // Set error message
                        errorProvider.SetError(textBox, "Incorrect number. Try again.");
                    }
                }
                else
                {
                    // Set error message
                    errorProvider.SetError(textBox, "Please enter a valid number.");
                }
            }
        }

        private void FilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Handle radio button checked change event for filtering
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // Get the selected affiliation index
                int affiliationIndex = Convert.ToInt32(radioButton.Tag);

                // Filter the displayed presidents based on the selected affiliation index
                FilterPresidentsByAffiliation(affiliationIndex);
            }
        }

        private void FilterPresidentsByAffiliation(int affiliationIndex)
        {
            // Iterate through all presidents and show/hide them based on the affiliation
            for (int i = 0; i < presidentRadioButtons.Length; i++)
            {
                
                bool showPresident = IsPresidentOfSelectedAffiliation(i,affiliationIndex);

                // Set the visibility of the president's controls (radio button, textbox, etc.)
                
                presidentGuessTextBoxes[i].Visible = showPresident;

                
            }
        }

        private bool IsPresidentOfSelectedAffiliation(int presidentIndex, int affiliationIndex)
        {
            switch (affiliationIndex)
            {
                case 0: // Case 0: Show all
                    return true;
                case 1: // Case 1: Show Democrats
                    return IsDemocrat(presidentIndex);
                case 2: // Case 2: Show Republicans
                    return IsRepublican(presidentIndex);
                case 3: // Case 3: Show Democratic-Republicans
                    return IsDemocraticRepublican(presidentIndex);
                case 4: // Case 4: Show Federalists
                    return IsFederalist(presidentIndex);
                default:
                    return false; // Handle other cases if needed
            }
        }

        private bool IsDemocrat(int presidentIndex)
        {
            return presidentIndex == 1 || presidentIndex == 2 || presidentIndex == 3 || presidentIndex == 4 || presidentIndex == 6 || presidentIndex == 7 || presidentIndex == 11;
        }

        private bool IsRepublican(int presidentIndex)
        {
            return presidentIndex == 0 || presidentIndex == 5 || presidentIndex == 8 || presidentIndex == 9 || presidentIndex == 10 || presidentIndex == 14;
        }

        private bool IsDemocraticRepublican(int presidentIndex)
        {
            return presidentIndex == 15;
        }

        private bool IsFederalist(int presidentIndex)
        {
            return presidentIndex == 12 || presidentIndex == 13;
        }

        
        private int GetCorrectAnswerForPresident(int presidentIndex)
        {
            // Use a switch statement to handle each president
            switch (presidentIndex)
            {
                case 0:
                    return 23;
                case 1:
                    return 32;
                case 2:
                    return 42;
                case 3:
                    return 15;
                case 4:
                    return 14;
                case 5:
                    return 43;
                case 6:
                    return 44;
                case 7:
                    return 35;
                case 8:
                    return 25;
                case 9:
                    return 40;
                case 10:
                    return 34;
                case 11:
                    return 8;
                case 12:
                    return 1;
                case 13:
                    return 2;
                case 14:
                    return 26;
                case 15:
                    return 3;
               //for when index is out of range
                default:
                    return -1;
            }
        }

        private Image GetPresidentImage(int index)
        {
            switch (index)
            {
                case 0:
                    return Presidents.Properties.Resources.BenjaminHarrison;
                case 1:
                    return Presidents.Properties.Resources.FranklinDRoosevelt;
                case 2:
                    return Presidents.Properties.Resources.WilliamJClinton;
                case 3:
                    return Presidents.Properties.Resources.JamesBuchanan;
                case 4:
                    return Presidents.Properties.Resources.FranklinPierce;
                case 5:
                    return Presidents.Properties.Resources.GeorgeWBush;
                case 6:
                    return Presidents.Properties.Resources.BarackObama;
                case 7:
                    return Presidents.Properties.Resources.JohnFKennedy;
                case 8:
                    return Presidents.Properties.Resources.WilliamMcKinley;
                case 9:
                    return Presidents.Properties.Resources.RonaldReagan;
                case 10:
                    return Presidents.Properties.Resources.DwightDEisenhower;
                case 11:
                    return Presidents.Properties.Resources.MartinVanBuren;
                case 12:
                    return Presidents.Properties.Resources.GeorgeWashington;
                case 13:
                    return Presidents.Properties.Resources.JohnAdams;
                case 14:
                    return Presidents.Properties.Resources.TheodoreRoosevelt;
                case 15:
                    return Presidents.Properties.Resources.ThomasJefferson;
                //for when index is out of range
                default:
                    return Presidents.Properties.Resources.BenjaminHarrison;
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
