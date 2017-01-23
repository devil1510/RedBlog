using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using JustBlog.Core.Objects;

namespace JustBlog.Web
{
    public static class ActionLinkExtensions
    {
        public static MvcHtmlString PostLink(this HtmlHelper helper,Post post)
        {
            return helper.ActionLink(
                post.Title, "Post", "Blog",
                    new {
                        id=post.Id
                    },
                    new
                    {
                        title=post.Title
                    }
                );
        }

        
    }
}