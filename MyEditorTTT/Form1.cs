using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace MyEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.newToolStripMenuItem.Click += new EventHandler(NewToolStripMenuItem__Click);
            this.openToolStripMenuItem.Click += new EventHandler(OpenToolStripMenuItem__Click);
            this.saveToolStripMenuItem.Click += new EventHandler(SaveToolStripMenuItem__Click);
            this.exitToolStripMenuItem.Click += new EventHandler(ExitToolStripMenuItem__Click);

            this.copyToolStripMenuItem.Click += new EventHandler(CopyToolStripMenuItem__Click);
            this.cutToolStripMenuItem.Click += new EventHandler(CutToolStripMenuItem__Click);
            this.pasteToolStripMenuItem.Click += new EventHandler(PasteToolStripMenuItem__Click);

            this.boldToolStripMenuItem.Click += new EventHandler(BoldToolStripMenuItem__Click);
            this.italicsToolStripMenuItem.Click += new EventHandler(ItalicsToolStripMenuItem__Click);
            this.underlineToolStripMenuItem.Click += new EventHandler(UnderlineToolStripMenuItem__Click);

            this.mSSansSerifToolStripMenuItem.Click += new EventHandler(MSSansSerifToolStripMenuItem__Click);
            this.timesNewRomanToolStripMenuItem.Click += new EventHandler(TimesNewRomanToolStripMenuItem__Click);

            this.testToolStripButton.Click += new EventHandler(TestToolStripButton__Click);

            this.richTextBox1.SelectionChanged += new EventHandler(RichTextBox1__SelectionChanged);

            this.countdownLabel.Visible = false;

            this.timer.Tick += new EventHandler(Timer__tick);

            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(ToolStrip__ItemClicked);
            this.Text = "MyEditor";
        }

        private void NewToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            this.Text = "MyEditor";
        }

        private void BoldToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Bold;
            Font selectionFont = null;

            selectionFont = richTextBox1.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox1.Font;
            }
            SetSelectionFont(fontStyle, !selectionFont.Bold);
        }
        private void TestToolStripButton__Click(object sender, EventArgs e)
        {
            this.timer.Interval = 500;

            this.toolStripProgressBar1.Value = 60;

            this.countdownLabel.Text = "3";
            this.countdownLabel.Visible = true;
            this.richTextBox1.Visible = false;

            for (int i = 3; i > 0; --i)
            {
                this.countdownLabel.Text = i.ToString();
                this.Refresh();
                Thread.Sleep(1000);
            }

            this.countdownLabel.Visible = false;
            this.richTextBox1.Visible = true;

            this.timer.Start();
        }
        //
        private void Timer__tick(object sender, EventArgs e)
        {
            --this.toolStripProgressBar1.Value;

            if (this.toolStripProgressBar1.Value == 0)
            {
                this.timer.Stop();
                string performance = "Congratulations! You typed " + Math.Round(this.richTextBox1.TextLength / 30.0,2) + " letters per second!";
                MessageBox.Show(performance);
            }
        }
        private void ItalicsToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Italic;
            Font selectionFont = null;

            selectionFont = richTextBox1.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox1.Font;
            }
            SetSelectionFont(fontStyle, !selectionFont.Italic);
        }
        private void UnderlineToolStripMenuItem__Click(object sender, EventArgs e)
        {
            FontStyle fontStyle = FontStyle.Underline;
            Font selectionFont = null;

            selectionFont = richTextBox1.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox1.Font;
            }
            SetSelectionFont(fontStyle, !selectionFont.Underline);
        }

        private void MSSansSerifToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("MS Sans Serif", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);

            richTextBox1.SelectionFont = newFont;
        }

        private void TimesNewRomanToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Font newFont = new Font("TImes New Roman", richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style);

            richTextBox1.SelectionFont = newFont;
        }

        private void RichTextBox1__SelectionChanged(object sender, EventArgs e)
        {
            if (this.richTextBox1.SelectionFont != null)
            {
                this.boldToolStripButton.Checked = richTextBox1.SelectionFont.Bold;
                this.italicsToolStripButton.Checked = richTextBox1.SelectionFont.Italic;
                this.underlineToolStripButton.Checked = richTextBox1.SelectionFont.Underline;
            }
            this.colorToolStripButton.BackColor = richTextBox1.SelectionColor;
        }

        private void OpenToolStripMenuItem__Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;

                if (openFileDialog.FileName.ToLower().Contains(".rtf"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }

                richTextBox1.LoadFile(openFileDialog.FileName, richTextBoxStreamType);

                this.Text = "My Editor (" + openFileDialog.FileName + ")";
            }
        }
        private void SaveToolStripMenuItem__Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = openFileDialog.FileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                RichTextBoxStreamType richTextBoxStreamType = RichTextBoxStreamType.RichText;

                if (saveFileDialog.FileName.ToLower().Contains(".rtf"))
                {
                    richTextBoxStreamType = RichTextBoxStreamType.PlainText;
                }

                richTextBox1.SaveFile(saveFileDialog.FileName, richTextBoxStreamType);

                this.Text = "My Editor (" + saveFileDialog.FileName + ")";
            }
        }
        private void ExitToolStripMenuItem__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CopyToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
        private void CutToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void PasteToolStripMenuItem__Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void ToolStrip__ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            FontStyle fontStyle = FontStyle.Regular;

            ToolStripButton toolStripButton = null;

            if (e.ClickedItem == this.boldToolStripButton)
            {
                fontStyle = FontStyle.Bold;
                toolStripButton = this.boldToolStripButton;

            }
            else if (e.ClickedItem == this.italicsToolStripButton)
            {
                fontStyle = FontStyle.Italic;
                toolStripButton = this.italicsToolStripButton;

            }
            else if (e.ClickedItem == this.underlineToolStripButton)
            {
                fontStyle = FontStyle.Underline;
                toolStripButton = this.underlineToolStripButton;

            }
            else if (e.ClickedItem == this.colorToolStripButton)
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                    colorToolStripButton.BackColor = colorDialog.Color;
                }

            }
            if (fontStyle != FontStyle.Regular)
            {
                toolStripButton.Checked = !toolStripButton.Checked;

                SetSelectionFont(fontStyle, toolStripButton.Checked);
            }
        }
        private void SetSelectionFont(FontStyle fontStyle, bool bSet)
        {
            Font newFont = null;
            Font selectionFont = null;

            selectionFont = richTextBox1.SelectionFont;
            if (selectionFont == null)
            {
                selectionFont = richTextBox1.Font;
            }
            if (bSet)
            {
                newFont = new Font(selectionFont, selectionFont.Style | fontStyle);

            }
            else
            {
                newFont = new Font(selectionFont, selectionFont.Style & ~fontStyle);
            }
            this.richTextBox1.SelectionFont = newFont;


        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

}

