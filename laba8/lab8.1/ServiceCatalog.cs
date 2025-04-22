using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Catalog
{
    internal class ServiceCatalog
    {
        private string name;
        private string category;
        private int price;
        private DateOnly date;
        private bool active;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Название услуги не может быть пустым.", nameof(Name));
                }
                name = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Категория услуги не может быть пустой.", nameof(Category));
                }
                category = value;
            }
        }

        public int Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Price), value, "Цена должна быть неотрицательной.");
                }
                price = value;
            }
        }

        public DateOnly Date
        {
            get { return date; }
            set { date = value; }
        }

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public ServiceCatalog()
        {
            Name = "Неизвестно";
            Category = "Без категории";
            Price = 0;
            Date = DateOnly.FromDateTime(DateTime.Now); 
            Active = true; 
        }

        public ServiceCatalog(string name, string category, int price, DateOnly date, bool active)
        {
            Name = name;
            Category = category;
            Price = price;
            Date = date;
            Active = active;
        }


        public override string ToString()
        {
            return $"{Name,-25} | Category: {Category,-15} | Price: {Price,-5} | Date: {Date} | Active: {Active}";
        }
    }
}