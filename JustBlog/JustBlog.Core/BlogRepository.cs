using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JustBlog.Core.Data;
using JustBlog.Core.Objects;
using Post = JustBlog.Core.Objects.Post;

namespace JustBlog.Core
{
    public class BlogRepository:IBlogRepository
    {
        private JustBlogEntities _blogContext=new JustBlogEntities();
        private IUnitOfWork _unitOfWork;

        public BlogRepository()
        {
            _unitOfWork=new UnitOfWork();
        }

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


        public IList<Post> Posts()
        {
            string query = "";
            List<Post> posts = _unitOfWork.ExecuteQuery<Post>("Exec pGetBlogs");
            return posts;
        }

        public bool CreateUser(User user)
        {
            SqlParameter idParameter=new SqlParameter(){ParameterName = "ID",Value = user.ID,DbType = DbType.String};
            SqlParameter firstNameParameter = new SqlParameter() { ParameterName = "FirstName", Value = user.FirstName, DbType = DbType.String };
            SqlParameter lastNameNameParameter = new SqlParameter() { ParameterName = "LastName", Value = user.LastName, DbType = DbType.String };
            SqlParameter emailParameter = new SqlParameter() { ParameterName = "Email", Value = user.Email, DbType = DbType.String };
            SqlParameter passwordHashParameter = new SqlParameter() { ParameterName = "Password", Value = user.Password, DbType = DbType.String };

            var result = _unitOfWork.ExecuteCommand("Exec pCreateUser @ID=@ID,@FirstName=@FirstName,@LastName=@LastName,@Email=@Email,@Password=@Password",
                idParameter, firstNameParameter, lastNameNameParameter, emailParameter, passwordHashParameter);
            return result;
        }

        private SqlParameter CreateSqlParameter(string parameterName,object value,bool isOutputDirection=false)
        {
            SqlParameter parameter=new SqlParameter();
            Object dbValue;
            if (value == null && isOutputDirection == false)
                dbValue = DBNull.Value;
            else
            {
                dbValue = value;
                var typeName = dbValue.GetType().FullName.ToLower();
                switch (typeName)
                {
                    case "string":
                        parameter.DbType=DbType.String;
                        break;
                    case "int":
                        parameter.DbType=DbType.Int32;
                        break;
                    case "long":
                        parameter.DbType=DbType.Int64;
                        break;

                }
            }
            parameter.ParameterName = parameterName;
            if (isOutputDirection)
            {
                parameter.Direction=ParameterDirection.Output;
            }
            return parameter;
        }
    }
}
