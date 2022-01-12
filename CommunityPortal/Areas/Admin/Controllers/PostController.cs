using System;
using System.Collections.Generic;
using System.Linq;
using CommunityPortal.Areas.Admin.Models.Services;
using CommunityPortal.Areas.Admin.Models.ViewModels.Post;
using CommunityPortal.Models.Domains;
using CommunityPortal.Models.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace CommunityPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private PostService Service { get; }
        private CategoryService CategoryService { get; }

        public PostController(PostService service, CategoryService categoryService)
        {
            Service = service;
            CategoryService = categoryService;
        }

        public IActionResult Index(FilterPostViewModel entry)
        {
            const int size = 20;

            List<Post> posts = Service.GetAll();

            if (!string.IsNullOrEmpty(entry.Search))
            {
                posts = posts.Where(item => item.Title.Contains(entry.Search)).ToList();
            }

            if (!string.IsNullOrEmpty(entry.Sort) && !string.IsNullOrEmpty(entry.Type))
            {
                if (entry.Sort.Equals(nameof(IndexPostViewModel.Id)))
                {
                    if (entry.Type.Equals("Asc"))
                    {
                        posts = posts.OrderBy(item => item.Id).ToList();
                    }
                    else if (entry.Type.Equals("Desc"))
                    {
                        posts = posts.OrderByDescending(item => item.Id).ToList();
                    }
                }
                else if (entry.Sort.Equals(nameof(IndexPostViewModel.Title)))
                {
                    if (entry.Type.Equals("Asc"))
                    {
                        posts = posts.OrderBy(item => item.Title).ToList();
                    }
                    else if (entry.Type.Equals("Desc"))
                    {
                        posts = posts.OrderByDescending(item => item.Title).ToList();
                    }
                }
                else if (entry.Sort.Equals(nameof(IndexPostViewModel.Created)))
                {
                    if (entry.Type.Equals("Asc"))
                    {
                        posts = posts.OrderBy(item => item.Created).ToList();
                    }
                    else if (entry.Type.Equals("Desc"))
                    {
                        posts = posts.OrderByDescending(item => item.Created).ToList();
                    }
                }
            }

            entry.Pages = (int)Math.Ceiling(posts.Count / (double)size);

            int offset = entry.Page > 1 ? (entry.Page - 1) * size : 0;

            entry.Result.AddRange(posts
                .Skip(offset)
                .Take(size)
                .Select(item => new IndexPostViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Created = DateTime.Now.Subtract(item.Created)
                })
                .ToList());


            return View(entry);
        }

        public IActionResult Create()
        {
            ViewData["Categories"] = CategoryService.GetAll();
            return View(new CreatePostViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel entry)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = CategoryService.GetAll();
                return View(entry);
            }

            Service.Add(entry);

            TempData.Message("rashin", "Your post saved successfully");

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            Post entry = Service.GetById(id);

            if (entry == null)
            {
                TempData.Message("rashin", "Sorry, there is a problem happened");
                return RedirectToAction(nameof(Index));
            }

            ViewData["Categories"] = CategoryService.GetAll();
            ViewBag.Id = id;

            CreatePostViewModel model = new CreatePostViewModel()
            {
                Title = entry.Title,
                Thumbnail = entry.Thumbnail,
                Content = entry.Content,
                Created = entry.Created,
                Categories = entry.Categories
                    .Select(item => item.CategoryId)
                    .ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CreatePostViewModel entry)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = CategoryService.GetAll();
                ViewBag.Id = id;

                return View(entry);
            }

            TempData.Message("rashin",
                Service.Edit(id, entry) ? 
                    "Your post updated successfully" : 
                    "Sorry, there is a problem happened"
                );

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            TempData.Message("rashin",
                Service.Remove(id) ?
                    "Your post deleted successfully" :
                    "Sorry, there is a problem happened"
            );

            return RedirectToAction(nameof(Index));
        }
    }
}
