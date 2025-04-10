using lab6._2._3;
public class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Введите первое время:");
        Time time1 = new Time(InputDataWithCheck.InputIntegerWithValidation("Часы (0-23): ", int.MinValue, int.MaxValue),
                             InputDataWithCheck.InputIntegerWithValidation("Минуты (0-59): ", int.MinValue, int.MaxValue),
                             InputDataWithCheck.InputIntegerWithValidation("Секунды (0-59): ", int.MinValue, int.MaxValue));

        Console.WriteLine("Введите второе время:");
        Time time2 = new Time(InputDataWithCheck.InputIntegerWithValidation("Часы (0-23): ", int.MinValue, int.MaxValue),
                             InputDataWithCheck.InputIntegerWithValidation("Минуты (0-59): ", int.MinValue, int.MaxValue),
                             InputDataWithCheck.InputIntegerWithValidation("Секунды (0-59): ", int.MinValue, int.MaxValue));


        Console.WriteLine($"time1: {time1}");
        Console.WriteLine($"time2: {time2}");

        Time time3 = time1 - time2;

        Console.WriteLine($"Разница (time1 - time2): {time3}");


        Time time4 = new Time(time1);
        Console.WriteLine($"time4 (копия time1): {time4}");

        Time time5 = time1++;
        Console.WriteLine($"time5 (time1++): {time5}");
        Console.WriteLine($"time1 (после time1++): {time1}"); 


        Time time6 = --time2;
        Console.WriteLine($"time6 (--time2): {time6}");
        Console.WriteLine($"time2 (после --time2): {time2}");


        int minutes = time1; 
        Console.WriteLine($"time1 в минутах: {minutes}");


        bool isNonZero = (bool)time2; 
        Console.WriteLine($"time2 не нулевое: {isNonZero}");

        Console.WriteLine($"time1 < time2: {time1 < time2}");
        Console.WriteLine($"time1 > time2: {time1 > time2}");

        Console.ReadKey();
    }

}