using Service_Catalog;
using Input_Validation;

namespace Service_Manager
{
    internal class ServiceManager
    {
        private static string filePath = "services.bin";
        private static List<ServiceCatalog> services = new List<ServiceCatalog>();
        private static Random rand = new Random();
        

        public static void GenerateRandomData(int count = 10)
        {
           
            string[] names = { "Веб-дизайн", "SEO-оптимизация", "Разработка приложения", "Аналитика данных", "Создание эл.магазина", "Графический дизайн", "Видео-продакшн", "Поддержка сайта", "Создание логотипа", "Ведение соц.сетей" };
            string[] categories = { "Маркетинг", "Разработка", "Дизайн", "Аналитика", "Коммерция" };

            services = Enumerable.Range(1, count).Select(i => new ServiceCatalog(
                names[rand.Next(names.Length)],
                categories[rand.Next(categories.Length)],
                rand.Next(100, 5000), 
                DateOnly.FromDateTime(DateTime.Now.AddDays(-rand.Next(365))), 
                rand.Next(0, 2) == 1 
            )).ToList();

            SaveToBin();
            Console.WriteLine("Случайные данные сгенерированы и сохранены.");
        }

        public static void SaveToBin()
        {
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    writer.Write(services.Count); 

                    foreach (ServiceCatalog service in services)
                    {
                        writer.Write(service.Name);
                        writer.Write(service.Category);
                        writer.Write(service.Price);
                        writer.Write(service.Date.ToDateTime(TimeOnly.MinValue).ToBinary()); 
                        writer.Write(service.Active);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения: {ex.Message}");
            }
        }

        public static void LoadFromBin()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Файл не найден. Генерация новых данных...");
                GenerateRandomData();
                return;
            }
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    int count = reader.ReadInt32(); 
                    services = new List<ServiceCatalog>();

                    for (int i = 0; i < count; i++)
                    {
                        string name = reader.ReadString();
                        string category = reader.ReadString();
                        int price = reader.ReadInt32();
                        DateOnly date = DateOnly.FromDateTime(DateTime.FromBinary(reader.ReadInt64())); 
                        bool active = reader.ReadBoolean();

                        services.Add(new ServiceCatalog(name, category, price, date, active));
                    }
                }

                Console.WriteLine("База данных загружена из BIN-файла.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
            }
        }

        public static void ViewAll()
        {
            if (services.Count == 0)
            {
                Console.WriteLine("Каталог услуг пуст.");
                return;
            }
            foreach (var service in services)
            {
                Console.WriteLine(service);
            }
        }

        public static void DeleteByName()
        {
            Console.Write("Введите название услуги для удаления: ");
            string? name = Console.ReadLine();
            List<ServiceCatalog> toRemove = (from catalogService in services
                                                            where catalogService.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                            select catalogService).ToList<ServiceCatalog>();
            foreach (ServiceCatalog recordToRemove in toRemove)
            {
                services.Remove(recordToRemove);
            }
            SaveToBin();
            if (toRemove.Count > 0)
            {
                Console.WriteLine($"{toRemove.Count} запись(ей) удалено.");
            }
            else
            {
                Console.WriteLine("Совпадений не найдено.");
            }
        }

        public static void AddServices()
        {

         string? name;
         string category;
         int price;
         DateOnly date;
         bool active;
            Console.Write("Название услуги: ");
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                    break;
                Console.Write("Название услуги не может быть пустым или состоять из пробелов. Попробуйте снова: ");
            }

            price = InputValidation.InputNaturalWithValidation("Стоимость (от 100 до 5000): ");
            while (price < 100 || price > 5000)
            {
                Console.Write("Стоимость должна быть в диапазоне от 100 до 5000. Попробуйте снова: ");
                price = InputValidation.InputNaturalWithValidation("Стоимость (от 100 до 5000): ");
            }

            string[] categories = { "Маркетинг", "Разработка", "Дизайн", "Аналитика", "Коммерция" };
            Console.WriteLine($"Доступные категории: {string.Join(", ", categories)}");
            while (true)
            {
                Console.Write("Введите категорию: ");
                category = Console.ReadLine();

                if (categories.Contains(category))
                {
                    break; 
                }
                else
                {
                    Console.WriteLine("Категория не найдена в списке доступных. Попробуйте снова.");
                }
            }

            while (true)
            {
                Console.Write("Введите дату (YYYY-MM-DD): ");
                if (DateOnly.TryParse(Console.ReadLine(), out date))
                    break;
                Console.Write("Некорректный формат даты. Попробуйте снова: ");
            }


            Console.Write("Активна ли услуга (true/false): ");
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "true" || input == "false")
                {
                    active = input == "true";
                    break;
                }
                Console.Write("Введите true или false. Попробуйте снова: ");
            }
            ServiceCatalog newRecord = new ServiceCatalog(name, category, price, date, active);
            services.Add(newRecord);

            SaveToBin(); 
            Console.WriteLine("Запись добавлена.");
        }

        public static void Query1()
        {
            
            List<ServiceCatalog> result = (from service in services
                                                           where service.Date > new DateOnly(2025, 1, 1)
                                                           select service).ToList();
            Console.WriteLine("Услуги, которые добавлены после 01.01.2025:");
            if (result.Any())
            {
                result.ForEach(service => Console.WriteLine(service));
            }
            else
            {
                Console.WriteLine("Нет услуг, соответствующих критериям.");
            }
        }

        public static void Query2()
        {
            
            var groupedServices = services
                .GroupBy(service => service.Category)
                .Where(group => group.Count() >= 2);

            Console.WriteLine("\nКатегории с двумя и более услугами:");

            if (groupedServices.Any())
            {
                foreach (var group in groupedServices)
                {
                    Console.WriteLine($"\nКатегория: '{group.Key}' ({group.Count()} услуг)");
                    foreach (var service in group)
                    {
                        Console.WriteLine(service);
                    }
                }
            }
            else
            {
                Console.WriteLine("Нет категорий с двумя и более услугами.");
            }
        }

        public static void Query3()
        {
            double averagePrice = services.Average(service => service.Price);
            Console.WriteLine($"Средняя стоимость услуги: {averagePrice:F2}");
        }

        public static void Query4()
        {
            int debtorsCount = (from servicesActive in services
                                where servicesActive.Active == false
                                select servicesActive).Count();
            Console.WriteLine($"Количество неактивных услуг: {debtorsCount}");
        }
    }
}