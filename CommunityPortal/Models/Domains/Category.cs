using System.Collections.Generic;

namespace CommunityPortal.Models.Domains
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CategoryPost> Posts { get; set; }
    }
}
