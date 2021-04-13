using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
            Width = 450;
            Height = 400;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new System.Globalization.CultureInfo[]{System.Globalization.CultureInfo.GetCultureInfo("ru-Ru"),
                System.Globalization.CultureInfo.GetCultureInfo("en-US")};
            comboBox1.DisplayMember = "NativeName";
            comboBox1.ValueMember = "Name";
            if(!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }
        }
        public void OpenF()
        {
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == "")

                {
                    return;
                }
                else
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();

                }
            }
        }
        public void SaveF()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            { return; }
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен");
        }
        public void CopyF()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        public void CutF()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }
        public void PasteF()
        {
            richTextBox1.Paste();
        }
        public void ColorF()
        {
            colorDialog1.Color = richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.SelectionColor = colorDialog1.Color;

            }
        }
        public void FontF()
        {
            fontDialog1.Font = richTextBox1.SelectionFont;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.SelectionFont = fontDialog1.Font;

            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveF();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenF();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveF();
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CutF();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            CutF();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyF();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CopyF();
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteF();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            PasteF();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorF();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontF();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            ColorF();
        }

        private void тема1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font font = new Font("Arial", 16, FontStyle.Italic);
            richTextBox1.Font = font;
            fontDialog1.ShowColor = true;
            fontDialog1.Color = richTextBox1.SelectionColor;
        }

        private void тема2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font font = new Font("Times New Roman", 20, FontStyle.Strikeout);
            richTextBox1.Font = font;
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Green;
        }

        private void тема3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font font = new Font("Gungsuh", 14, FontStyle.Bold);
            richTextBox1.Font = font;
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.SelectionColor = Color.Violet;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            FontF();
        }

        private void toolStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show(MyRes.SwitchLanguageReguest, MyRes.SwitchLanguageTitle, MessageBoxButtons.YesNo)==
                System.Windows.Forms.DialogResult.Yes)
            {
                // this.Refresh();
                
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
                this.Close();
            }
        
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
