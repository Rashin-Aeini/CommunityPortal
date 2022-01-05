using CommunityPortal.Areas.Admin.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunityPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private CategoryService Service { get; }

        public CategoryController(CategoryService service)
        {
            Service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return Ok(Service.GetAll());
        }
    }
}
