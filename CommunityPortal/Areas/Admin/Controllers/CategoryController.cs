using System;
using System.Collections.Generic;
using System.Linq;
using CommunityPortal.Areas.Admin.Models.Services;
using CommunityPortal.Areas.Admin.Models.ViewModels.Category;
using CommunityPortal.Models.Domains;
using CommunityPortal.Models.Extensions;
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

        public IActionResult Index(FilterCategoryViewModel entry)
        {
            const int size = 20;

            List<Category> categories = Service.GetAll()
                .Where(item => item.Title.Contains(entry.Search))
                .ToList();

            entry.Pages = (int)Math.Ceiling(categories.Count / (double)size);

            int offset = entry.Page > 1 ? (entry.Page - 1) * size : 0;

            entry.Result.AddRange(categories
                .Skip(offset)
                .Take(size)
                .Select(item => new IndexCategoryViewModel()
                {
                    Id = item.Id,
                    Title = item.Title
                })
                .ToList());

            return View(entry);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCategoryViewModel entry)
        {
            if (!ModelState.IsValid)
            {
                return View(entry);
            }

            Service.Add(entry);

            TempData.Message("Rashin", "Your category saved successfully");


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category entry = Service.GetById(id);

            if (entry == null)
            {
                TempData.Message("Rashin", "The category doesn't exist");
                return RedirectToAction(nameof(Index));
            }

            CreateCategoryViewModel model = new CreateCategoryViewModel()
            {
                Title = entry.Title
            };
            ViewBag.Id = entry.Id;

            return View(model);
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, CreateCategoryViewModel entry)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Id = id;
                return View(entry);
            }

            if (Service.Edit(id, entry))
            {
                TempData.Message("Rashin", "The category updated");
            }
            else
            {
                TempData.Message("Rashin", "Have some problem in updating, please try later");
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (Service.Remove(id))
            {
                TempData.Message("Rashin", "The category delete");
            }
            else
            {
                TempData.Message("Rashin", "Have some problem in updating, please try later");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
