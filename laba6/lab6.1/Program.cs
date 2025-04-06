using lab6._1;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Базовый класс:");

        var figure1 = new Figure(InputDataWithCheck.InputIntegerWithValidation("Введите длину: ", int.MinValue, int.MaxValue),
                              InputDataWithCheck.InputIntegerWithValidation("Введите ширину: ", int.MinValue, int.MaxValue),
                              InputDataWithCheck.InputIntegerWithValidation("Введите высоту: ", int.MinValue, int.MaxValue));

        Console.WriteLine(figure1);
        Console.WriteLine($"Объем: {figure1.CalculateVolume()}");

        var figure2 = new Figure(figure1);
        Console.WriteLine("Проверка конструктора копирования:");
        Console.WriteLine(figure2);
       // Console.WriteLine($"Объем: {figure2.CalculateVolume()}");

        Console.WriteLine("\nДочерний класс:");

       // var child1 = new SurfaceAreaAndDiagonal(figure1.Length, figure1.Width, figure1.Height);
        var figure3 = new SurfaceAreaAndDiagonal(InputDataWithCheck.InputIntegerWithValidation("Введите длину: ", int.MinValue, int.MaxValue),
                       InputDataWithCheck.InputIntegerWithValidation("Введите ширину: ", int.MinValue, int.MaxValue),
                       InputDataWithCheck.InputIntegerWithValidation("Введите высоту: ", int.MinValue, int.MaxValue));

        Console.WriteLine(figure3);
        Console.WriteLine($"Длина диагонали: {figure3.CalculateDiagonal()}");
        Console.WriteLine($"Площадь поверхности: {figure3.CalculateSurfaceArea()}");

        var figure4 = new SurfaceAreaAndDiagonal(figure3);
        Console.WriteLine("Проверка конструктора копирования:");
        Console.WriteLine(figure4);
       // Console.WriteLine($"Длина диагонали: {figure4.CalculateDiagonal()}");
       // Console.WriteLine($"Площадь поверхности: {figure4.CalculateSurfaceArea()}");

        Console.ReadKey();
    }
}