using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace l1TAuFR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = "";
        Compiler сompiler = new Compiler();
        List<Token> tokens;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Файлы txt (*.txt)|*.txt";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = File.ReadAllText(dialog.FileName);
                richTextBox1.Text = path;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            textBox3.Text = "";
            try
            {
                if (richTextBox1.Text == "")
                    throw new Exception($"Заполните \"Анализируемый код\" или загрузите файл .txt");
                tokens = сompiler.LeksemAnalyzer(richTextBox1.Text);
                for (int i = 0; i < tokens.Count; i++)
                    richTextBox2.Text += $"{tokens[i]}\r\n";
                сompiler.BottomupAnalyzer();
                сompiler.bottomupAnalyzer.Analyzer();
                foreach (string g in сompiler.bottomupAnalyzer.Matr)
                    richTextBox3.Text += g + "\r\n";
            }
            catch (Exception err)
            {
                textBox3.Text = $"{err.Message}";
            }
        }
    }
}
