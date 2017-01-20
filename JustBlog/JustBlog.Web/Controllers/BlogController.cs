using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Core;
using JustBlog.Web.Models;

namespace JustBlog.Web.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository _blogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        //
        // GET: /Blog/
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Posts(int p=1)
        {
            BlogRepository blogs =new BlogRepository();
            
            var viewModel = new ListViewModel();
            viewModel.Posts = _blogRepository.Posts(0, 10);
            viewModel.Total = _blogRepository.TotalPosts();
            ViewBag.Title = "Latest Posts";
            return View("List", viewModel);
        }
    }
}

