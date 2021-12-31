﻿using System;
using System.Collections.Generic;
using System.Linq;
using CommunityPortal.Areas.Admin.Models.Services;
using CommunityPortal.Areas.Admin.Models.ViewModels.Post;
using CommunityPortal.Models.Domains;
using Microsoft.AspNetCore.Mvc;

namespace CommunityPortal.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private IService<Post, CreatePostViewModel> Service { get; }

        public PostController(IService<Post, CreatePostViewModel> service)
        {
            Service = service;
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
    }
}
