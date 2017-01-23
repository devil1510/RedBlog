using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace JustBlog.Web.Models
{
    public class ListViewModel
    {
        public IList<JustBlog.Core.Objects.Post> Posts { get; set; }
        public int Total { get; set; }
    }

    public class PostModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual string Description { get; set; }
        public virtual string UrlSlug { get; set; }
        public virtual bool Published { get; set; }
        public virtual DateTime Modified { get; set; }
    }
}