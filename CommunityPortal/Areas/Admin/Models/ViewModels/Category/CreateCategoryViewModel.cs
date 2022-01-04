using System.ComponentModel.DataAnnotations;

namespace CommunityPortal.Areas.Admin.Models.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
