using FluentNHibernate.Mapping;
using HomeWork1.Entity;

namespace HomeWork1.Mapping
{
    sealed class BasketMap : ClassMap<Basket>
    {
        public BasketMap()
        {
            Map(x => x.GoodsId);
            Map(x => x.UserId);
            Id(x => x.ID);
        }
    }
}
