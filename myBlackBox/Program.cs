using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите значение x: ");
            string input = Console.ReadLine();

            double x;

            if (!double.TryParse(input, out x))
            {
                Console.WriteLine("Ошибка: введено не число.");
                return;
            }

            if (x < -2)
            {
                Console.WriteLine("Ошибка: x вне области определения (x < -2).");
                return;
            }

            if (x == -2)
            {
                Console.WriteLine("Ошибка: ln(0) не определён.");
                return;
            }

            if (x == 1)
            {
                Console.WriteLine("Ошибка: деление на ноль (x = 1).");
                return;
            }

            if (x > -2 && x < 1 || x > 1)
            {
                double y = Math.Log(x + 2) / (x - 1);
                Console.WriteLine($"Результат: y = {y:F6}");
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: введённое число слишком большое или слишком маленькое.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Неизвестная ошибка: " + ex.Message);
        }

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}