using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Service_Manager;
using Service_Catalog;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n--- Каталог услуг ---");
            Console.WriteLine("1. Чтение базы данных из бинарного файла");
            Console.WriteLine("2. Просмотр базы данных");
            Console.WriteLine("3. Удалить услугу по названию");
            Console.WriteLine("4. Добавить новую услугу");
            Console.WriteLine("5. Запрос 1: Услуги, которые добавлены после 01.01.2025: ");
            Console.WriteLine("6. Запрос 2: Услуги одной категории ");
            Console.WriteLine("7. Запрос 3: Средняя стоимость услуги");
            Console.WriteLine("8. Запрос 4: Количество неактивных услуг");
            Console.WriteLine("9. Сгенерировать случайные данные");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            string? input = Console.ReadLine();
            switch (input)
            {
                case null:
                    Console.WriteLine("Ввод не может быть пустым!");
                    break;
                case "1":
                    ServiceManager.LoadFromBin();
                    break;
                case "2":
                    ServiceManager.ViewAll();
                    break;
                case "3":
                    ServiceManager.DeleteByName();
                    break;
                case "4":
                    ServiceManager.AddServices();
                    break;
                case "5":
                    ServiceManager.Query1();
                    break;
                case "6":
                    ServiceManager.Query2();
                    break;
                case "7":
                    ServiceManager.Query3();
                    break;
                case "8":
                    ServiceManager.Query4();
                    break;
                case "9":
                    ServiceManager.GenerateRandomData();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный ввод");
                    break;
            }
        }
    }
}