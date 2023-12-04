using System;
using System.Drawing;
using System.Windows.Forms;

namespace InterfaceFromHell
{
    public partial class Form3 : Form
    {
        private Label dynamicLabel1;
        private Label dynamicLabel2;
        private Label dynamicLabel3;

        public Form3()
        {
            InitializeComponent();

            // Create the first dynamic label
            dynamicLabel1 = new Label();
            dynamicLabel1.Text = "Not Here!";
            dynamicLabel1.Font = new Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold);
            dynamicLabel1.AutoSize = true;
            dynamicLabel1.Location = new Point(50, 50);
            dynamicLabel1.Click += DynamicLabel1_Click;

            // Add the first dynamic label to the form
            this.Controls.Add(dynamicLabel1);
            pictureBox1.Visible = false;
            
        }

        private void DynamicLabel1_Click(object sender, EventArgs e)
        {
            // Hide the first dynamic label
            pictureBox1.Visible = false;
            dynamicLabel1.Visible = false;

            // Create and show the second dynamic label
            dynamicLabel2 = new Label();
            dynamicLabel2.Text = "Not Here!";
            dynamicLabel2.Font = new Font("Arial", 12, FontStyle.Bold);
            dynamicLabel2.Location = new Point(400, 250);
            dynamicLabel2.BackColor = Color.Blue;
            dynamicLabel2.Click += DynamicLabel2_Click;

            // Add the second dynamic label to the form
            Controls.Add(dynamicLabel2);
        }

        private void DynamicLabel2_Click(object sender, EventArgs e)
        {
            // Hide the second dynamic label
            dynamicLabel2.Visible = false;
            pictureBox1.Visible = true;


            //Create and show the thrid dynamic label
            dynamicLabel3 = new Label();
            dynamicLabel3.Text = "Found Me!";
            dynamicLabel3.Font = new Font("Arial", 25, FontStyle.Bold);
            dynamicLabel3.Size = new Size(200,50);
            dynamicLabel3.Location= new Point (200, 50);
            Controls.Add(dynamicLabel3);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            pictureBox1.Click += PictureBox_Click;
            
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Handle the click event for the PictureBox if needed
            Application.Exit();
        }
    }
}


