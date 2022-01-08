using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommunityPortal.Areas.Admin.Models.ViewModels.Post;
using CommunityPortal.Models.Domains;

namespace CommunityPortal.Areas.Admin.Models.Services
{
    public interface IPostService : IService<Post, CreatePostViewModel>
    {
        bool TrackCategory(int post, int category);
        bool SubTrackCategory(int post, int category);
    }
}
