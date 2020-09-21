using Blogpostforum.BussinessLayer.Interfaces;
using Blogpostforum.BussinessLayer.Services.Repository;
using Blogpostforum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.BussinessLayer.Services
{
    public class BlogPostServices : IBlogPostServices
    {
        /// <summary>
        /// Createing Referance variable of IBlogPostRepository and injecing in BlogPostServices constructor
        /// </summary>
        private readonly IBlogPostRepository _postRepository;

        public BlogPostServices(IBlogPostRepository blogPostRepository)
        {
            _postRepository = blogPostRepository;
        }
        /// <summary>
        /// Add new comment on post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public async Task<Comment> Comments(int postId, Comment comments)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create new post
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        public async Task<Post> Create(Post blogPost)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all comments on post by Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllComments(int postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get All post from Db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> GetAllPost()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get post by Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<Post> GetPostById(int postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
