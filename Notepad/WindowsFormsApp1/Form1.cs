using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SMIOpen_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                try
                {
                    StreamReader sr = new StreamReader(path);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops there was an error : " + ex.Message);
                }
            }
        }

        private void SMISave_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                try
                {
                    StreamWriter sw = new StreamWriter($"{path}",true);
                    foreach (var line in richTextBox1.Lines)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops there was an error : " + ex.Message);
                }
            }
        }

        private void SMIClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void SMISelectAll_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(".");
            foreach (Match match in regex.Matches(richTextBox1.Text))
            {
                richTextBox1.Select(match.Index,match.Length);
                richTextBox1.SelectionColor = Color.DarkOrange;
            }
        }

        
        private void SMIDateTime_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += $"{DateTime.Now}\n";
        }

        private void SMIFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void SMIZoomIn_Click(object sender, EventArgs e)
        {
            string fontFamily = richTextBox1.Font.FontFamily.ToString();
            float fontSize = richTextBox1.Font.Size;
            System.Drawing.Font font = new Font(fontFamily,++fontSize);
            richTextBox1.Font = font;
        }

        private void SMIZoomOut_Click(object sender, EventArgs e)
        {
            string fontFamily = richTextBox1.Font.FontFamily.ToString();
            float fontSize = richTextBox1.Font.Size;
            System.Drawing.Font font = new Font(fontFamily, --fontSize);
            richTextBox1.Font = font;
        }

        private void RichTextBox1_Click(object sender, EventArgs e)
        {
            Regex regex = new Regex(".");
            foreach (Match match in regex.Matches(richTextBox1.Text))
            {
                richTextBox1.Select(match.Index, match.Length);
                richTextBox1.SelectionColor = Color.Black;
            }
        }
    }
}
