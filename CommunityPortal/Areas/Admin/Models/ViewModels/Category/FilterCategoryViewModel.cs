using System.Collections.Generic;

namespace CommunityPortal.Areas.Admin.Models.ViewModels.Category
{
    public class FilterCategoryViewModel
    {
        public FilterCategoryViewModel()
        {
            Result = new List<IndexCategoryViewModel>();
            Search = ""; //string.Empty;
        }

        #region Question
        
        public string Search { get; set; }

        public int Page { get; set; }
        public int Pages { get; set; }

        #endregion

        #region Answer
        
        public List<IndexCategoryViewModel> Result { get; }

        #endregion
    }
}
