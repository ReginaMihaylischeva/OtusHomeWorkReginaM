using HomeWork1.Entity;
using NHibernate;
using System;

namespace HomeWork1
{
    sealed class Program
    {
        static void Main()
        {
            var session = DbInfoService.GetSession();

            Console.WriteLine("Что будем делать? \n1-читать\n2-писать");
            var action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    ReadInfo(session);
                    break;
                case "2":
                    AddInfo(session);
                    break;
            }

            Console.ReadKey();
        }

        private static void ReadInfo(ISession session)
        {
            var tableNames = DbInfoService.GetTableNames();

            if (tableNames.Equals("-1"))
            {
                Console.WriteLine("Таблица пуста. Необходимо зполнить таблицу.");
                return;
            }

            var tableName = GetOutputInterface(tableNames);

            IRepository<Basket> baskets = new Repository<Basket>(session);
            IRepository<Goods> goods = new Repository<Goods>(session);
            IRepository<User> users = new Repository<User>(session);


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
        private static void AddInfo(ISession session)
        {
            var tableNames = DbInfoService.GetTableNames();
            var tableName = GetInputInterface(tableNames);

            var addData = new AddDataService();

            switch (tableName)
            {
                case "User":
                    addData.AddUser(session);
                    break;
                case "Goods":
                    addData.AddGood(session);
                    break;
                case "Basket":
                    addData.AddBasket(session);
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
    }
}
