using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JustBlog.Core;
using JustBlog.Web.Models;
using Post = JustBlog.Core.Objects.Post;

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

        [HttpGet]
        public ViewResult Post(int id)
        {
            PostModel model=new PostModel();
            var post = _blogRepository.Post(id);
            model = post == null ? null : Mapping(post);
            return View("Post",model);
        }

        [HttpGet]
        public ViewResult Posts()
        {
            List<PostModel> model=new List<PostModel>();
            var posts = _blogRepository.Posts();
            if (posts != null && posts.Any())
            {
                foreach (var item in posts)
                {
                    model.Add(Mapping(item));
                }
            }
            return View("Posts", model);
        }

        private  PostModel Mapping(Post post)
        {
             PostModel model=new PostModel()
             {
                 Id = post.Id,
                 Title = post.Title,
                 ShortDescription = post.ShortDescription,
                 Description = post.Description,
                 UrlSlug = post.UrlSlug,
                 Modified = post.Modified,
                 Published = post.Published
             };
            return model;
        }
    }
}

