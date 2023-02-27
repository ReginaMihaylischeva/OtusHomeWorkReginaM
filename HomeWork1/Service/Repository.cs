using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    public sealed class Repository<IEntity> : IRepository<IEntity>
    {
        private ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public void Save(IEntity item)
        {
            session.Save(item);
        }

        public List<IEntity> ReadAll()
        {
            return new List<IEntity>(session.CreateCriteria(typeof(IEntity)).List<IEntity>());
        }
    }
}
