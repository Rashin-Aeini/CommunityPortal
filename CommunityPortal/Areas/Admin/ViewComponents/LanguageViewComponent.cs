using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CommunityPortal.Areas.Admin.ViewComponents
{
    public class LanguageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(new List<string>(){ "Persian", "English" });
        }
    }
}
