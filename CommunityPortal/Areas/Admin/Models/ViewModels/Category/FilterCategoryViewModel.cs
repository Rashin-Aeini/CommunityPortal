using System.Collections.Generic;

namespace CommunityPortal.Areas.Admin.Models.ViewModels.Category
{
    public class FilterCategoryViewModel
    {
        public FilterCategoryViewModel()
        {
            Result = new List<IndexCategoryViewModel>();
        }

        public string Search { get; set; }

        public int Page { get; set; }
        public int Pages { get; set; }

        public List<IndexCategoryViewModel> Result { get; }
    }
}
