using Blogpostforum.DataLayer;
using Blogpostforum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogpostforum.BussinessLayer.Services.Repository
{
    public class BlogPostRepository : IBlogPostRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting DbContext
        /// in constructor and getting a data from sql server
        /// </summary>
        private readonly BlogpostforumDbContext _forumDbContext;

        public BlogPostRepository(BlogpostforumDbContext forumDbContext)
        {
            _forumDbContext = forumDbContext;
        }
        /// <summary>
        /// Add new comment on post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comments"></param>
        /// <returns></returns>
        public async Task<Comment> Comments(int postId, Comment comments)
        {
            try
            {
                if (comments.PostId == postId)
                {
                    _forumDbContext.Comments.Add(comments);
                }
                await _forumDbContext.SaveChangesAsync();
                return comments;
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        /// <summary>
        /// Add/create new post
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        public async Task<Post> Create(Post blogPost)
        {
            try
            {
                var post = _forumDbContext.Posts.Add(blogPost);
                await _forumDbContext.SaveChangesAsync();
                return post;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get All comments on post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Comment>> GetAllComments(int postId)
        {
            try
            {
                var commentlist = await _forumDbContext.Comments.Where(x => x.PostId == postId).ToListAsync();
                return commentlist;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get all post
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> GetAllPost()
        {
            try
            {
                var postlist = await _forumDbContext.Posts.ToListAsync();
                return postlist;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get single post by post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<Post> GetPostById(int postId)
        {
            try
            {
                var post = await _forumDbContext.Posts.FirstOrDefaultAsync(x => x.PostId == postId);
                return post;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Disposing DbContext
        /// </summary>
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _forumDbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
