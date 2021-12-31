using System.Collections.Generic;

namespace CommunityPortal.Areas.Admin.Models.Services
{
    public interface IService<TDomain, TCreate>
    {
        List<TDomain> GetAll();
        TDomain GetById(int id);
        TDomain Add(TCreate entry);
        bool Edit(int id, TCreate entry);
        bool Remove(int id);

    }
}
