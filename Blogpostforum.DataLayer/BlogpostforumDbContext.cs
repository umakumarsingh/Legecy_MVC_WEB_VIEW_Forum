using Blogpostforum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.DataLayer
{
    public class BlogpostforumDbContext : DbContext
    {
        public BlogpostforumDbContext() :base("name=BlogConnectionString")
        {

        }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
