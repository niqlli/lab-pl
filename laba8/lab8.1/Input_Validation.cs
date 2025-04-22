using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace Input_Validation
{
    internal class InputValidation
    {
        public static int InputIntegerWithValidation(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пустой ввод. Повторите ввод.");
                    Console.ResetColor();
                    continue;
                }
                if (input == "0")
                {
                    return 0;
                }
                if (int.TryParse(input, out int inputNumber) && !input.StartsWith('0') && !(input.StartsWith("-0")))
                {
                    return inputNumber;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа. Повторите ввод.");
                Console.ResetColor();
            }
        }


        public static int InputNaturalWithValidation(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Пустой ввод. Повторите ввод.");
                    Console.ResetColor();
                    continue;
                }
                if (int.TryParse(input, out int inputNumber) && inputNumber > 0 && !input.StartsWith('0'))
                {
                    return inputNumber;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат натурального числа. Повторите ввод.");
                Console.ResetColor();
            }
        }
    }
}
