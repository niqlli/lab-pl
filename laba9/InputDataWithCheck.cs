namespace lab6._2._3
{
    public static class InputDataWithCheck
    {
        public static int InputIntegerWithValidation(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Неверный ввод. Введите целое число от {min} до {max}.");
                Console.WriteLine("Повторите ввод\n");
                Console.ResetColor();
            }
        }
    }
}
