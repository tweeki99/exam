using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Models;
using Warehouse.Services;
using Warehouse.Services.Abstract;

namespace Warehouse.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Product> repository = new JsonRepository<Product>();

            var reporter = new ConsoleReporter();

            (repository as JsonRepository<Product>).ReportEvent += reporter.SendMessage;

            var product = new Product
            {
                Id = 1,
                Title = "Хлеб"
            };

            repository.Add(product);

            //var product = CreateProduct();

            //System.Console.ReadLine();
        }

        static public Product CreateProduct()
        {
            Product product = new Product();

            System.Console.WriteLine("Введите название");
            product.Title = System.Console.ReadLine();

            System.Console.WriteLine("Введите цену");
            while (true)
            {
                double price;
                if (Double.TryParse(System.Console.ReadLine(), out price))
                {
                    product.Price = price;
                    break;
                }
                System.Console.WriteLine("Введите цену правильно");
            }

            System.Console.WriteLine("Введите количество");
            while (true)
            {
                int quantity;
                if (Int32.TryParse(System.Console.ReadLine(), out quantity))
                {
                    product.Quantity = quantity;
                    break;
                }
                System.Console.WriteLine("Введите количество правильно");
            }


            System.Console.WriteLine("Производитель");
            product.Manufacturer = System.Console.ReadLine();

            System.Console.WriteLine("Страна производителя");
            product.ManufactureCountry = System.Console.ReadLine();

            System.Console.WriteLine("Дата производства");
            int year, month, day;
            System.Console.WriteLine("Введите год");
            while (true)
            {
                if (Int32.TryParse(System.Console.ReadLine(), out year))
                {
                    try
                    {
                        DateTime test = new DateTime(year, 1, 1);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        System.Console.WriteLine("Введите год правильно");
                        continue;
                    }
                }
                System.Console.WriteLine("Введите год правильно");
            }

            System.Console.WriteLine("Введите месяц");
            while (true)
            {

                if (Int32.TryParse(System.Console.ReadLine(), out month))
                {
                    try
                    {
                        DateTime test = new DateTime(1999, month, 1);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        System.Console.WriteLine("Введите месяц правильно");
                        continue;
                    }
                }
                System.Console.WriteLine("Введите месяц правильно");
            }

            System.Console.WriteLine("Введите день");
            while (true)
            {
                if (Int32.TryParse(System.Console.ReadLine(), out day))
                {
                    try
                    {
                        DateTime test = new DateTime(1999, 1, day);
                        break;
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        System.Console.WriteLine("Введите день правильно");
                        continue;
                    }
                }
                System.Console.WriteLine("Введите день правильно");
            }
            product.DateOfManufacture = new DateTime(year, month, day);

            return product;
        }
    }


}
