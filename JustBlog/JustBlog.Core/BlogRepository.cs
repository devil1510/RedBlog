using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Data;
using Post = JustBlog.Core.Objects.Post;

namespace JustBlog.Core
{
    public class BlogRepository:IBlogRepository
    {
        private JustBlogEntities _blogContext=new JustBlogEntities();

        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts =from p in  _blogContext.Posts.Where(p=>p.Published==true).OrderBy(p=>p.Id).Skip(pageNo*pageSize).Take(pageSize) 
                       select new Post()
                       {
                           Id = p.Id,
                           Title = p.Title,
                           ShortDescription = p.ShortDecription,
                           Description = p.Description,
                           PostOn = p.PostOn,
                           Modified = p.Modified,
                           
                       };
            return posts.ToList();
        }

        public int TotalPosts()
        {
             return _blogContext.Posts.Where(p => p.Published == true).Count();
        }

        public Post Post(int id)
        {
            var post = _blogContext.Posts.SingleOrDefault(x => x.Id == id);
            if (post != null)
            {
                return new Post()
                {
                    Id = post.Id,
                    ShortDescription = post.ShortDecription,
                    Title = post.Title,
                    Description = post.Description,
                    Modified = post.Modified,
                    UrlSlug = post.UrlSlug
                };
            }
            return null;
        }
    }
}
