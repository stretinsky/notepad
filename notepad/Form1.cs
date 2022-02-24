using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Form1 : Form
    {
        public static string filePath { get; private set; }
        bool isChanged = false;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingFileWithDialog();
        }
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show($"Сохранить файл {filePath}?",
                    "Notepad",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SavingFile();
                    if (isChanged)
                    {
                        return;
                    }
                }
                else if (result == DialogResult.No)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    filePath = openFileDialog1.FileName;
                    textBox1.LoadFile(filePath);
                    isChanged = false;
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            filePath = openFileDialog1.FileName;
            textBox1.LoadFile(filePath);
            isChanged = false;
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavingFile();
        }

        private void NewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show($"Сохранить файл {filePath}?",
                    "Notepad",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SavingFile();
                    if (isChanged)
                    {
                        return;
                    }
                }
                else if (result == DialogResult.No)
                {
                    filePath = null;
                    textBox1.Text = null;
                    isChanged = false;
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            filePath = null;
            textBox1.Text = null;
            isChanged = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show($"Сохранить файл {filePath}?",
                    "Notepad",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SavingFile();
                    if (!isChanged)
                    {
                        this.Close();
                    }   
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }
            this.Close();
        }
        private void SavingFile()
        {
            if (filePath != null)
            {
                textBox1.SaveFile(filePath);
                isChanged = false;
            }
            else
            {
                SavingFileWithDialog();
            }
        }
        private void SavingFileWithDialog()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filePath = saveFileDialog1.FileName;
            textBox1.SaveFile(filePath);
            isChanged = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isChanged)
            {
                DialogResult result = MessageBox.Show($"Сохранить файл {filePath}?",
                    "Notepad",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.None,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    SavingFile();
                    if (isChanged)
                    {
                        e.Cancel = true;
                    }
                }
                else if (result == DialogResult.No)
                {
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void lineBreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lineBreakToolStripMenuItem.Checked)
            {
                lineBreakToolStripMenuItem.Checked = false;                
            }
            else
            {
                lineBreakToolStripMenuItem.Checked = true;
            }
            textBox1.WordWrap = lineBreakToolStripMenuItem.Checked;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.SelectionFont = fontDialog1.Font;
                textBox1.SelectionColor = fontDialog1.Color;
                
            }
        }
        //sfa
    }
}
