using System;

namespace CommunityPortal.Areas.Admin.Models.ViewModels.Post
{
    public class CreatePostViewModel
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Content { get; set; }
        public TimeSpan Created { get; set; }
    }
}
