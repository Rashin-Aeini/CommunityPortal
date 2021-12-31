using System.Collections.Generic;

namespace CommunityPortal.Models.Repositories
{
    public interface IRepository<T>
    {
        List<T> Read();
        T Read(int id);
        T Create(T entry);
        bool Update(T entry);
        bool Delete(T entry);
    }
}
