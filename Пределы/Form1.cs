using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Пределы
{
    public partial class LimCalc : Form
    {
        public LimCalc()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void equals_button_Click(object sender, EventArgs e)
        {
            // Нажатие по кнопке равно
            /*
            // Берем значения числителя и знаменателя
            string numerator = textBox4.Text;
            string denominator = textBox2.Text;

            string args = $"\"{numerator}\" \"{denominator}\"";

            // создаем процесс
            Process process = new Process();

            // настраиваем свойства процесса
            process.StartInfo.FileName = "C:\\LimCalcBackend.exe";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            // запускаем процесс
            process.Start();

            // получаем выходные данные
            string output = process.StandardOutput.ReadToEnd();

            // ожидаем завершения процесса
            process.WaitForExit();

            // вывод ответа (временно)
            string result_output = $"{numerator}\n{denominator}";
            richTextBox2.Text = result_output;

            richTextBox1.Text = output;
            */
        }

        private void numerator_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
