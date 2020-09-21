using Blogpostforum.BussinessLayer.Interfaces;
using Blogpostforum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Blogpostforum.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// Creating Referance Variable of IBlogPostServices and injecting into controller constructor
        /// </summary>
        private readonly IBlogPostServices _bpServices;

        public BlogController(IBlogPostServices blogPostServices)
        {
            _bpServices = blogPostServices;
        }
        /// <summary>
        /// Get All Post
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create new Post
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }
        /// <summary>
        /// Create new post Post ation Method.
        /// </summary>
        /// <param name="blogPost"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Abstract,Description,PostedDate")] Post blogPost)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Create new comment
        /// </summary>
        /// <returns></returns>
        public ActionResult Comments()
        {
            return View();
        }
        /// <summary>
        /// Create new commnet on Post, Post Method
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Comments(int postId, Comment comment)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get List of comments by Post Id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<ActionResult> BlogComments(int? postId)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
