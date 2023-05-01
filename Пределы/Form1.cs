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
            //// Нажатие по кнопке равно
            // Получаем значения числителя и знаменателя и записываем в удобоваримый для бекенда вид
            string numerator = numeratorInput.Text;
            string denominator = denominatorInput.Text;
            string args = $"\"{numerator}\" \"{denominator}\"";
			
			///////////////////////////////////////
			////////// Работа с бекендом //////////
			////////////////////////////////////////
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
			////////////////////////////////////////

			///////////////////////////////////////
            ////// вывод ответа в answerBox ///////
			///////////////////////////////////////
			// Работаем с двумя последними строками вывода
            string[] lines = output.Split('\n');
            string answerNumerator = lines[lines.Length - 3].TrimEnd();
            string answerDenominator = lines[lines.Length - 2].TrimEnd();

            /// Упростим числитель и знаменатель
            int tmp1 = int.Parse(answerNumerator);
            int tmp2 = int.Parse(answerDenominator);
            // наибольший общий делитель
            int gcd = Gcd(tmp1, tmp2);
            tmp1 /= gcd;
            tmp2 /= gcd;
            answerNumerator = tmp1.ToString();
            answerDenominator = tmp2.ToString();


            /// создать separator (знак деления)
            string separator = "";

			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину полосы под количество символов
            int maxLengthProblem = Math.Max(numerator.Length, denominator.Length);
            for (int i = 0; i < maxLengthProblem; i++)
            {
                separator += "-";
            }
            separator += " = ";

            // создаем часть уровнения после равно
            int maxLengthAnswer = Math.Max(answerNumerator.Length, answerDenominator.Length);
            for (int i = 0; i < maxLengthAnswer; i++)
            {
                separator += "-";
            }

            // выровняем числитель и знаменатель по длине пробелами
			string tmpNumerator = numerator;
			string tmpDenominator = denominator;
            if (numerator.Length < maxLengthProblem)
            {
            	tmpNumerator = tmpNumerator.PadRight(maxLengthProblem);
            }
            else if (denominator.Length < maxLengthProblem)
            {
                tmpDenominator = tmpDenominator.PadRight(maxLengthProblem);
            }
			
			// компенсируем для " = " в separator
            tmpNumerator += "   " + answerNumerator;
            tmpDenominator += "   " + answerDenominator;

			// Выводим ответ
            string result_output = $"{tmpNumerator}\r\n{separator}\r\n{tmpDenominator}";
            answerBox.Text = result_output;
			///////////////////////////////////////
			
			///////////////////////////////////////
			///////// Вывод шагов решения /////////
			///////////////////////////////////////
			//// Выводим первый шаг, деление числителя и знаменателя на наибольшую степень
			// Взять наибольшую степень из output
            string largestPow = lines[0].TrimEnd();

			//// Выводим в таком порядке:
			/* 5 пробелов + Числитель
			 * 5 пробелов + Дробь в ширину числителя
			 * 5 пробелов + x^$largestPow
			 * "lim" + пробел + дробь в ширину самого широкого числителя/знаменателя + 2x"-" + " ="
			 * "x→∞" + 2 пробела + знаменатель
			 * 5 пробелов + дробь в ширину знаменателя
			 * 5 пробелов + x^$largestPow */

			/// Пункт 1
			string tmpoutput = $"     {numerator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 2
			// Создаем дробь в ширину числителя
			separator = "";
            for (int i = 0; i < numerator.Length; i++)
            {
                separator += "-";
            }
			tmpoutput = $"     {separator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);
			
			/// Пункт 3
			if (largestPow == "1")
			{
				tmpoutput = $"     x\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}
			else
			{
				tmpoutput = $"     x^{largestPow}\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}

			/// Пункт 4
			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину полосы под количество символов
			string wideSeparator = "";
            for (int i = 0; i < maxLengthProblem; i++)
            {
                wideSeparator += "-";
            }
			tmpoutput = $"lim -{wideSeparator}- =\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 5
			tmpoutput = $"x→∞  {denominator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);
			
			/// Пункт 6
			// Создаем дробь в ширину знаменателя
			separator = "";
            for (int i = 0; i < denominator.Length; i++)
            {
                separator += "-";
            }
			tmpoutput = $"     {separator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 7 (то же самое что пункт 3)
			if (largestPow == "1")
			{
				tmpoutput = $"     x\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}
			else
			{
				tmpoutput = $"     x^{largestPow}\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}
			solvingStepsBox.AppendText("\r\n");

			//// Выводим второй шаг, промежуточный результат после деления, что стало 0
			/// Выводим в таком порядке:
			/* 5 пробелов + промежуточный числитель
			 * "lim" + пробел + дробь в ширину самого широкого числителя/знаменателя + 2x"-" + " ="
			 * "x→∞" + 2 пробела + промежуточный знаменатель */

            string intermNumerator = lines[2].TrimEnd();
            string intermDenominator = lines[3].TrimEnd();
			
			/// Пункт 1
			tmpoutput = $"     {intermNumerator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 2
			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину полосы под количество символов
			wideSeparator = "";
            int maxLengthInterm = Math.Max(intermNumerator.Length, intermDenominator.Length);
            for (int i = 0; i < maxLengthInterm; i++)
            {
                wideSeparator += "-";
            }
			tmpoutput = $"lim -{wideSeparator}- =\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 3
			tmpoutput = $"x→∞  {intermDenominator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			solvingStepsBox.AppendText("\r\n");
        }
    }
}
