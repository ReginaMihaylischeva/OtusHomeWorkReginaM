using FluentNHibernate.Mapping;
using System.Linq;

namespace HomeWork1
{
    sealed class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(x => x.LastName);
            Map(x => x.FirstName);
            Id(x => x.ID);
        }
    }
}
