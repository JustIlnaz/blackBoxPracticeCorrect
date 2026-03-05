using System;
using System.Globalization;


namespace myBlackBox
{
    internal class Program
    {
        static double CalculateF(double x)
        {
            if (x <= -2)
                throw new ArgumentOutOfRangeException("x", "x вне области допустимых значений");

            if (Math.Abs(x - 1) < 1e-9)
                throw new DivideByZeroException("Деление на ноль");

            double numerator = Math.Log(x + 2);
            double denominator = x - 1;

            return numerator / denominator;
        }

        static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;


            while (true)
            {
                Console.Write("Введите x: ");
                string input = Console.ReadLine();

                if (input.ToLower() == "выход")
                    break;

                input = input.Replace(',', '.');

                if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double x))
                {
                    Console.WriteLine("Ошибка: введено не число\n");
                    continue;
                }

                try
                {
                    double result = CalculateF(x);

                    if (double.IsNaN(result) || double.IsInfinity(result))
                        Console.WriteLine($"f({x}) = не определено\n");
                    else
                        Console.WriteLine($"f({x}) = {result:F6}\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n");
                }
            }
        }
    }
}