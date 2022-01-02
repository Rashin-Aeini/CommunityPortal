using System.Collections.Generic;
using CommunityPortal.Models.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CommunityPortal.Areas.Admin.ViewComponents
{
    public class MessageViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            IDictionary<string, List<string>> messages = TempData.Message();

            return View(messages);
        }
    }
}
