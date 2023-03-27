using HomeWork1.Entity;
using NHibernate;
using System;

namespace HomeWork1
{
    sealed class Program
    {
        static void Main()
        {           
            Console.WriteLine("Что будем делать? \n1-читать\n2-писать");
            var action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    ReadInfo();
                    break;
                case "2":
                    AddInfo();
                    break;
            }

            Console.ReadKey();
        }

        private static void ReadInfo()
        {
            var tableNames = DbInfoService.GetTableNames();

            if (tableNames.Equals("-1"))
            {
                Console.WriteLine("Таблица пуста. Необходимо зполнить таблицу.");
                return;
            }

            var tableName = GetOutputInterface(tableNames);

            IRepository<Basket> baskets = new Repository<Basket>();
            IRepository<Goods> goods = new Repository<Goods>();
            IRepository<User> users = new Repository<User>();


            switch (tableName)
            {
                case "User":
                    users.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Имя: {p.FirstName} Фамилия: {p.LastName}"));
                    break;
                case "Goods":
                    goods.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Описание: {p.Description} Наименование: {p.Name} Цена: {p.Price}"));
                    break;
                case "Basket":
                    baskets.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Id пользователя: {p.UserId} Id товара: {p.GoodsId}"));
                    break;
                case "All":
                    users.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Имя: {p.FirstName} Фамилия: {p.LastName}"));
                    Console.WriteLine("\n");
                    goods.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Наименование: {p.Name} Цена: {p.Price} Цена: {p.Price} Описание: {p.Description}"));
                    Console.WriteLine("\n");
                    baskets.ReadAll().ForEach(p => Console.WriteLine($"Id: {p.ID} Id пользователя: {p.UserId} Id товара: {p.GoodsId}"));
                    Console.WriteLine("\n");
                    break;
                default:
                    Console.WriteLine("Передано некорректное наименование.");
                    break;
            }
        }
        private static void AddInfo()
        {
            var tableNames = DbInfoService.GetTableNames();
            var tableName = GetInputInterface(tableNames);

            var addData = new AddDataService();

            switch (tableName)
            {
                case "User":
                    var user = GetUserInfo();
                    addData.AddUser(user);
                    break;
                case "Goods":
                    var good = GetGoodInfo();
                    addData.AddGood(good);
                    break;
                case "Basket":
                    var basket = GetBasketInfo();
                    addData.AddBasket(basket);
                    break;
                default:
                    Console.WriteLine("Передано некорректное наименование.");
                    break;
            }
        }

        private static string GetInputInterface(string tableNames)
        {
            Console.WriteLine($"В базе присутствуют следующие таблицы: {tableNames}\n" +
                "Введите название таблицы для ввода данных:");
            var tableName = Console.ReadLine();
            return tableName;
        }

        private static string GetOutputInterface(string tableNames)
        {
            Console.WriteLine($"В базе присутствуют следующие таблицы: {tableNames}\n" +
                "Введите название таблицы для вывода содержимого, для вывода всех таблиц введите 'All':");
            var tableName = Console.ReadLine();
            return tableName;
        }

        private static User GetUserInfo()
        {
           Console.WriteLine("Введите имя:");
           var userName = Console.ReadLine();
           Console.WriteLine("Введите фамилию:");
           var userLastName = Console.ReadLine();

           var user = new User()
           {
                    FirstName = userName,
                    LastName = userLastName
           };

           return user;
        }

        private static Goods GetGoodInfo()
        {
            Console.WriteLine("Введите цену:");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите наименование:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание:");
            var description = Console.ReadLine();

            var good = new Goods()
            {
                Price = price,
                Name = name,
                Description = description

            };

            return good;
        }

        private static Basket GetBasketInfo()
        {
            Console.WriteLine("Введите id пользователя:");
            var userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите id товара:");
            var orderId = int.Parse(Console.ReadLine());

            var basket = new Basket()
            {
                UserId = userId,
                GoodsId = orderId
            };

            return basket;
        }
    }
}
