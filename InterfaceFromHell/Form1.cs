using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfaceFromHell
{
    public partial class Form1 : Form
    {
        private Form2 secondForm;

        public Form1()
        {
            InitializeComponent();
            secondForm = new Form2();

            //When you click the third button it should open the second form
            button3.Click += btnOpenSecondForm__Click;

            //Title of the page
            labelTitle.Font = new Font("Arial", 16, FontStyle.Bold); 
            labelTitle.ForeColor = Color.Red;
            this.BackColor = Color.Green;
        }

        private void btnOpenSecondForm__Click(object sender, EventArgs e)
        { 
            // Close the first form
            this.Hide();

                      // Show the second form
            secondForm.Show();
        }
    }
}


