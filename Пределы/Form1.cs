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

		// Работа с бекендом
		static string runBackend(string args)
		{
            // Создаем процесс
            Process process = new Process();

            // Свойства процесса
            process.StartInfo.FileName = "C:\\LimCalcBackend.exe";
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;

            // Запускаем процесс
            process.Start();

            // получаем выходные данные
            string output = process.StandardOutput.ReadToEnd();

            // Ожидаем завершения процесса
            process.WaitForExit();
			
			// Возвращаем то, что выдал бекенд
			return output;
		}
		
		static string fitSeparator(string numerator, string denominator, string separator)
		{
			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину разделителя под количество символов
            int maxLength = Math.Max(numerator.Length, denominator.Length);
            for (int i = 0; i < maxLength; i++)
            {
                separator += "-";
            }
			return separator;
		}

		static void printToAnswerBox(string numerator, string denominator, string answerNumerator, string answerDenominator)
		{
            /// Упростим числитель и знаменатель, разделив оба на наибольший общий делитель (gcd)
            int tmp1 = int.Parse(answerNumerator);
            int tmp2 = int.Parse(answerDenominator);
            int gcd = Gcd(tmp1, tmp2);
            tmp1 /= gcd;
            tmp2 /= gcd;
            answerNumerator = tmp1.ToString();
            answerDenominator = tmp2.ToString();

            /// Создать separator (знак деления)
            string separator = "";

			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину разделителя под количество символов
			separator = fitSeparator(numerator, denominator, separator);
            separator += " = ";

            // Выровняем числитель и знаменатель по длине пробелами
            if (numerator.Length < denominator.Length)
            {
            	numerator = numerator.PadRight(denominator.Length);
            }
            else if (denominator.Length < numerator.Length)
            {
                denominator = denominator.PadRight(denominator.Length);
            }

            // создаем часть уровнения после равно
			separator += fitSeparator(answerNumerator, answerDenominator, separator);
			
			// компенсируем для " = " в separator и добавляем ответ
            numerator += "   " + answerNumerator;
            denominator += "   " + answerDenominator;

			// Выводим ответ
            string result_output = $"{numerator}\r\n{separator}\r\n{denominator}";
            answerBox.Text = result_output;
		}

		static void divideByX(string largestPow)
		{
			if (largestPow == "1")
			{
				string tmpoutput = $"     x\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}
			else
			{
				string tmpoutput = $"     x^{largestPow}\r\n";
				solvingStepsBox.AppendText(tmpoutput);
			}
		}

		static void printToSolvingStepsFirst(string numerator, string denominator, string[] lines)
		{
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
			string separator = fitSeparator(numerator, 0);
			tmpoutput = $"     {separator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);
			
			/// Пункт 3
			divideByX(largestPow);

			/// Пункт 4
			// Создаем дробь посередине
			separator = fitSeparator(numerator, denominator);
			tmpoutput = $"lim -{separator}- =\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 5
			tmpoutput = $"x→∞  {denominator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);
			
			/// Пункт 6
			// Создаем дробь в ширину знаменателя
			separator = fitSeparator(0, denominator);
			tmpoutput = $"     {separator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 7 (то же самое что пункт 3)
			divideByX(largestPow);
			solvingStepsBox.AppendText("\r\n");
		}

		static void printToSolvingStepsSecond(string[] lines)
		{
			/// Выводим в таком порядке:
			/* 5 пробелов + промежуточный числитель
			 * "lim" + пробел + дробь в ширину самого широкого числителя/знаменателя + 2x"-" + " ="
			 * "x→∞" + 2 пробела + промежуточный знаменатель */

            string numerator = lines[2].TrimEnd();
            string denominator = lines[3].TrimEnd();
			
			/// Пункт 1
			string tmpoutput = $"     {numerator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 2
			// Ищем что длиннее, числитель или знаменатель, и подгоняем длину полосы под количество символов
			string separator = fitSeparator(numerator, denominator);
			tmpoutput = $"lim -{separator}- =\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			/// Пункт 3
			tmpoutput = $"x→∞  {denominator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			solvingStepsBox.AppendText("\r\n");
		}

		static void printToSolvingStepsThird(string numerator, string denominator)
		{
			string tmpoutput = $"{numerator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			// Дробь в ширину самого длинного элемента
			string separator = fitSeparator(numerator, denominator);
			tmpoutput = $"{separator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);

			tmpoutput = $"{denominator}\r\n";
			solvingStepsBox.AppendText(tmpoutput);
		}

        private void equals_button_Click(object sender, EventArgs e)
        {
            //// Нажатие по кнопке равно
            // Получаем значения числителя и знаменателя и записываем в удобоваримый для бекенда вид
            string numerator = numeratorInput.Text;
            string denominator = denominatorInput.Text;
            string args = $"\"{numerator}\" \"{denominator}\"";
			
			// Запускаем бекенд, получаем вывод в output
			string output = runBackend(args);

			// Разделяем вывод бекенда на строки 
            string[] lines = output.Split('\n');

			//// Выводим ответ в AnswerBox
			// Работаем с двумя последними строками вывода
			// answerX - то что вывел бекенд, когда просто numerator и denominator - то что ввёл юзер
            string answerNumerator = lines[lines.Length - 3].TrimEnd();
            string answerDenominator = lines[lines.Length - 2].TrimEnd();
			printToAnswerBox(numerator, denominator, lines);

			//// Выводим шаги решения в solvingStepsBox
			// Выводим первый шаг, деление числителя и знаменателя на наибольшую степень
			printToSolvingStepsFirst(numerator, denominator, lines);

			// Выводим второй шаг, промежуточный результат после деления, что стало 0
			printToSolvingStepsSecond(lines);

			// Выводим третий шаг, просто ответ
			printToSolvingStepsThird(answerNumerator, answerDenominator);
        }
    }
}
