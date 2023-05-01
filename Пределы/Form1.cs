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

        // наибольший общий делитель
        static int Gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return Gcd(b, a % b);
            }
        }

        private void equals_button_Click(object sender, EventArgs e)
        {
            // Нажатие по кнопке равно
            // Получаем значения числителя и знаменателя и записываем в удобоваримый для бекенда вид
            string numerator = numeratorInput.Text;
            string denominator = denominatorInput.Text;

            string args = $"\"{numerator}\" \"{denominator}\"";

            // создаем процесс
            Process process = new Process();

            // Свойства процесса
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

            // вывод ответа в answerBox

            string[] lines = output.Split('\n');
            string answerNumerator = lines[lines.Length - 3].TrimEnd();
            string answerDenominator = lines[lines.Length - 2].TrimEnd();

            // Упростить числитель и знаменатель
            int tmp1 = int.Parse(answerNumerator);
            int tmp2 = int.Parse(answerDenominator);

            // наибольший общий делитель
            int gcd = Gcd(tmp1, tmp2);
            tmp1 /= gcd;
            tmp2 /= gcd;

            answerNumerator = tmp1.ToString();
            answerDenominator = tmp2.ToString();

            // создать separator 1
            string separator = "";

            int maxLengthProblem = Math.Max(numerator.Length, denominator.Length);

            for (int i = 0; i < maxLengthProblem; i++)
            {
                separator += "-";
            }
            separator += " = ";

            // создать separator 2
            int maxLengthAnswer = Math.Max(answerNumerator.Length, answerDenominator.Length);

            for (int i = 0; i < maxLengthAnswer; i++)
            {
                separator += "-";
            }

            // выровнять числитель и знаменатель по длине

            if (numerator.Length < maxLengthProblem)
            {
                numerator = numerator.PadRight(maxLengthProblem);
            }
            else if (denominator.Length < maxLengthProblem)
            {
                denominator = denominator.PadRight(maxLengthProblem);
            }

            numerator += "   " + answerNumerator;
            denominator += "   " + answerDenominator;


            string result_output = $"{numerator}\r\n{separator}\r\n{denominator}";
            answerBox.Text = result_output;

            solvingStepsBox.Text = output;
        }
    }
}
