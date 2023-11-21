using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 *Controls
 *TeacherButton
 *StudentButton
 *ImageList
 *SplitContainer
 *FlowLayoutPanel
 *Panel
 *ToolStrip
 *ToolStripLinkLabel
 *ToolStripButton
 *EmailLabel
 *PhotoGroupBox
 *PhotopictureBox
 *PlusImage
 *MinusImage
 *PeopleGlobals.dll
 *EditPerson.dll
 *
 */
namespace DYnamic_People
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Globals.AddPeopleSampleData();

            this.teacherButton.Click += new EventHandler(TeacherButton__Click);
            this.studentButton.Click += new EventHandler(StudentButton__Click);

            this.panel1.Visible = false;
        }

        private void TeacherButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            foreach(KeyValuePair<string,Person> keyValuePair in Globals.people.sortedList)
            {
                if(keyValuePair.Value.GetType() == typeof(Teacher))
                {
                    AddPanel(keyValuePair.Value);
                }
            }
        }
        private void StudentButton__Click(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            foreach (KeyValuePair<string, Person> keyValuePair in Globals.people.sortedList)
            {
                if (keyValuePair.Value.GetType() == typeof(Student))
                {
                    AddPanel(keyValuePair.Value);
                }
            }
            studentButton.Text = this.flowLayoutPanel1.Controls.Count.ToString();
        }

        private void ToolStripButton1__Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = (ToolStripButton) sender;
            Panel p = (Panel)tsb.Tag;

            if (tsb.Checked)
            {
                tsb.Image = global::DYnamic_People.Properties.Resources.plus;
                p.Size = new System.Drawing.Size(189, 159);
                tsb.Checked = false;
            }
            else
            {
                tsb.Image = global::DYnamic_People.Properties.Resources.minus;
                p.Size = new System.Drawing.Size(189, 159);
            }

            p.Refresh();

        }

        private void ToolStripLabel1__Click(object sender, EventArgs e)
        {
            ToolStripLabel tsl = (ToolStripLabel) sender;
            Panel p = (Panel)tsl.Tag;

            PersonEditForm pef = new PersonEditForm((Person)p.Tag, this);
            pef.Visible = false;

            pef.ShowDialog();

            Person person = pef.formPerson;

            p.Controls.Clear();

            AddPersonToPanel(ref p, person);

            p.Refresh();
        }

        private void AddPanel(Person person)
        {
            Panel panel1 = new System.Windows.Forms.Panel();



            this.flowLayoutPanel1.Controls.Add(panel1);
            this.flowLayoutPanel1.Controls.SetChildIndex(panel1, flowLayoutPanel1.Controls.Count);

        }

        private void AddPersonToPanel(ref Panel panel, Person person)
        {
            ToolStrip toolStrip1 = new System.Windows.Forms.ToolStrip();
            ToolStripButton toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ToolStripLabel toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            Label emailLabel = new System.Windows.Forms.Label();
            GroupBox photoGroupBox = new System.Windows.Forms.GroupBox();
            PictureBox photoPictureBox = new System.Windows.Forms.PictureBox();
        }
    }
}
