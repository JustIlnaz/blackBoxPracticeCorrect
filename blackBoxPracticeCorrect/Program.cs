using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите x: ");
            double x = Convert.ToDouble(Console.ReadLine());

            if (x == 2)
            {
                throw new DivideByZeroException("Ошибка: деление на ноль");
            }

            double value = (x * x - 9) / (x - 2);

            if (value < 0)
            {
                throw new ArgumentException("Ошибка: подкоренное выражение отрицательное");
            }

            double result = Math.Sqrt(value);

            Console.WriteLine("f(x) = " + result);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите числовое значение.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: результат вычислений слишком велик для представления в типе double.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла неизвестная ошибка: " + ex.Message);
        }
    }
}