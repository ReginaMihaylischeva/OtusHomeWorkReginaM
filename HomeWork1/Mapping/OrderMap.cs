using FluentNHibernate.Mapping;
using HomeWork1.Entity;

namespace HomeWork1.Mapping
{
    sealed class OrderMap : ClassMap<Goods>
    {
        public OrderMap()
        {
            Map(x => x.Price);
            Map(x => x.Description);
            Map(x => x.Name);
            Id(x => x.ID);
        }
    }
}
