﻿using System;
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
            process.StartInfo.FileName = "C:\\ConsoleApp1.exe";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            // запускаем процесс
            process.Start();

            // получаем выходные данные
            string output = process.StandardOutput.ReadToEnd();
			richTextBox1.Text = output;

            // ожидаем завершения процесса
            process.WaitForExit();
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
