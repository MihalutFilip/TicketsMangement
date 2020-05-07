using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<Entity>
    {
        ICollection<Entity> GetAll();
        Entity GetById(object id);
        void Update(Entity entity);
        void Save(Entity entity);
        void Delete(object id);
    }
}
