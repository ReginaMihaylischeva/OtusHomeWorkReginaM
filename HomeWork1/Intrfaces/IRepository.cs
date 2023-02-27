using System.Collections.Generic;

namespace HomeWork1
{
    public interface IRepository<IEntity>
    {
        void Save(IEntity item);

        List<IEntity> ReadAll();

    }
}
