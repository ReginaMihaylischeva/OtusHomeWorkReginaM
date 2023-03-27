using HomeWork1.Entity;

namespace HomeWork1
{
    class AddDataService
    {
        public void AddUser(User user)
        {
            IRepository<User> users = new Repository<User>();

            users.Save(user);
        }

        public void AddGood(Goods good)
        {            
            IRepository<Goods> goods = new Repository<Goods>();

            goods.Save(good);
        }

        public void AddBasket(Basket basket)
        {
            IRepository<Basket> baskets = new Repository<Basket>();

            baskets.Save(basket);
        }
    }
}
