using HomeWork1.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    class AddDataService
    {
        public void AddUser(ISession session)
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
            IRepository<User> users = new Repository<User>(session);

            users.Save(user);
        }

        public void AddGood(ISession session)
        {
            Console.WriteLine("Введите цену:");
            var price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите наименование:");
            var name = Console.ReadLine();
            Console.WriteLine("Введите описание:");
            var description = Console.ReadLine();

            var order = new Goods()
            {
                Price = price,
                Name = name,
                Description = description

            };
            IRepository<Goods> goods = new Repository<Goods>(session);

            goods.Save(order);
        }

        public void AddBasket(ISession session)
        {
            Console.WriteLine("Введите id пользователя:");
            var userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите id товара:");
            var orderId = int.Parse(Console.ReadLine());

            var order = new Basket()
            {
                UserId = userId,
                GoodsId = orderId
            };
            IRepository<Basket> baskets = new Repository<Basket>(session);

            baskets.Save(order);
        }
    }
}
