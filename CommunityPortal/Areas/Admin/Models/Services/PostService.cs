using System;
using System.Collections.Generic;
using CommunityPortal.Areas.Admin.Models.ViewModels.Post;
using CommunityPortal.Models.Domains;
using CommunityPortal.Models.Repositories;

namespace CommunityPortal.Areas.Admin.Models.Services
{
    public class PostService : IPostService
    {
        private IRepository<Post> Repository { get; }

        public PostService(IRepository<Post> repository)
        {
            Repository = repository;
        }

        public List<Post> GetAll()
        {
            return Repository.Read();
        }

        public Post GetById(int id)
        {
            return Repository.Read(id);
        }

        public Post Add(CreatePostViewModel entry)
        {
            Post item = new Post()
            {
                Title = entry.Title,
                Thumbnail = entry.Thumbnail,
                Content = entry.Content,
                Created = TimeSpan.FromSeconds(0)
            };

            return Repository.Create(item);
        }

        public bool Edit(int id, CreatePostViewModel entry)
        {
            Post item = new Post()
            {
                Id = id,
                Title = entry.Title,
                Thumbnail = entry.Thumbnail,
                Content = entry.Content,
                Created = entry.Created
            };

            return Repository.Update(item);
        }

        public bool Remove(int id)
        {
            Post item = GetById(id);
            return item != null && Repository.Delete(item);
        }

        public bool TrackCategory(int post, int category)
        {
            throw new NotImplementedException();
        }

        public bool SubTrackCategory(int post, int category)
        {
            throw new NotImplementedException();
        }
    }
}
