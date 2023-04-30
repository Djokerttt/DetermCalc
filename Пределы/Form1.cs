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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			SetApplicationFont(this.Controls, new Font("Cascadia Mono", 12, FontStyle.Regular));

			// зафиксировать размер
			this.MinimumSize = new Size(400, 600);
			this.MaximumSize = new Size(400, 600);
        }
		
		// Поменять стандартный шрифт
		private void SetApplicationFont(Control.ControlCollection controls, Font font)
		{
			foreach (Control control in controls)
			{
				control.Font = font;
				if (control.Controls.Count > 0)
				{
					SetApplicationFont(control.Controls, font);
				}
			}
		}       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Равно
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

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
			//Ответ
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Вывод решения
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
            //Числитель
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            //Знаменатель
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
