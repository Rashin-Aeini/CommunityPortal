using System.Collections.Generic;
using System.Linq;
using CommunityPortal.Models.Data;
using CommunityPortal.Models.Domains;

namespace CommunityPortal.Models.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private PortalContext Context { get; }

        public CategoryRepository(PortalContext context)
        {
            Context = context;
        }

        public List<Category> Read()
        {
            return Context.Categories.ToList();
        }

        public Category Read(int id)
        {
            return Read().SingleOrDefault(item => item.Id == id);
        }

        public Category Create(Category entry)
        {
            Context.Categories.Add(entry);

            Context.SaveChanges();

            return entry;
        }

        public bool Update(Category entry)
        {
            Context.Categories.Update(entry);

            return Context.SaveChanges() > 0;
        }

        public bool Delete(Category entry)
        {
            Context.Categories.Remove(entry);

            return Context.SaveChanges() > 0;
        }
    }
}
