using System.Collections.Generic;
using System.Linq;
using CommunityPortal.Areas.Admin.Models.ViewModels.Category;
using CommunityPortal.Models.Domains;
using CommunityPortal.Models.Repositories;

namespace CommunityPortal.Areas.Admin.Models.Services
{
    public class CategoryService : IService<Category, CreateCategoryViewModel>
    {
        private IRepository<Category> Repository { get; }

        public CategoryService(IRepository<Category> repository)
        {
            Repository = repository;
        }

        public List<Category> GetAll()
        {
            return Repository.Read();
        }

        public Category GetById(int id)
        {
            return Repository.Read(id);
        }

        public Category Add(CreateCategoryViewModel entry)
        {
            Category item = new Category()
            {
                Title = entry.Title
            };

            return Repository.Create(item);
        }

        public bool Edit(int id, CreateCategoryViewModel entry)
        {
            Category item = new Category()
            {
                Id = id,
                Title = entry.Title
            };

            return Repository.Update(item);
        }

        public bool Remove(int id)
        {
            Category entry = GetById(id);

            if (entry != null && entry.Posts.Any())
            {
                entry.Posts.Clear();
                Repository.Update(entry);
            }

            return entry != null && Repository.Delete(entry);
        }
    }
}
