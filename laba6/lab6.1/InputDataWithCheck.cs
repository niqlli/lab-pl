namespace lab6._1
{
     class InputDataWithCheck
    {
        static public int InputIntegerWithValidation(string prompt, int left, int right)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result) && result >= left && result <= right)
                {
                    return result;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nВведенные данные имеют неверный формат или не принадлежат диапазону [{left}; {right}]");
                Console.WriteLine("Повторите ввод\n");
                Console.ResetColor();
            }
        }
    }
}
