using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfaceFromHell
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.Click += Form2_Click;
            this.KeyPress += Form2_KeyPress;
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            // Change the background color to a random color
            Random random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            this.BackColor = randomColor;
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is '3'
            if (e.KeyChar == '3')
            {

                // Open or navigate to Form3
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
