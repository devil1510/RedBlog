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
}