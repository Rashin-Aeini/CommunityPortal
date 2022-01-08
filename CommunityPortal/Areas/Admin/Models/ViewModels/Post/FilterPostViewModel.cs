﻿using System.Collections.Generic;

namespace CommunityPortal.Areas.Admin.Models.ViewModels.Post
{
    public class FilterPostViewModel
    {
        public FilterPostViewModel()
        {
            Result = new List<IndexPostViewModel>();

        }

        #region Question
        
        public string Search { get; set; }

        public string Sort { get; set; }
        public string Type { get; set; }

        public int Pages { get; set; }
        public int Page { get; set; }

        #endregion

        #region Answer
        
        public List<IndexPostViewModel> Result { get; }

        #endregion
    }
}
