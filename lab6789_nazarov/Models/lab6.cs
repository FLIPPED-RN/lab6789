using System.Windows;
using System.Windows.Controls;

namespace lab6789_nazarov.Models;

public class lab6
{
    //
    //ВЫСОКИЙ УРОВЕНЬ 4 ЗАДАНИЕ<--------
    //Назаров Руслан 23-ИСП-2/1
    public static void ProcessInput(string input, TextBlock output)
    {
        string[] inputValues = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double[] numbers = new double[inputValues.Length];
        int positiveCount = 0;

        for (int i = 0; i < inputValues.Length; i++)
        {
            if (double.TryParse(inputValues[i], out double value))
            {
                numbers[i] = value;
            }
            else
            {
                MessageBox.Show($"Ошибка преобразования строки \"{inputValues[i]}\" в число.");
                return;
            }
        }

        List<double> filteredNumbers = new List<double>();
        foreach (double num in numbers)
        {
            if (Math.Abs(num) <= 10 && num != 0)
            {
                filteredNumbers.Add(num);
                if (num % 2 == 0)
                    positiveCount++;
            }
        }

        output.Text = $"Количество: {positiveCount}";
    }

    public static void ProcessInput(string input, ListBox output)
    {
        string[] inputValues = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        double[] numbers = new double[inputValues.Length];

        

        for (int i = 0; i < inputValues.Length; i++)
        {
            if (double.TryParse(inputValues[i], out double value))
            {
                numbers[i] = value;
            }
            else
            {
                MessageBox.Show($"Ошибка: {inputValues[i]} - не число! Начните вводить цисла через пробел или запятую");
                return;
            }
           
        }

        List<double> filteredNumbers = new List<double>();
        foreach (double num in numbers)
        {
            if (Math.Abs(num) <= 10)
            {
                filteredNumbers.Add(num);
            }
        }

        output.Items.Clear();
        foreach (double num in filteredNumbers)
        {
            output.Items.Add(num);
        }
    }
}