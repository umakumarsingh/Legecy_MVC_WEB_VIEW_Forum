using Blogpostforum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.BussinessLayer.Services.Repository
{
    public interface IBlogPostRepository
    {
        Task<Post> Create(Post blogPost);
        Task<Post> GetPostById(int postId);
        Task<IEnumerable<Post>> GetAllPost();
        Task<IEnumerable<Comment>> GetAllComments(int postId);
        Task<Comment> Comments(int postId, Comment comments);
    }
}
